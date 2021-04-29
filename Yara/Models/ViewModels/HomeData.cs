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
    public class HomeData
    {
        public string Name { set; get; }
        public string StudentCode { set; get; }
        public string StudentId { set; get; }
        public string practicesText { set; get; }
        public string activeterm { get; set; }
    }
}