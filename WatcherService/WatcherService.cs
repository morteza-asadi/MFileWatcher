using LogServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatcherServices
{
    /// <summary>
    /// Watcher Service
    /// </summary>
    public class WatcherService : IWatcherService,IDisposable
    {

        private FileSystemWatcher _fileWatcher;

        private ILogService _Logger;

        private string _path;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="path">Destination Path</param>
        /// <param name="Log">LogService</param>
        /// <param name="includeSubFolder">Include SubFolder</param>
        public WatcherService(string path,ILogService Log ,bool includeSubFolder = true )
        {
            this._Logger = Log; 

            this._path = path;

            this._fileWatcher = new FileSystemWatcher(path);

            this._fileWatcher.Created += _fileWatcher_Created;

            this._fileWatcher.Changed += _fileWatcher_Changed;

            this._fileWatcher.Renamed += _fileWatcher_Renamed;

            this._fileWatcher.Deleted += _fileWatcher_Deleted;

            this._fileWatcher.IncludeSubdirectories = includeSubFolder;
        }

        void _fileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            _Logger.Log(e);
        }

        void _fileWatcher_Renamed(object sender, RenamedEventArgs e)
        {

            _Logger.Log(e);

        }

        void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            _Logger.Log(e);
        }

        void _fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            _Logger.Log(e);

        }

        /// <summary>
        /// Start Watcher
        /// </summary>
        public void Start()
        {
            _fileWatcher.EnableRaisingEvents = true;
        }
        
        /// <summary>
        /// Stop Watcher
        /// </summary>
        public void Stop()
        {
            _fileWatcher.EnableRaisingEvents = false;
        }

       
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }


}
