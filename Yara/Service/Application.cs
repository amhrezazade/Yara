using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yara.Models;
using Yara.Models.apiModels;
using Yara.Models.ViewModels;

namespace Yara.Service
{
    public static class App
    {
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

            db.SaveToken(authResult.data);

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

            if (studentResult.OK)
            {
                var s = studentResult.data;
                data.user = new UserData()
                {
                    Name = s.FirstName + " " + s.LastName,
                    StudentId = s.StudentCode,
                    ImageUrl = StaticData.ProfileImageURL + s.ImageFileName,
                };
            }


            var TermListRes = await Api.GetTermList();
            var ActiveTermRes = await Api.GetActiveTermId();

            data.Activeterm = ActiveTermRes.data.ActiveTerm;

            Lesson[] Lessons = null;
            foreach (var term in TermListRes.data)
                if (term.Term == data.Activeterm)
                {
                    Lessons = term.Lessons;
                    break;
                }
            if(Lessons ==null)
                return "خطا";

            data.Lessons = new List<LessonItem>();
            foreach (var l in Lessons)
            {
                var Lesson = new LessonItem(l);

                var AnnouncesRes = await Api.GetAnnounces(Lesson.GroupID);
                if(AnnouncesRes.OK)
                    foreach (var a in AnnouncesRes.data)
                        Lesson.Announces.Add(new AnnouncesItem(a));

                var PracticesRes = await Api.GetPractices(Lesson.GroupID);
                if (PracticesRes.OK)
                    foreach (var a in PracticesRes.data)
                        Lesson.Practices.Add(new PracticesItem(a));

                data.Lessons.Add(Lesson);
            }

            db.Save(data);

            return "OK";
        }




    }
}