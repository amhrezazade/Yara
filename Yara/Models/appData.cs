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

        public HomeData Home { set; get; } = new HomeData();
        public List<ContentItem> Announces { set; get; } = new List<ContentItem>();
        public List<ContentItem> Exams { set; get; } = new List<ContentItem>(); 
        public List<ContentItem> Teachers { set; get; } = new List<ContentItem>();
        public List<ContentItem> Resources { set; get; } = new List<ContentItem>();
        public List<ContentItem> Todays { set; get; } = new List<ContentItem>();
        public practices practicesList { set; get; } = new practices();
    }
}