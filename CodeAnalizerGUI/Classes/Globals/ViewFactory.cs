using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CodeAnalizerGUI
{
    class ViewFactory
    {
        private static ViewFactory instance;
        public static ViewFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new ViewFactory();

                return instance;
            }
        }

        private ViewFactory()
        {

        }

        public UserControl CreateView(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
