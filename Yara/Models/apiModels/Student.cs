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
    public class Student
    {
        public int StudentID { set; get; }
        public string StudentCode { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string ImageFileName { set; get; }
    }
}