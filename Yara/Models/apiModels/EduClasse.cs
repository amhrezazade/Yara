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
    public class EduClasse
    {
        public int DayID { set; get; }
        public string StartTime { set; get; }
        public string FinishTime { set; get; }
        public string ClassTitle { set; get; }
        public string FacultyTitle { set; get; }

    }
}
