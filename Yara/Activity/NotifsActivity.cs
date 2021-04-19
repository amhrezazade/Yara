using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Widget;
using System.Threading.Tasks;
using Yara.Data;
using Yara.Service;


namespace Yara.Activity
{
    [Activity(Label = "NotifsActivity")]
    public class NotifsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Set layout content  
            SetContentView(Resource.Layout.Notifs);

        }
    }
}