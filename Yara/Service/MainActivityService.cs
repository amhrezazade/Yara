using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yara.Activity;
using Yara.Adapters;
using Yara.Models;
using Yara.Models.ViewModels;

namespace Yara.Service
{
    public class MainActivityService
    {
        private appData _data;


        public MainActivityService()
        {
            _data = db.Load();
        }



        public ContentItemAdapter GetTestAdapter()
        {      
            List<ContentItem> ContentList = new List<ContentItem>();
            return new ContentItemAdapter(ContentList.ToArray());
        }


    }
}