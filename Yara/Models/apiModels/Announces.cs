using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yara.Models.apiModels
{
    public class Announces
    {
        public int AnnounceID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string FileName { set; get; }
        public string Links { set; get; }
        public int OrderNo { set; get; }
        public bool IsActive { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public string SeenInfo { set; get; }

    }
}
