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
using Xamarin.Essentials;

namespace Yara.Activity
{
    [Activity(Label = "About")]
    public class AboutActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.About);
            var iv = FindViewById<ImageView>(Resource.Id.ivabout);

            iv.Click += async (s, e) =>
            {
                await Browser.OpenAsync("https://www.instagram.com/amhrezazade/", BrowserLaunchMode.SystemPreferred);
            };

        }
    }
}