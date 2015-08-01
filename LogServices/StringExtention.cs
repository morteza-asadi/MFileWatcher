using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    /// <summary>
    /// String Extention
    /// </summary>
    public static class StringExtention
    {
        /// <summary>
        /// Convert EventArgs To String
        /// </summary>
        /// <param name="e">Renamed EventArgs</param>
        /// <returns>String</returns>
        public static string ShowDetail(this RenamedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("User Name : {2} Event : {0} DateTme : {1}", e.ChangeType, DateTime.Now, System.Security.Principal.WindowsIdentity.GetCurrent().Name));

            sb.AppendLine(string.Format("Name : {0}", e.Name));

            sb.AppendLine(string.Format("FullPath : {0}", e.FullPath));

            sb.AppendLine(string.Format("OldName : {0}", e.OldName));

            sb.AppendLine(string.Format("OldFullPath : {0}", e.OldFullPath));

            return sb.ToString();
        }

        /// <summary>
        /// Convert EventArgs To String
        /// </summary>
        /// <param name="e">FileSystem EventArgs</param>
        /// <returns>String</returns>
        public static string ShowDetail(this FileSystemEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("User Name : {2} Event : {0} DateTme : {1}", e.ChangeType, DateTime.Now, System.Security.Principal.WindowsIdentity.GetCurrent().Name));

            sb.AppendLine(string.Format("Event : {0} DateTme : {1}", e.ChangeType, DateTime.Now));

            sb.AppendLine(string.Format("Name : {0}", e.Name));

            sb.AppendLine(string.Format("FullPath : {0}", e.FullPath));

            return sb.ToString();
        }
    }
}
