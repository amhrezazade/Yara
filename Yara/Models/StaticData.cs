

namespace Yara.Models
{
    public static class StaticData
    {
        public const string ServerProtocol = "https://";
        public const string ServerHost = "yaraapi.mazust.ac.ir";
        public const string BaseUrl = ServerProtocol + ServerHost;
        public const string DownloadpracticesURL = BaseUrl + "/static/practices/";
        public const string DownloadannouncesURL = BaseUrl + "/static/announces/";
        public const string DownloadresourcesURL = BaseUrl + "/static/resources/";
        public const string DownloadticketURL = BaseUrl + "/static/tickets/";
        
        public const string UserAgent = "Yara Notifier Android Application";
        public const string ProfileImageURL = "https://reg.mazust.ac.ir/CPanel/StudentsImages/";
    }
}