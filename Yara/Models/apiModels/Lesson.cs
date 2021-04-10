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

namespace Yara.Models.apiModels
{
    public class Lesson
    {
        public int GroupID { set; get; }
        public string ExamDate { set; get; }
        public string ExamStartTime { set; get; }
        public string ExamFinishTime { set; get; }
        public string LessonCode { set; get; }
        public string LessonTitle { set; get; }
        public int UnseenAnnounces { set; get; }
        public int UnseenTickets { set; get; }
        public int UnansweredPractices { set; get; }

    }
}