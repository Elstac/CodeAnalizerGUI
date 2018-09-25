using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CodeAnalizerGUI.Exceptions
{
    class DependencyMadnessException:Exception
    {
        public DependencyMadnessException(object target)
        {
            string message = target.ToString()+" has too many dependecies";
            throw new DependencyMadnessException(message);
        }

        private DependencyMadnessException(string msg):base(msg)
        {

        }
    }
}
