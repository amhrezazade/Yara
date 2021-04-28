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
    public class NotificationItem
    {
        public NotificationItem(string titel,string caption)
        {
            Titel = titel;
            Caption = caption;
        }

        public string Titel { set; get; }
        public string Caption { set; get; }

    }
}