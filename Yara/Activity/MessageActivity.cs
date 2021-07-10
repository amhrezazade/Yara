using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using AndroidX.CardView.Widget;
using AndroidX.AppCompat.View.Menu;
using AndroidX.RecyclerView.Widget;
using Yara.Adapters;
using System.Collections.Generic;
using Yara.Models.ViewModels;
using Yara.Service;
using Android.Content;
using Yara.Helper;
using System.Threading.Tasks;
using System;
using Yara.Models;

namespace Yara.Activity
{
    [Activity(Label = "پیام ها")]
    public class MessageActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.ContentItemActivity);
            var rv = FindViewById<RecyclerView>(Resource.Id.contentitemrecyclerview);
            rv.SetLayoutManager(new LinearLayoutManager(this));

            var data = db.Load();
            string arg = Intent.GetStringExtra("arg");
            var tRes = await Api.GetTickets(arg);
            if (tRes.data == null)
            {
                Finish();
                return;
            }
                

            var myname = data.Home.Name;
            var teachername = data.Teachers.Find(x => x.Def == arg).Titel;

            List<ContentItem> list = new List<ContentItem>();
            foreach (var t in tRes.data)
                list.Add(new ContentItem(t,myname, teachername));

            if (list.Count == 0)
                list.Add(new ContentItem(new NotificationItem("موردی یافت نشد", "")));


            rv.SetAdapter(new ContentItemAdapter(list.ToArray()));
        }
    }
}