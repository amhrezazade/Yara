using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Yara.Models;
using Yara.Models.apiModels;
using Yara.Models.ViewModels;

namespace Yara.Service
{
    public static class Api
    {
        public static async Task<ApiResult<string>> Login(LoginModel m)
        {
            string rout = "/api/auth";
            string body = JsonConvert.SerializeObject(m);
            var res = await Server.Post(rout, body);
            return new ApiResult<string>(res.Res, res.ok, res.Res);
        }

        private static async Task<ApiResult<ResType>> GetObject<ResType>(string Rout)
        {
            var res = await Server.Get(Rout);

            if (res.ok)
                try
                {
                    return new ApiResult<ResType>(JsonConvert.DeserializeObject<ResType>(res.Res));
                }
                catch
                {
                    try
                    {
                        JObject json = JObject.Parse(res.Res);
                        string error = json["Error"].ToString();
                        return new ApiResult<ResType>(false, error);
                    }
                    catch
                    {
                        return new ApiResult<ResType>(false, res.Res);
                    }
                }

            return new ApiResult<ResType>(res.ok, res.Res);
        }

        public static async void SeenAnnounce(int AnnouncesId) =>
             await Server.Put("/api/announces/seen/" + AnnouncesId.ToString());

        public static async Task<ApiResult<Student>> GetStudetData(string UserToken = null) =>
            await GetObject<Student>("/api/students");

        public static async Task<ApiResult<TermItem[]>> GetTermList() =>
            await GetObject<TermItem[]>("/api/lessons/student");

        public static async Task<ApiResult<ActiveTermId>> GetActiveTermId() =>
            await GetObject<ActiveTermId>("/api/lessons/activeTerm");

        public static async Task<ApiResult<Announces[]>> GetAnnounces(int LessonId) =>
            await GetObject<Announces[]>("/api/announces/actives/" + LessonId.ToString());

        public static async Task<ApiResult<Resources[]>> GetResources(int LessonId) =>
            await GetObject<Resources[]>("/api/resources/actives/" + LessonId.ToString());

        public static async Task<ApiResult<Practices[]>> GetPractices(int LessonId) =>
            await GetObject<Practices[]>("/api/practices/actives/" + LessonId.ToString());

        public static async Task<ApiResult<Exam[]>> GetExams(int LessonId) =>
            await GetObject<Exam[]>("/api/exams/actives/" + LessonId.ToString());

        public static async Task<ApiResult<LessonInfo>> GetLessonInfo(int LessonId) =>
            await GetObject<LessonInfo>("/api/lessons/groupInfo/" + LessonId.ToString());
    }
}
