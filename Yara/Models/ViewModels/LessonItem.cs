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
using Yara.Models.apiModels;

namespace Yara.Models.ViewModels
{
    public class LessonItem
    {
        public LessonItem()
        { }
        public LessonItem(Lesson l)
        {
            GroupID = l.GroupID;
            if (l.ExamDate == null) ExamDate = ""; else ExamDate = l.ExamDate;
            if (l.ExamStartTime == null) ExamStartTime = ""; else ExamStartTime = l.ExamStartTime;
            if (l.ExamFinishTime == null) ExamFinishTime = ""; else ExamFinishTime = l.ExamFinishTime;
            if (l.LessonCode == null) LessonCode = ""; else LessonCode = l.LessonCode;
            if (l.LessonTitle == null) LessonTitle = ""; else LessonTitle = l.LessonTitle;
            Announces = null;
            Practices = null;
        }

        public int GroupID { set; get; }
        public string ExamDate { set; get; }
        public string ExamStartTime { set; get; }
        public string ExamFinishTime { set; get; }
        public string LessonCode { set; get; }
        public string LessonTitle { set; get; }
        public string EduGroupTitle { set; get; }
        public string LecturerName { set; get; }
        public List<EduClasse> Classes { set; get; }

        public List<AnnouncesItem> Announces { set; get; }
        public List<PracticesItem> Practices { set; get; }
    }
}