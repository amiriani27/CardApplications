using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardApps.Common
{
    public class GameManger
    {
        private Thread _mainThread = null;
        public Thread MainThread { get { return _mainThread; } set { _mainThread = value; } }


    }
}
