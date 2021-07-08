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
using System.Threading.Tasks;

namespace Yara.Activity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {

        private async void LoadImage()
        {
            var iv = FindViewById<ImageView>(Resource.Id.ivprofileimage);
            try
            {
                iv.SetImageBitmap(await db.LoadProfileImage());
            }
            catch
            {
                iv.SetImageResource(Resource.Drawable.ic_baseline_person_24);
            }
        }
        
        private void fillText()
        {
            
            var data = db.Load().Home;
            FindViewById<TextView>(Resource.Id.tvstudentname).Text = data.Name;
            FindViewById<TextView>(Resource.Id.tvstudentcode).Text = data.StudentCode;
            FindViewById<TextView>(Resource.Id.tvpracticescaption).Text = data.practicesText;
            FindViewById<TextView>(Resource.Id.tvstudentid).Text = data.StudentId;
            FindViewById<TextView>(Resource.Id.tvactiveterm).Text = data.activeterm;
            FindViewById<TextView>(Resource.Id.tvannouncescaption).Text = data.announcesText;
            FindViewById<TextView>(Resource.Id.tvresourcescaption).Text = data.resourcesText;
            FindViewById<TextView>(Resource.Id.tvexam).Text = data.examText;
            FindViewById<TextView>(Resource.Id.tvtoday).Text = data.todayText;

        }
        
        private void setClickvent()
        {
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
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            fillText();
            setClickvent();
            Task startupWork = new Task(() => { LoadImage(); });
            startupWork.Start();
        }
    }

}

