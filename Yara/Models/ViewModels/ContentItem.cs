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
using Yara.Helper;
using Yara.Models.apiModels;
using Yara.Service;

namespace Yara.Models.ViewModels
{
    public class ContentItem
    {
        public string Titel { set; get; }
        public string Caption { set; get; }
        public string date { set; get; }
        public string GreenNote { set; get; }
        public string RedNote { set; get; }
        public string Def { set; get; }
        public string LinkTitel { set; get; }
        public string Link { set; get; }
        public ImageType Image { set; get; }


        public ContentItem(Practices p,string LessonName)
        {
            Titel = p.Title;
            Caption = p.Description + "\r\n" + "نمره " + p.Score + " از " + p.ScoreBase;
            date = DateTimeHelper.GetDateString(p.RegDate, p.RegTime);
            GreenNote = DateTimeHelper.GetDateString(p.StartDate, p.StartTime);
            RedNote = DateTimeHelper.GetDateString(p.FinishDate, p.FinishTime);
            Def = LessonName + " (" + p.PracticeID . ToString() + ")";
            if (p.FileName == string.Empty)
                Link = "";
            else
                Link = StaticData.DownloadpracticesURL +
                    p.FileName +
                    "?token=" +
                    General.GenerateToken(p.FileName);
            Image = ImageType.Note;
            LinkTitel = "فایل پیوست";
            ClearNull();
        }

        public ContentItem(NotificationItem p)
        {
            Titel = p.Titel;
            Caption = p.Caption;
            date = string.Empty;
            GreenNote = string.Empty;
            RedNote = string.Empty;
            Def = string.Empty;
            Link = string.Empty;
            LinkTitel = string.Empty;
            Image = ImageType.Subject;
            ClearNull();
        }


        public ContentItem(Announces a, string LessonName)
        {
            Titel = a.Title;
            Caption = a.Description;
            date = DateTimeHelper.GetDateString(a.RegDate,a.RegTime);
            if (a.SeenInfo == null)
            {
                GreenNote = string.Empty;
                RedNote = "جدید";
            }
            else 
            {
                GreenNote = "دیده شده در ";
                var inf = JsonConvert.DeserializeObject<SeenInformation>(a.SeenInfo);
                RedNote = DateTimeHelper.GetDateString(inf.VisitDate, inf.VisitTime);
            }
            Def = LessonName + " (" + a.AnnounceID.ToString() + ")";
            if (a.FileName == string.Empty)
                Link = "";
            else
                Link = StaticData.DownloadannouncesURL +
                    a.FileName +
                    "?token=" +
                    General.GenerateToken(a.FileName);
            LinkTitel = "فایل پیوست";
            Image = ImageType.Motif;
            ClearNull();
        }

        public ContentItem(Exam e, string LessonName)
        {
            Caption = " شماره آزمون : " + e.ExamID;

            Caption += "\r\n" +
                " شماره گروه :   " + e.GroupID;


            if (e.StudentScore != null && e.TotalScore != null)
                Caption += "\r\n" +
                    " نمره شما : " + e.StudentScore.Value.ToString() + " از " + e.TotalScore.Value.ToString();

            Caption += "\r\n" +
                +e.AnsweredQuestionsCount + " سوال پاسخ داده شده از  " + e.QuestionsCount;

            if (e.NeedAuthentication)
            {
                Caption += "\r\n" + " نیاز به احراز هویت پیامکی دارد🔒  ";

                if (e.InAuthProcessScope)
                    Caption += "\r\n" + " ❕شما در بازه احراز هویت قرار دارید ";

                if (e.IsAuthenticated)
                    Caption += "\r\n" + " احراز هویت انجام شده است✅ ";
            }  
            else
                Caption += "\r\n" + " نیاز به احراز هویت پیامکی ندارد🔓  ";

            if (e.InExamScope)
                Caption += "\r\n" + " 📃آزمون در حال اجرا...  ";


            Caption += "\r\n" + e.Description;

            if(e.AnsweredQuestionsCount == 0)
                Titel = e.Title;
            else
                Titel = e.Title + " (شرکت کرده) ";
            date = DateTimeHelper.GetDateString(e.RegDate, e.RegTime);
            GreenNote = DateTimeHelper.GetDateString(e.StartDate, e.StartTime);
            RedNote = DateTimeHelper.GetDateString(e.FinishDate, e.FinishTime);
            Def = LessonName;
            Link = "";
            Image = ImageType.exam;
            LinkTitel = "فایل پیوست";
            ClearNull();
        }

        public ContentItem(Resources a, string LessonName)
        {
            Titel = a.Title;
            Caption = a.Description;
            date = DateTimeHelper.GetDateString(a.RegDate, a.RegTime);
            GreenNote = string.Empty;
            RedNote = string.Empty;
            Def = LessonName + " (" + a.ResourceID.ToString() + ")";
            if (a.FileName == string.Empty)
                Link = "";
            else
                Link = StaticData.DownloadresourcesURL +
                    a.FileName +
                    "?token=" +
                    General.GenerateToken(a.FileName);
            LinkTitel = "فایل پیوست";
            Image = ImageType.Cloud;
            ClearNull();
        }

        public ContentItem(Teacher t,LessonInfo i,Lesson l)
        {
            Titel = i.LecturerFirstName +
                " " +
                i.LecturerLastName +
                " " +
                t.MemberID.ToString();

            Caption = l.LessonTitle +
                " - " +
                i.EduGroupTitle + " شماره " +
                l.GroupID.ToString();

            Image = ImageType.Person;

            if (t.UnseenMessagesCount == 0)
                GreenNote = "پیام جدیدی نیست";
            else
            {
                GreenNote = DateTimeHelper.num(t.UnseenMessagesCount) + " پیام ناخوانده ";
                GreenNote = CommonExtensions.ToPersianNumber(GreenNote);
            }

            Def = l.GroupID.ToString() +
                "/2/" +
                t.MemberID.ToString();

            RedNote = string.Empty;
            date = string.Empty;
            Link = string.Empty;
            LinkTitel = string.Empty;
            ClearNull();
        }


        public ContentItem(Ticket t , string myname,string tname)
        {
            if (t.ReceiverMemberType == 1)
            {
                Titel = tname;
                Image = ImageType.mail;
            }
            else
            {
                Image = ImageType.Profile;
                Titel = myname;
            }
                

            Caption = t.Message;

            date = DateTimeHelper.GetDateString(t.RegDate, t.RegTime);

            if (t.SeenDate == null)
            {
                GreenNote = string.Empty;
                RedNote = "جدید";
            }
            else
            {
                GreenNote = "دیده شده در ";
                RedNote = DateTimeHelper.GetDateString(t.SeenDate, t.SeenTime);
            }

            Def = t.TicketID.ToString();

            if (t.FileName == string.Empty)
                Link = "";
            else
                Link = StaticData.DownloadresourcesURL +
                    t.FileName +
                    "?token=" +
                    General.GenerateToken(t.FileName);

            LinkTitel = "فایل پیوست";
        }

        public ContentItem()
        {
            Titel = string.Empty;
            Caption = string.Empty;
            date = string.Empty;
            GreenNote = string.Empty;
            RedNote = string.Empty;
            Def = string.Empty;
            Link = string.Empty;
            LinkTitel = string.Empty;
            Image = ImageType.None;
        }

        private void ClearNull()
        {
            if (Titel == null) Titel = "";
            if (Caption == null) Caption = "";
            if (date == null) date = "";
            if (GreenNote == null) GreenNote = "";
            if (RedNote == null) RedNote = "";
            if (Def == null) Def = "";
            if (Link == null) Link = "";
            if (LinkTitel == null) LinkTitel = "";
        }

        public string getShareText() =>
            "🧷" + Titel + " " + Def + "\r\n\r\n🛑" + Caption + "\r\n" + Link;
    }
}