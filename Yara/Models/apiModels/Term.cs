﻿using Android.App;
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
    public class TermItem
    {
        public int Term { set; get; }
        public List<Lesson> Lessons { set; get; }
    }
}