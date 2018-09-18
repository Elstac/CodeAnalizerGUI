using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.Exceptions
{
    public class NoFileSelectedException:Exception
    {
        public NoFileSelectedException(string msg):base(msg)
        {

        }
    }
}
