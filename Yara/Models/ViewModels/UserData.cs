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

namespace Yara.Models.ViewModels
{
    public class UserData
    {
        public int Id { set; get; } = 0;
        public string Name { set; get; } = "";
        public string StudentId { set; get; } = "";
        public string ImageUrl { set; get; } = "";
    }
}