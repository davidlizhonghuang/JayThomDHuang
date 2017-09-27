using System.Web.Hosting;

namespace WebJayThomDhuang.LogProcess
{

    public static class LogProcess
        {
            public static void WriteLog(string inputparastr, string userid, string logMesg, ElogType logType)
            {
                var json = inputparastr;
                string logPath = "";
                string filePath = "";
                var s = HostingEnvironment.MapPath("/");
                var baseUrl = s + "/logs/";
                switch (logType.ToString())
                {
                    case "Request":
                        logPath = baseUrl + "Request";
                        filePath = string.Format("{0}/{1}.log", logPath, userid);
                        Utilities.WriteLog(logPath, filePath, logMesg);
                        Utilities.WriteLog(logPath, filePath, "request str = " + json);
                        break;
                    case "SysException":
                        logPath = baseUrl + "SysException";
                        filePath = string.Format("{0}/{1}.log", logPath, userid);
                        Utilities.WriteLog(logPath, filePath, logMesg);
                        break;
                    case "Response":
                        logPath = baseUrl + "Response";
                        filePath = string.Format("{0}/{1}.log", logPath, userid);
                        Utilities.WriteLog(logPath, filePath, logMesg);
                        break;
                    case "Output":
                        logPath = baseUrl + "Output";
                        filePath = string.Format("{0}/{1}.log", logPath, userid);
                        Utilities.WriteLog(logPath, filePath, logMesg);
                        break;
                    case "ClientCreate":
                        logPath = baseUrl + "ClientCreate";
                        filePath = string.Format("{0}/{1}.log", logPath, userid);
                        Utilities.WriteLog(logPath, filePath, logMesg);
                        break;

                 

                    default:
                        logPath = baseUrl + "others";
                        filePath = string.Format("{0}/{1}.log", logPath, userid);
                        Utilities.WriteLog(logPath, filePath, logMesg);
                        break;
                }
            }
        }
        public enum ElogType
        {
            Request,
            SysException,
            Response,
            Output,
            ClientCreate,
            others
        }
    
}