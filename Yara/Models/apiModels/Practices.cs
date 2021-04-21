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
    public class Practices
    {
        public int PracticeID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string FileName { set; get; }
        public string Links { set; get; }
        public string StartDate { set; get; }
        public string StartTime { set; get; }
        public string FinishDate { set; get; }
        public string FinishTime { set; get; }
        public double Score { set; get; }
        public double ScoreBase { set; get; }
        public bool IsFileAnswer { set; get; }
        public bool IsActive { set; get; }
        public int OrderNo { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public Answer RegedAnswer { set; get; }
        public bool InRegAnswerScope { set; get; }
    }
}

/*
        "PracticeID": 4479,
        "Title": "تمرین فصل های 15، 10و 11",
        "Description": "",
        "FileName": "lecturer_100_50_1606549891637.pdf",
        "Links": "[]",
        "StartDate": "13990915",
        "StartTime": "0800",
        "FinishDate": "13991010",
        "FinishTime": "2355",
        "Score": 20,
        "ScoreBase": 20,
        "IsFileAnswer": true,
        "IsActive": true,
        "OrderNo": 4479,
        "RegDate": "13990908",
        "RegTime": "112121",
        "RegedAnswer": null,
        "InRegAnswerScope": false
*/