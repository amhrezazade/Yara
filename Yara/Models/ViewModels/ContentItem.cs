﻿using Android.App;
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
using Yara.Helper;
using Yara.Models.apiModels;
using Yara.Service;

namespace Yara.Models.ViewModels
{
    public class ContentItem
    {
        public string Titel { set; get; }
        public string Caption { set; get; }
        public string date { set; get; }
        public string GreenNote { set; get; }
        public string RedNote { set; get; }
        public string Def { set; get; }
        public string LinkTitel { set; get; }
        public string Link { set; get; }
        public ImageType Image { set; get; }


        public ContentItem(Practices p)
        {
            Titel = p.Title;
            Caption = p.Description;
            date = DateTimeHelper.GetDateString(p.RegDate, p.RegTime);
            GreenNote = DateTimeHelper.GetDateString(p.StartDate, p.StartTime);
            RedNote = DateTimeHelper.GetDateString(p.FinishDate, p.FinishTime);
            Def = "نمره " + p.Score + " از " + p.ScoreBase;
            if (p.FileName == string.Empty)
                Link = "";
            else
                Link = StaticData.DownloadpracticesURL + p.FileName;
            Image = ImageType.Note;
            LinkTitel = "فایل پیوست";
            ClearNull();
        }

        public ContentItem(NotificationItem p)
        {
            Titel = p.Titel;
            Caption = p.Caption;
            date = string.Empty;
            GreenNote = string.Empty;
            RedNote = string.Empty;
            Def = string.Empty;
            Link = string.Empty;
            LinkTitel = string.Empty;
            Image = ImageType.Subject;
            ClearNull();
        }

        public ContentItem(Student s)
        {
            Titel = s.FirstName + " " + s.LastName;
            Caption = s.StudentCode;
            date = string.Empty;
            GreenNote = "Id:";
            RedNote = s.StudentID.ToString();
            Def = string.Empty;
            Link = string.Empty;
            LinkTitel = string.Empty;
            Image = ImageType.Profile;
            ClearNull();
        }

        public ContentItem(Announces a)
        {
            Titel = a.Title;
            Caption = a.Description;
            date = DateTimeHelper.GetDateString(a.RegDate,a.RegTime);
            if (a.SeenInfo == null)
            {
                GreenNote = string.Empty;
                RedNote = "جدید";
            }
            else 
            {
                GreenNote = "دیده شده در ";
                var inf = JsonConvert.DeserializeObject<SeenInformation>(a.SeenInfo);
                RedNote = DateTimeHelper.GetDateString(inf.VisitDate, inf.VisitTime);
            }
            Def = a.AnnounceID.ToString();
            if (a.FileName == string.Empty)
                Link = "";
            else
                Link = StaticData.DownloadannouncesURL + a.FileName;
            LinkTitel = "فایل پیوست";
            Image = ImageType.Motif;
            ClearNull();
        }

        public ContentItem(Resources a)
        {
            Titel = a.Title;
            Caption = a.Description;
            date = DateTimeHelper.GetDateString(a.RegDate, a.RegTime);
            GreenNote = string.Empty;
            RedNote = string.Empty;
            Def = a.ResourceID.ToString();
            if (a.FileName == string.Empty)
                Link = "";
            else
                Link = StaticData.DownloadannouncesURL + a.FileName;
            LinkTitel = "فایل پیوست";
            Image = ImageType.Cloud;
            ClearNull();
        }


        public ContentItem()
        {
            Titel = string.Empty;
            Caption = string.Empty;
            date = string.Empty;
            GreenNote = string.Empty;
            RedNote = string.Empty;
            Def = string.Empty;
            Link = string.Empty;
            LinkTitel = string.Empty;
            Image = ImageType.None;
        }

        private void ClearNull()
        {
            if (Titel == null) Titel = "";
            if (Caption == null) Caption = "";
            if (date == null) date = "";
            if (GreenNote == null) GreenNote = "";
            if (RedNote == null) RedNote = "";
            if (Def == null) Def = "";
            if (Link == null) Link = "";
            if (LinkTitel == null) LinkTitel = "";
        }

        public string getShareText() =>
            Titel + "\r\n\r\n" + Caption + "\r\n" + Link;
    }
}