﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI
{
    public interface IVMMediator
    {
        void Register(MVVMMessage msg, Action<object> callback);
        void NotifyColleagues(MVVMMessage msg, object args);
    }
}
