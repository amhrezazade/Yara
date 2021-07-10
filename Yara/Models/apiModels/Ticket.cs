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
    public class Ticket
    {
        public int TicketID { set; get; }
        public int SenderMemberType { set; get; }
        public int SenderMemberID { set; get; }
        public int ReceiverMemberType { set; get; }
        public int ReceiverMemberID { set; get; }
        public string Message { set; get; }
        public string FileName { set; get; }
        public string RegDate { set; get; }
        public string RegTime { set; get; }
        public string SeenDate { set; get; }
        public string SeenTime { set; get; }
    }
}

