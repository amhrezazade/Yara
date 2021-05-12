﻿using Android.OS;
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
using System.Threading.Tasks;
using Android.App;

namespace Yara.Activity
{
    [Activity(Label = "منابع")]
    public class ResourceActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.ResourceActivity);
            var rv = FindViewById<RecyclerView>(Resource.Id.resourcerecyclerview);
            rv.SetLayoutManager(new LinearLayoutManager(this));
            rv.SetAdapter(new ContentItemAdapter(db.Load().Resources.ToArray()));
        }
    }
}