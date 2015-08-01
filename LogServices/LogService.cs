using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    /// <summary>
    /// Log Service 
    /// </summary>
    public class LogService : ILogService
    {
        private LogStrategy[] Strategy;

        private string _path;

        private const string _fileName = "LogActivity.txt";

        /// <summary>
        /// First Constructor
        /// </summary>
        /// <param name="st">Log Strategy</param>
        public LogService(params LogStrategy[] st)
        {
            this.Strategy = st;
        }

        /// <summary>
        /// Second Constructor
        /// </summary>
        /// <param name="path">Destination Path</param>
        /// <param name="st">Log Strategy</param>
        public LogService(string path, params LogStrategy[] st)
        {
            this.Strategy = st;

            this._path = path;
        }

        /// <summary>
        /// Log For FileSystemEventArgs
        /// </summary>
        /// <param name="e">FileSystemEventArgs</param>
        public void Log(FileSystemEventArgs e)
        {
            Show(e.ShowDetail());
        }

        /// <summary>
        /// Log For RenamedEventArgs
        /// </summary>
        /// <param name="e">RenamedEventArgs</param>
        public void Log(RenamedEventArgs e)
        {
            Show(e.ShowDetail());
        }


        /// <summary>
        /// Check Strategy
        /// </summary>
        /// <param name="data">Log Data</param>
        private void Show(string data)
        {
            foreach (var item in Strategy)
            {
                switch (item)
                {
                    case LogStrategy.Email:
                        break;
                    case LogStrategy.File: WriteToFile(data);
                        break;
                    case LogStrategy.Console: Console.WriteLine(data);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Write Data To LogActivity.txt
        /// </summary>
        /// <param name="data">Log Data</param>
        private void WriteToFile(string data)
        {
            string FullPath = _path + _fileName;

            if (File.Exists(FullPath))
            {
                using (StreamReader reader = new StreamReader(FullPath))
                {
                    data = reader.ReadToEnd() + data;
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(_path + _fileName))
            {
                file.WriteLine(data);
            }

        }
    }
}
