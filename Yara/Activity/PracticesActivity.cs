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
using Yara.Models;

namespace Yara.Activity
{
    [Activity(Label = "تمارین")]
    public class PracticesActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        RecyclerView mRecyclerView;
        practices _data;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            _data = db.Load().practicesList;
            SetContentView(Resource.Layout.PracticesActivity);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.PracticesnavigationBar);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.PracticesrecyclerView);
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            navigation.SetOnNavigationItemSelectedListener(this);
            mRecyclerView.SetAdapter(new ContentItemAdapter(_data.InScope.ToArray()));
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_p_inscope:
                    mRecyclerView.SetAdapter(new ContentItemAdapter(_data.InScope.ToArray()));
                    return true;
                case Resource.Id.navigation_p_Answered:
                    mRecyclerView.SetAdapter(new ContentItemAdapter(_data.Answered.ToArray()));
                    return true;
                case Resource.Id.navigation_p_Lost:
                    mRecyclerView.SetAdapter(new ContentItemAdapter(_data.Lost.ToArray()));
                    return true;
            }
            return false;
        }

    }
}