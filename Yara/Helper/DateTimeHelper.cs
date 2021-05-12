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

    public class Date
    {
        public int y { set; get; }
        public int m { set; get; }
        public int d { set; get; }

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

        public string ToString(char del)
        {
            return h.ToString() + del + m.ToString();
        }

    }
    public static class DateTimeHelper
    {

        private static string num(int n)
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
        private static string DateEx(string stringdate)
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
                return "امروز";
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


        public static string GetDateString(string date, string time)
        {
            string output =  new Date(date).ToString('/') + " ( " + DateEx(date) + " )  ,  " + new Time(time).ToString(':');
            return CommonExtensions.ToPersianNumber(output);
        }
    }
}