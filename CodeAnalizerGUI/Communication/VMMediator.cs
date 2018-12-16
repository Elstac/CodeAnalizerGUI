using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI
{
    public enum MVVMMessage
    {
        OpenNewControl,
        OpenNewRootControl,
        CloseControl,
        NewContributorCreated,
        AuthorSelected,
        FileChosed,
        ImageChosed,
        ProjectCreated
    }

    public sealed class VMMediator:IVMMediator
    {
        private MultiDictionary<MVVMMessage,Action<object>> messageList= new MultiDictionary<MVVMMessage, Action<object>>();

        private static IVMMediator instance =new VMMediator();
        public static IVMMediator Instance
        {
            get => instance;
        }
        static VMMediator()
        {
            
        }

        public void Register(MVVMMessage msg, Action<object>callback)
        {
            messageList.AddValue(msg, callback);
        }

        public void NotifyColleagues(MVVMMessage msg,object args)
        {
            if(messageList.ContainsKey(msg))
                foreach (var callback in messageList[msg])
                    callback(args);
        }
    }
}
