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
    public class LessonInfo
    {
        public int GroupID { set; get; }
        public int Term { set; get; }
        public string EduGroupTitle { set; get; }
        public string ExamDate { set; get; }
        public string ExamStartTime { set; get; }
        public string ExamFinishTime { set; get; }
        public string LecturerFirstName { set; get; }
        public string LecturerLastName { set; get; }
        public EduClasse[] Classes { set; get; }

    }
}
