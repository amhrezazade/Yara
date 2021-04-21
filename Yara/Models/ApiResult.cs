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

namespace Yara.Models
{

    public class ApiResult<TResult>
    {
        public bool OK { get; }
        public string Message { get; }
        public TResult data { get; }

        public ApiResult(bool ok = true, string message = "ok")
        {
            OK = ok;
            Message = message;
        }

        public ApiResult(TResult res,bool ok = true, string message = "ok")
        {
            OK = ok;
            Message = message;
            data = res;
        }
    }
}