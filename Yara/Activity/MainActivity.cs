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
using AndroidX.AppCompat.Widget;

namespace Yara.Activity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        DateTime LastUpdate;
        private async void LoadImage()
        {
            var iv = FindViewById<ImageView>(Resource.Id.ivprofileimage);
            try
            {
                iv.SetImageBitmap(await db.LoadProfileImageAsync());
            }
            catch
            {
                iv.SetImageResource(Resource.Drawable.ic_baseline_person_24);
            }
        }
        
        
        private void setup()
        {
            var data = db.Load().Home;
            LastUpdate = DateTime.Parse(data.LastUpdate);
            FindViewById<TextView>(Resource.Id.tvstudentname).Text = data.Name;
            FindViewById<TextView>(Resource.Id.tvstudentcode).Text = data.StudentCode;
            FindViewById<TextView>(Resource.Id.tvpracticescaption).Text = data.practicesText;
            FindViewById<TextView>(Resource.Id.tvstudentid).Text = data.StudentId;
            FindViewById<TextView>(Resource.Id.tvannouncescaption).Text = data.announcesText;
            FindViewById<TextView>(Resource.Id.tvresourcescaption).Text = data.resourcesText;
            FindViewById<TextView>(Resource.Id.tvexam).Text = data.examText;
            FindViewById<TextView>(Resource.Id.tvtoday).Text = data.todayText;
            FindViewById<TextView>(Resource.Id.tvteacher).Text = data.ChatText;

            var t = FindViewById<TextView>(Resource.Id.tvactiveterm);
            t.Text = data.activeterm;
            t.Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(SelectTermActivity)));
            };

            FindViewById<Button>(Resource.Id.btshowpractice).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(PracticesActivity)));
            };
            FindViewById<Button>(Resource.Id.btannouncesshow).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(AnnouncesActivity)));
            };
            FindViewById<Button>(Resource.Id.btresourcesshow).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(ResourceActivity)));
            };
            FindViewById<Button>(Resource.Id.btshowexam).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(ExamActivity)));
            };
            FindViewById<Button>(Resource.Id.btshowtoday).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(TodayActivity)));
            };
            FindViewById<Button>(Resource.Id.btshowteacher).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(TeacherActivity)));
            };
            FindViewById<TextView>(Resource.Id.tvabout).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(AboutActivity)));
            };

            FindViewById<Button>(Resource.Id.btexit).Click += (s, e) =>
            {
                if (db.clearData())
                {
                    StartActivity(new Intent(Application.Context, typeof(splash)));
                    Finish();
                }

            };

            FindViewById<Button>(Resource.Id.btupdate).Click += (s, e) =>
            {
                StartActivity(new Intent(Application.Context, typeof(splash)));
                Finish();
            };

            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            setup();
            Task startupWork = new Task(() => { LoadImage(); });
            startupWork.Start();
        }

        protected override void OnResume()
        {
            base.OnResume();

            FindViewById<TextView>(Resource.Id.tvTitel).Text =
                " اخرین به روز رسانی : " +
                DateTimeHelper.GetDateString(LastUpdate);

        }

    }

}

