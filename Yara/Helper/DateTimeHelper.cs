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

namespace Yara.Helper
{
    public enum DayType
    {
        yesterday,
        today,
        tomorrow,
        nexttomorrow,
        none
    }

    public class Date
    {
        public int y { set; get; }
        public int m { set; get; }
        public int d { set; get; }

        public Date(int Y, int M, int D)
        {
            y = Y;
            m = M;
            d = D;
        }

        public Date(string date)
        {
            string t = "";
            t += date[0].ToString()  + date[1].ToString() + date[2].ToString() + date[3].ToString();
            y = int.Parse(t);

            t = "";
            t += date[4].ToString() + date[5].ToString();
            m = int.Parse(t);

            t = "";
            t += date[6].ToString() + date[7].ToString();
            d = int.Parse(t);
        }

        public Date(DateTime date)
        {
            y = date.Year;
            m = date.Month;
            d = date.Day;
        }

        public override string ToString()
        {
            string output = y.ToString();
            if (m < 10)
                output += "0" + m.ToString();
            else
                output += m.ToString();
            if (d < 10)
                output += "0" + d.ToString();
            else
                output += d.ToString();
            return output;
        }

        public string ToString(char del)
        {
            return y.ToString() + del + m.ToString() + del + d.ToString();
        }

        public DateTime ToDateTime()
        {
            return DateTime.Parse(ToString());
        }
    }




    public class Time
    {
        public int h { set; get; }
        public int m { set; get; }

        public Time(string date)
        {

            string t = "";
            t += date[0].ToString() + date[1].ToString();
            h = int.Parse(t);

            t = "";
            t += date[2].ToString() + date[3].ToString();
            m = int.Parse(t);
        }

        public Time(DateTime date)
        {
            m = date.Minute;
            h = date.Hour;
        }

        public override string ToString()
        {
            string output = "";
            if (h < 10)
                output += "0" + h.ToString();
            else
                output += h.ToString();
            if (m < 10)
                output += "0" + m.ToString();
            else
                output += m.ToString();
            return output;
        }

        public string ToString(char del, bool Reverse = false)
        {
            if(Reverse)
                return m.ToString() + " " + del + " " + h.ToString();
            return h.ToString() + " " +  del + " " + m.ToString();
        }

    }
    public static class DateTimeHelper
    {

        public static string num(int n)
        {
            switch (n)
            {
                case 0:
                    return "صفر";
                case 1:
                    return "یک";
                case 2:
                    return "دو";
                case 3:
                    return "سه";
                case 4:
                    return "چهار";
                case 5:
                    return "پنج";
                case 6:
                    return "شش";
                case 7:
                    return "هفت";
                case 8:
                    return "هشت";
                case 9:
                    return "نه";
                case 10:
                    return "ده";
            }

            return n.ToString();
        }
        private static string DateEx(string stringdate,string time)
        {
            DateTime date = CommonExtensions.ConvertJalaliToMiladi(new Date(stringdate).ToString('-'));
            DateTime now = DateTime.Now;
            TimeSpan res = date - now;

            int dd = res.Days;
            int dm = res.Days / 30;

            string x;
            if (dm != 0)
            {       
                if (dm < 0)
                {
                    dm = -dm;
                    x = " ماه قبل ";
                }
                else
                {
                    x = " ماه بعد ";
                }

                return num(dm) + x;
            }

            if (dd == -1)
                return "دیروز";
            else if (dd == 0)
            {
                Time t = new Time(time);

                int h = t.h - now.Hour;
                int m = t.m - now.Minute;

                if (h < 0)
                {
                    h = -h;
                    return num(h) + " ساعت قبل ";
                }

                if (h > 0)
                    return num(h) + " ساعت بعد ";

                if (m < 0)
                {
                    m = -m;
                    return num(m) + " دقیقه قبل ";
                }

                if (m > 0)
                    return num(h) + " دقیقه بعد ";

                return "چند لحظه پیش";
            }    
            else if (dd == 1)
                return "فردا";
                
            if (dd < 0)
            {
                dd = -dd;
                x = " روز قبل ";
            }
            else
            {
                x = " روز بعد ";
            }

            return num(dd) + x;



        }

        public static DayType GetDayType(string stringdate)
        {
            DateTime date = CommonExtensions.ConvertJalaliToMiladi(new Date(stringdate).ToString('-'));
            DateTime now = DateTime.Now;
            TimeSpan res = date - now;

            int dd = res.Days;

            if (dd == -1)
                return DayType.yesterday;
            else if (dd == 0)
                return DayType.today;
            else if (dd == 1)
                return DayType.tomorrow;
            else if (dd == 2)
                return DayType.nexttomorrow;

            return DayType.none;

        }


        public static string GetDateString(string date, string time)
        {
            if (time == null || time == "")
                time = "0000";

            if (time == null || time == "")
                time = "14000101";

            //string output = " ⏰ " +  new Date(date).ToString('/') + " ( " + DateEx(date,time) + " )\r\n 📆 " + new Time(time).ToString(':', true);
            string output = " 📆 " + new Date(date).ToString('/') + " ( " + DateEx(date,time) + " )  ⏰  " + new Time(time).ToString(':', true);
            return CommonExtensions.ToPersianNumber(output);
        }

        public static string GetDateString()
        {
            var now = DateTime.Now;

            string date = CommonExtensions.ConvertMiladiToJalali(now).ToString();
            string time = new Time(now).ToString();

            string output = new Date(date).ToString('/') + " ( " + DateEx(date, time) + " )  ,  " + new Time(time).ToString(':', true);
            return CommonExtensions.ToPersianNumber(output);
        }

        public static string GetDateString(DateTime t)
        {
            var now = t;

            string date = CommonExtensions.ConvertMiladiToJalali(now).ToString();
            string time = new Time(now).ToString();

            string output = new Date(date).ToString('/') + " ( " + DateEx(date, time) + " )  ,  " + new Time(time).ToString(':', true);
            return CommonExtensions.ToPersianNumber(output);
        }

        public static string GetDateStringEx()
        {
            var now = DateTime.Now;

            string date = CommonExtensions.ConvertMiladiToJalali(now).ToString();
            string time = new Time(now).ToString();

            string output = new Date(date).ToString('/') + "  ,  " + new Time(time).ToString(':');
            return CommonExtensions.ToPersianNumber(output);
        }

    }
}