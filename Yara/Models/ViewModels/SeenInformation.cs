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

namespace Yara.Models.ViewModels
{
    public class SeenInformation
    {
        public int VisitID { set; get; }
        public string VisitDate { set; get; }
        public string VisitTime { set; get; }
    }
}