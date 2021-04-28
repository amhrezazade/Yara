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

namespace Yara.Models
{
    public static class StaticData
    {
        public const string BaseUrl = "https://yaraapi.mazust.ac.ir";
        public const string UserAgent = "Yara Notifier Android Application";
        public const string ProfileImageURL = "https://reg.mazust.ac.ir/CPanel/StudentsImages/";
        public const string DownloadpracticesURL = "https://yaraapi.mazust.ac.ir/static/practices/";
        public const string DownloadannouncesURL = "https://yaraapi.mazust.ac.ir/static/announces/";
    }
}