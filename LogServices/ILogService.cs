using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    /// <summary>
    /// Log Service Interface
    /// </summary>
   public  interface ILogService
    {
        void Log(FileSystemEventArgs e);
       
        void Log(RenamedEventArgs e);


    }
}
