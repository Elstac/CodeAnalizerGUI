using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CodeAnalizerGUI.Classes
{
    class ViewModelFactory
    {
        private static ViewModelFactory instance;
        public static ViewModelFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new ViewModelFactory();

                return instance;
            }
        }

        private ViewModelFactory()
        {

        }

        public T CreateViewModel<T>()
        {
           return DIContainer.Container.Resolve<T>();
        }
    }
}
