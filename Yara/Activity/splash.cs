using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Threading.Tasks;
using Yara.Service;
using System.Collections.Generic;
using Yara.Models;
using Yara.Models.apiModels;
using Yara.Models.ViewModels;
using System;
using Yara.Helper;

namespace Yara.Activity
{
    [Activity( MainLauncher = true)]
    public class splash : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.StartActivity);
            FindViewById<ImageView>(Resource.Id.imageView).SetImageResource(Resource.Drawable.logo);
        }
  
        protected override void OnResume()
        {
            SimulateStartup();
            base.OnResume();
        }

        protected override void OnPause()
        {
            Finish();
            base.OnPause();
        }

        async Task SimulateStartup()
        {
            TextView t = FindViewById<TextView>(Resource.Id.textView1);
            var res = await Server.Test();
            switch (res)
            {
                case Server.TestApiResult.DataNull:
                case Server.TestApiResult.TokenError:
                    StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
                    Finish();
                    return;
                case Server.TestApiResult.NetworkError:
                    t.Text = "خطای اتصال به شبکه";
                    await Task.Delay(1000);
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                    Finish();
                    return ;
                case Server.TestApiResult.OK:
                    break;
                default:
                    t.Text = "خطا ";
                    await Task.Delay(1000);
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                    Finish();
                    return;
            }

            var data = new appData();


            var studentResult = await Api.GetStudetData();
            var TermListRes = await Api.GetTermList();
            var ActiveTermRes = await Api.GetActiveTermId();

            var imagebytes = await Server.GetProfileImageBytes(studentResult.data.ImageFileName);
            if (imagebytes != null)
                await db.SaveProfileImage(imagebytes);

            data.Home.Name = studentResult.data.FirstName + " " + studentResult.data.LastName;
            data.Home.StudentCode = studentResult.data.StudentCode;
            data.Home.StudentId = studentResult.data.StudentID.ToString();
            int ActiveTerm = ActiveTermRes.data.ActiveTerm;
            ActiveTerm = 13992;
            data.Home.activeterm = ActiveTerm.ToString();
            Lesson[] Lessons = null;

            foreach (var term in TermListRes.data)
                if (term.Term == ActiveTerm)
                {
                    Lessons = term.Lessons;
                    break;
                }


            NotifCollector notif = new NotifCollector();
            int practiceCount = 0;
            int announcesCount = 0;
            int ResourcesCount = 0;
            int examcount = 0;
            int chatCount = 0;
            const int delay = 5;
            foreach (var l in Lessons)
            {
                notif.LessonName = l.LessonTitle;

                t.Text = (l.LessonTitle + " اعلان ها ...");
                await Task.Delay(delay);  
                var AnnouncesRes = await Api.GetAnnounces(l.GroupID);

                t.Text = (l.LessonTitle + " تمارین ...");
                await Task.Delay(delay);
                var PracticesRes = await Api.GetPractices(l.GroupID);

                t.Text = (l.LessonTitle + " اطلاعات ...");
                await Task.Delay(delay);
                var LessonInfoRes = await Api.GetLessonInfo(l.GroupID);

                t.Text = (l.LessonTitle + " منابع ...");
                await Task.Delay(delay);
                var ResourcesRes = await Api.GetResources(l.GroupID);

                t.Text = (l.LessonTitle + " آزمون ها ...");
                await Task.Delay(delay);
                var ExamRes = await Api.GetExams(l.GroupID);

                t.Text = (l.LessonTitle + " پیام ها ...");
                await Task.Delay(delay);
                var TeachersRes = await Api.GetTeachers(l.GroupID);


                t.Text = "در حال پردازش...";
                await Task.Delay(delay);

                var titel = new NotificationItem
                    (
                        l.LessonTitle + " " + l.GroupID.ToString(),
                        LessonInfoRes.data.LecturerFirstName + " " +
                        LessonInfoRes.data.LecturerLastName + " - " +
                        LessonInfoRes.data.EduGroupTitle
                    );


                if (TeachersRes.data != null)
                {
                    var teacher = TeachersRes.data[0];
                    data.Teachers.Add(new ContentItem(teacher, LessonInfoRes.data, l));
                    if (teacher.UnseenMessagesCount > 0)
                        notif.Add(new ContentItem(teacher, LessonInfoRes.data, l));
                    chatCount += teacher.UnseenMessagesCount;
                }

                if (AnnouncesRes.data.Length > 0)
                {              
                    data.Announces.Add(new ContentItem(titel));
                    foreach (var a in AnnouncesRes.data)
                    {
                        ContentItem item = new ContentItem(a, l.LessonTitle);
                        notif.Add(a);
                        data.Announces.Add(item);
                        if (a.SeenInfo == null)
                            announcesCount++;
                    }
                    data.Announces.Add(new ContentItem());
                }

                if (ExamRes.data.Length > 0)
                {
                    data.Exams.Add(new ContentItem(titel));
                    foreach (var a in ExamRes.data)
                    {
                        data.Exams.Add(new ContentItem(a, l.LessonTitle));
                        notif.Add(a);
                        examcount++;
                    }
                    data.Exams.Add(new ContentItem());
                }

                if (ResourcesRes.data.Length > 0)
                {
                    data.Resources.Add(new ContentItem(titel));
                    foreach (var a in ResourcesRes.data)
                    {
                        data.Resources.Add(new ContentItem(a, l.LessonTitle));
                        notif.Add(a);
                        ResourcesCount++;
                    }
                    data.Resources.Add(new ContentItem());
                }

                List<Practices> insope = new List<Practices>();
                List<Practices> answered = new List<Practices>();
                List<Practices> lost = new List<Practices>();
                foreach (var p in PracticesRes.data)
                {
                    notif.Add(p);
                    if (p.RegedAnswer == null)
                    {
                        if (p.InRegAnswerScope)
                        {
                            insope.Add(p);
                            practiceCount++;
                        }
                        else
                            lost.Add(p);
                    }
                    else
                        answered.Add(p);
                }


                if (insope.Count > 0)
                {
                    data.practicesList.InScope.Add(new ContentItem(titel));
                    foreach (var i in insope)
                        data.practicesList.InScope.Add(new ContentItem(i, l.LessonTitle));
                    data.practicesList.InScope.Add(new ContentItem());
                }



                if (answered.Count > 0)
                {
                    data.practicesList.Answered.Add(new ContentItem(titel));
                    foreach (var i in answered)
                        data.practicesList.Answered.Add(new ContentItem(i, l.LessonTitle));
                    data.practicesList.Answered.Add(new ContentItem());
                }



                if (lost.Count > 0)
                {
                    data.practicesList.Lost.Add(new ContentItem(titel));
                    foreach (var i in lost)
                        data.practicesList.Lost.Add(new ContentItem(i, l.LessonTitle));
                    data.practicesList.Lost.Add(new ContentItem());
                }



            }

            if (data.practicesList.Lost.Count == 0)
                data.practicesList.Lost.Add(new ContentItem(new NotificationItem("موردی یافت نشد", "")));

            if (data.practicesList.Answered.Count == 0)
                data.practicesList.Answered.Add(new ContentItem(new NotificationItem("موردی یافت نشد", "")));

            if (data.practicesList.InScope.Count == 0)
                data.practicesList.InScope.Add(new ContentItem(new NotificationItem("موردی یافت نشد", "")));


            data.Todays = notif.GetList();
            data.Home.todayText = notif.Count.ToString() + " اعلان فوری ";
            data.Home.ChatText = chatCount + " پیام ناخوانده ";
            data.Home.practicesText = practiceCount.ToString() + " تمرین آماده پاسخ  ";
            data.Home.announcesText = announcesCount.ToString() + " اعلان جدید  ";
            data.Home.resourcesText = ResourcesCount.ToString() + " منبع ";
            data.Home.examText = examcount.ToString() + " آزمون ";
            data.Home.LastUpdate = DateTime.Now.ToString();

            await db.Save(data);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
        }


    }
}