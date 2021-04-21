using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yara.Activity;
using Yara.Adapters;
using Yara.Models.ViewModels;

namespace Yara.Service
{
    public class MainActivityService
    {



        public MainActivityService()
        {

        }

        public NotificationAdapter GetNotificationAdapter()
        {
            var list = new List<NotificationItem>();
            list.Add(new NotificationItem("Titel1", "Caption1", ""));
            list.Add(new NotificationItem("Titel2", "Caption2", ""));
            list.Add(new NotificationItem("Titel2", "Caption2", ""));
            list.Add(new NotificationItem("Titel2", "Caption2", ""));
            list.Add(new NotificationItem("Titel2", "Caption2", ""));
            return new NotificationAdapter(list);
        }

    }
}