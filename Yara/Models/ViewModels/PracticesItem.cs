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
        public PracticesItem()
        { }
        public PracticesItem(Practices p)
        {
            PracticeID = p.PracticeID;
            if (p.Title == null) Title = ""; else Title = p.Title;
            if (p.Description == null) Description = ""; else Description = p.Description;
            if (p.FileName == null) FileName = ""; else FileName = p.FileName;
            if (p.StartDate == null) StartDate = ""; else StartDate = p.StartDate;
            if (p.StartTime == null) StartTime = ""; else StartTime = p.StartTime;
            if (p.FinishDate == null) FinishDate = ""; else FinishDate = p.FinishDate;
            if (p.FinishTime == null) FinishTime = ""; else FinishTime = p.FinishTime;
            Score = p.Score;
            ScoreBase = p.ScoreBase;
            IsFileAnswer = p.IsFileAnswer;
            if (p.RegDate == null) RegDate = ""; else RegDate = p.RegDate;
            if (p.RegTime == null) RegTime = ""; else RegTime = p.RegTime;
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
        public double Score { set; get; }
        public double ScoreBase { set; get; }
        public bool IsFileAnswer { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public Answer RegedAnswer { set; get; }
        public bool InRegAnswerScope { set; get; }
    }
}