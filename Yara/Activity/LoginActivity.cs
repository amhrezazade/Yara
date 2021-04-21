using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Yara.Models.apiModels;
using Yara.Service;

namespace Yara.Activity
{
    [Activity]
    public class LoginActivity : AppCompatActivity
    {
        Button btn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.loginActivuty);
            btn = FindViewById<Button>(Resource.Id.btnLogin);
            btn.Click += async (s, e) => { await btnClick(); };
        }

        private async Task btnClick()
        {
            EditText txtUsername = FindViewById<EditText>(Resource.Id.etStudentNumber);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.etPassword);
            TextView lblinfo = FindViewById<TextView>(Resource.Id.lblInfo);


            lblinfo.Text = "لطفا صبر کنید";
            btn.Visibility = ViewStates.Invisible;
            await Task.Delay(100);

            string res = await App.Login(txtUsername.Text, txtPassword.Text);

            if (res != "OK")
            {
                lblinfo.Text = res;
                btn.Visibility = ViewStates.Visible;
                return;
            }
            await App.RefreshData();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();

        }



    }

}