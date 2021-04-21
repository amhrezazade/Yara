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
using Yara.Models;
using Yara.Models.ViewModels;

namespace Yara.Models
{
    public class appData
    {
        public UserData user { set; get; } 
        public int Activeterm { set; get; } 
        public List<LessonItem> Lessons { set; get; }
    }
}