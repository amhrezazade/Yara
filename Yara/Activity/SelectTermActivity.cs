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
using Android.App;
using Android.Graphics;
using Yara.Models;

namespace Yara.Activity
{
    [Activity(Label = "Term")]
    public class SelectTermActivity : AppCompatActivity
    {
        LinearLayout lay;
        appData data;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.SelectTerm);
            lay = FindViewById<LinearLayout>(Resource.Id.SelectLayout);

            data = db.Load();
            
            string[] list = data.Home.Terms;
            foreach (string s in list)
            {
                Button t = new Button(Application.Context);
                t.SetBackgroundColor(Color.Gray);
                t.Text = s;
                t.Click += async (se, e) =>
                {
                    data.Home.activeterm = s;
                    await db.Save(data);
                    StartActivity(new Intent(Application.Context, typeof(splash)));
                    Finish();
                };
                t.SetTextColor(Color.Black);
                lay.AddView(t);

            }
            

        }
    }
}