﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBoltAttribute;

namespace WinBoltAttribute
{
    public static class logger
    {
        public static void WriteLog(string message)
        {
           /* string logPath = ConfigurationManager.AppSettings["logPath"];

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {message}");
            }*/

        }
    }
}
