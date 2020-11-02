using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Interviu.Controllers
{
    public class FileController : Controller
    {
        private String filePath =  "C:/Users/crist/Desktop/Interviu/Log.txt";
        

        public void ErrorLogging( String message)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();
                writer.WriteLine("Message : " + message);
                
            }
        }
    }
}
