﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DaxStudio.UI.Model;

namespace DaxStudio.UI.Events
{
    public class ActivateTraceEvent
    {
        public ActivateTraceEvent(ITraceWatcher watcher)
        {
            Watcher = watcher;
        }
        ITraceWatcher Watcher { get; set; }
    }
}
