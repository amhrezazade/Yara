using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Yara.Data;
using AndroidX.CardView.Widget;
using AndroidX.AppCompat.View.Menu;
using AndroidX.RecyclerView.Widget;
using Yara.Adapters;
using System.Collections.Generic;
using Yara.Models.ViewModels;

namespace Yara.Activity
{
    [Activity]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        NotificationAdapter mAdapter;
        List<NotificationItel> list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            list = new List<NotificationItel>();

            list.Add(new NotificationItel("Titel1", "Caption1", ""));
            list.Add(new NotificationItel("Titel2", "Caption2", ""));
            list.Add(new NotificationItel("Titel2", "Caption2", ""));
            list.Add(new NotificationItel("Titel2", "Caption2", ""));
            list.Add(new NotificationItel("Titel2", "Caption2", ""));

            mAdapter = new NotificationAdapter(list);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);         
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mRecyclerView.SetAdapter(mAdapter);
        }
    }
}

