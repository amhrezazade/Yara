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
        public AnnouncesItem()
        { }
        public AnnouncesItem(Announces a)
        {
            AnnounceID = a.AnnounceID;
            if (a.Title == null) Title = ""; else Title = a.Title;
            if (a.Description == null) Description = ""; else Description = a.Description;
            if (a.FileName == null) FileName = ""; else FileName = a.FileName;
            if (a.RegDate == null) RegDate = ""; else RegDate = a.RegDate;
            if (a.RegTime == null) RegTime = ""; else RegTime = a.RegTime;
            if (a.SeenInfo != null)
                SeenInfo = JsonConvert.DeserializeObject<SeenInformation>(a.SeenInfo);
            else
                SeenInfo = new SeenInformation();
        }

        public int AnnounceID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string FileName { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public SeenInformation SeenInfo { set; get; }
    }
}