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
    public class Answer
    {
        public int AnswerID { set; get; } = 0;
        public string FileName { set; get; } = string.Empty;
        public string StudentDescription { set; get; } = string.Empty;
        public string RegDate { set; get; } = string.Empty;
        public string RegTime { set; get; } = string.Empty;
        public int Score { set; get; } = 0;
        public string ScoreRegisterarDescription { set; get; } = string.Empty;
        public string ScoreRegDate { set; get; } = string.Empty;
        public string ScoreRegTime { set; get; } = string.Empty;
    }
}

/*
            "AnswerID": 30146,
            "FileName": "student_4563_23_1603139212925.txt",
            "StudentDescription": "",
            "RegDate": "13990728",
            "RegTime": "235443",
            "Score": 15,
            "ScoreRegisterarDescription": "",
            "ScoreRegDate": "13991028",
            "ScoreRegTime": "122406"
 */