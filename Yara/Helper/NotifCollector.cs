using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Threading.Tasks;
using Yara.Service;
using System.Collections.Generic;
using Yara.Models;
using Yara.Models.apiModels;
using Yara.Models.ViewModels;
using System;
using Yara.Helper;


namespace Yara.Helper
{
    class NotifCollector
    {
        List<ContentItem> yesterday = new List<ContentItem>();
        List<ContentItem> today = new List<ContentItem>();
        List<ContentItem> tomorrow = new List<ContentItem>();
        List<ContentItem> nexttomorrow = new List<ContentItem>();

        public string LessonName = "";

        public int Count
        {
            get
            {
                return yesterday.Count + today.Count + tomorrow.Count + nexttomorrow.Count;
            }
        }

        public void Add(Announces a)
        {
            ContentItem item = new ContentItem(a, LessonName);
            switch (DateTimeHelper.GetDayType(a.RegDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
        }

        public void Add(Exam e)
        {
            ContentItem item = new ContentItem(e, LessonName);
            switch (DateTimeHelper.GetDayType(e.RegDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
            switch (DateTimeHelper.GetDayType(e.StartDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
            switch (DateTimeHelper.GetDayType(e.FinishDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
        }
        public void Add(Resources e)
        {
            ContentItem item = new ContentItem(e, LessonName);
            switch (DateTimeHelper.GetDayType(e.RegDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
        }

        public void Add(Practices e)
        {
            ContentItem item = new ContentItem(e, LessonName);
            switch (DateTimeHelper.GetDayType(e.RegDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
            switch (DateTimeHelper.GetDayType(e.StartDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
            switch (DateTimeHelper.GetDayType(e.FinishDate))
            {
                case DayType.yesterday:
                    yesterday.Add(item);
                    return;
                case DayType.today:
                    today.Add(item);
                    return;
                case DayType.tomorrow:
                    tomorrow.Add(item);
                    return;
                case DayType.nexttomorrow:
                    nexttomorrow.Add(item);
                    return;
            }
        }

        public void Add(ContentItem c)
        {
            today.Add(c);
        }

        public List<ContentItem> GetList()
        {
            List<ContentItem> list = new List<ContentItem>();

            if (yesterday.Count > 0)
            {
                list.Add(new ContentItem(new NotificationItem("دیروز", yesterday.Count.ToString() + " مورد ")));
                foreach (var x in yesterday)
                    list.Add(x);
            }
            
            if (today.Count > 0)
            {
                list.Add(new ContentItem(new NotificationItem("امروز", today.Count.ToString() + " مورد ")));
                foreach (var x in today)
                    list.Add(x);
            }

            if (tomorrow.Count > 0)
            {
                list.Add(new ContentItem(new NotificationItem("فردا", tomorrow.Count.ToString() + " مورد ")));
                foreach (var x in tomorrow)
                    list.Add(x);
            }

            if (nexttomorrow.Count > 0)
            {
                list.Add(new ContentItem(new NotificationItem("پسفردا", nexttomorrow.Count.ToString() + " مورد ")));
                foreach (var x in nexttomorrow)
                    list.Add(x);
            }
            
            if(list.Count == 0)
                list.Add(new ContentItem(new NotificationItem("موردی یافت نشد", "")));


            return list;
        }
    }
}