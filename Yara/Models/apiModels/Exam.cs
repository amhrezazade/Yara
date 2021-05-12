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
    public class Exam
    {
        public int ExamID { set; get; }
        public string Title { set; get; }
        public int GroupID { set; get; }
        public string Description { set; get; }
        public string StartDate { set; get; }
        public string StartTime { set; get; }
        public string FinishDate { set; get; }
        public string FinishTime { set; get; }
        public int RegMemberID { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public bool IsFinalExam { set; get; }
        public bool NeedAuthentication { set; get; }
        public bool IsScoreVisible { set; get; }
        public bool IsActive { set; get; }
        public double TotalScore { set; get; }
        public int QuestionsCount { set; get; }
        public int AnsweredQuestionsCount { set; get; }
        public bool IsAuthenticated { set; get; }
        public bool InExamScope { set; get; }
        public bool InAuthProcessScope { set; get; }
        public double StudentScore { set; get; }
    }
}
