using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Threading.Tasks;
using Yara.Service;

namespace Yara.Activity
{
    [Activity( MainLauncher = true)]
    public class splash : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.StartActivity);
            FindViewById<ImageView>(Resource.Id.imageView).SetImageResource(Resource.Drawable.logo);
        }

        protected override void OnResume()
        {
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
            base.OnResume();
        }

        protected override void OnPause()
        {
            Finish();
            base.OnPause();
        }

        async void SimulateStartup()
        {
            await Task.Delay(2000);

            var res = await App.RefreshData();

            if (res == "Login")
            {
                StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
                return;
            }


            if (res != "OK")
            {
                //Toast.MakeText(Application.Context, res, ToastLength.Long).Show();
                Finish();
                return;
            }


            StartActivity(new Intent(Application.Context, typeof(MainActivity)));

        }
    }
}