using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatcherServices
{
    /// <summary>
    /// Watcher Service Interface
    /// </summary>
    public interface IWatcherService
    {
        void Start();

        void Stop();

    }
}
