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
        //public UserData user { set; get; } 
        //public int Activeterm { set; get; } 
        //public List<LessonItem> Lessons { set; get; }
        public List<ContentItem> Home { set; get; } = new List<ContentItem>();
        public List<ContentItem> Announces { set; get; } = new List<ContentItem>();
        public List<ContentItem> Exams { set; get; } = new List<ContentItem>();
        public List<ContentItem> Teachers { set; get; } = new List<ContentItem>();
        public practices practicesList { set; get; } = new practices();
    }

    public class practices
    {
        public List<ContentItem> InScope { set; get; } = new List<ContentItem>();
        public List<ContentItem> Answered { set; get; } = new List<ContentItem>();
        public List<ContentItem> Lost { set; get; } = new List<ContentItem>();
    }
}