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
    [Activity(Label = "آزمون ها")]
    public class ExamActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.ContentItemActivity);
            var rv = FindViewById<RecyclerView>(Resource.Id.contentitemrecyclerview);
            rv.SetLayoutManager(new LinearLayoutManager(this));
            rv.SetAdapter(new ContentItemAdapter(db.Load().Exams.ToArray()));
        }
    }
}