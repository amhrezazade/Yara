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
using Yara.Models.apiModels;

namespace Yara.Models.ViewModels
{
    public class PracticesItem
    {
        public PracticesItem(Practices p)
        {
            PracticeID = p.PracticeID;
            Title = p.Title;
            Description = p.Description;
            FileName = p.FileName;
            FinishDate = p.FinishDate;
            FinishDate = p.FinishDate;
            FinishTime = p.FinishTime;
            Score = p.Score;
            ScoreBase = p.ScoreBase;
            IsFileAnswer = p.IsFileAnswer;
            RegDate = p.RegDate;
            RegTime = p.RegTime;
            RegedAnswer = p.RegedAnswer;
            InRegAnswerScope = p.InRegAnswerScope;
        }


        public int PracticeID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string FileName { set; get; }
        public string StartDate { set; get; }
        public string StartTime { set; get; }
        public string FinishDate { set; get; }
        public string FinishTime { set; get; }
        public int Score { set; get; }
        public int ScoreBase { set; get; }
        public bool IsFileAnswer { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public Answer RegedAnswer { set; get; }
        public bool InRegAnswerScope { set; get; }
    }
}