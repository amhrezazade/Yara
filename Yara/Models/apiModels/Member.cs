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
    public class Member
    {
        public int MemberID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string ImageFileName { set; get; }
        public int UnseenMessagesCount { set; get; }
        public string UserType { set; get; }
        public string RegDateTime { set; get; }

    }
}

/*
  [
    {
        "MemberID": 100,
        "FirstName": "qwe",
        "LastName": "asd",
        "ImageFileName": "",
        "UnseenMessagesCount": 0,
        "UserType": "lecturer",
        "RegDateTime": "13991008-145643"
    }
]
 */