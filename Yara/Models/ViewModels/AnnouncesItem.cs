using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yara.Models.apiModels;

namespace Yara.Models.ViewModels
{
    public class AnnouncesItem
    {

        public AnnouncesItem(Announces a)
        {
            AnnounceID = a.AnnounceID;
            Title = a.Title;
            Description = a.Description;
            FileUrl = a.FileName;
            RegDate = a.RegDate;
            SeenInfo = JsonConvert.DeserializeObject<SeenInformation>(a.SeenInfo);
        }

        public int AnnounceID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string FileUrl { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public SeenInformation SeenInfo { set; get; }
    }
}