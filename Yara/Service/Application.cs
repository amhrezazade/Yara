using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Yara.Models;
using Yara.Models.apiModels;
using Yara.Models.ViewModels;


namespace Yara.Service
{
    public delegate void Progress(int p);
    public static class App
    {
        //public static event Progress RefreshProgress;
        public static string GetDateString(string date,string time)
        {
           return date[0].ToString() + date[1] + date[2] + date[3] + "/" +
                date[4] + date[5] + "/" +
                date[6] + date[7] + " , " +
                time[0] + time[1] + ":" +
                time[2] + time[3];
        }

        public static async Task ItemClick(string arg)
        {
            await Browser.OpenAsync(arg, BrowserLaunchMode.SystemPreferred);
        }


        public static async Task<string> Login(string Username,string Password)
        {
            
            LoginModel model = new LoginModel()
            {
                username = Username,
                password = Password,
                userTypeID = 1
            };

            if (model.username.Length < 8 || model.password.Length < 8)
                return "نام کاربری و رمز عبور نباید از 8 کاراکتر کمتر باشند";

            var authResult = await Api.Login(model);

            if (!authResult.OK)
                return authResult.Message;

            await db.SaveToken(authResult.data);

            return "OK";

        }

        public static async Task<string> RefreshData()
        {

            var res = await Server.Test();
            switch (res)
            {
                case Server.TestApiResult.DataNull:
                case Server.TestApiResult.TokenError:
                    return "Login";
                case Server.TestApiResult.NetworkError:
                    return "خطای اتصال به شبکه";
                case Server.TestApiResult.OK:
                    break;
                default:
                    return "خطا";
            }

            var data = new appData();
            

            var studentResult = await Api.GetStudetData();
            var TermListRes = await Api.GetTermList();
            var ActiveTermRes = await Api.GetActiveTermId();

            var imagebytes = await Server.GetProfileImageBytes(studentResult.data.ImageFileName);
            await db.SaveProfileImage(imagebytes);
            data.Home.Name = studentResult.data.FirstName + " " +  studentResult.data.LastName;
            data.Home.StudentCode = studentResult.data.StudentCode;
            data.Home.StudentId = studentResult.data.StudentID.ToString();
            int ActiveTerm = ActiveTermRes.data.ActiveTerm;
            data.Home.activeterm = ActiveTerm.ToString();
            Lesson[] Lessons = null;
            foreach (var term in TermListRes.data)
                if (term.Term == ActiveTerm)
                {
                    Lessons = term.Lessons;
                    break;
                }
            if(Lessons ==null)
                return "خطا";

            int practiceCount = 0;
            foreach (var l in Lessons)
            {
                
                var AnnouncesRes = await Api.GetAnnounces(l.GroupID);
                var PracticesRes = await Api.GetPractices(l.GroupID);
                var LessonInfoRes = await Api.GetLessonInfo(l.GroupID);

                var titel = new NotificationItem(l.LessonTitle, LessonInfoRes.data.LecturerLastName);

                data.Announces.Add(new ContentItem(titel));
                foreach (var a in AnnouncesRes.data)
                    data.Announces.Add(new ContentItem(a));

                List<Practices> insope = new List<Practices>();
                List<Practices> answered = new List<Practices>();
                List<Practices> lost = new List<Practices>();
                foreach (var p in PracticesRes.data)
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

                if (insope.Count > 0)
                {
                    data.practicesList.InScope.Add(new ContentItem(titel));
                    foreach (var i in insope)
                        data.practicesList.InScope.Add(new ContentItem(i));
                }

                if (answered.Count > 0)
                {
                    data.practicesList.Answered.Add(new ContentItem(titel));
                    foreach (var i in answered)
                        data.practicesList.Answered.Add(new ContentItem(i));
                }

                if (lost.Count > 0)
                {
                    data.practicesList.Lost.Add(new ContentItem(titel));
                    foreach (var i in lost)
                        data.practicesList.Lost.Add(new ContentItem(i));
                }
            }

            data.Home.practicesText = practiceCount.ToString() + "تمرین آماده پاسخ  ";


            await db.Save(data);

            return "OK";
        }




    }
}