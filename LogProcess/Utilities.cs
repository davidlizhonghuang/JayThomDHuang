using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebJayThomDhuang.LogProcess
{
   
        public static class Utilities
        {
            public static void WriteLog(string strDirectoryPath, string strLogFilePath, string value)
            {
                bool folderExists = Directory.Exists(strDirectoryPath);
                if (!folderExists)
                    Directory.CreateDirectory(strDirectoryPath);

                bool FileExist = true;
                if (!System.IO.File.Exists(strLogFilePath))
                {
                    FileExist = false;
                    System.IO.File.Create(strLogFilePath).Close();
                }
                using (StreamWriter w = System.IO.File.AppendText(strLogFilePath))
                {
                    if (FileExist)
                    {
                        w.WriteLine(Environment.NewLine);
                    }
                    w.WriteLine(DateTime.Now.ToString() + " ==> " + value);
                    w.Flush();
                    w.Close();
                }
            }

          
        }
    
}