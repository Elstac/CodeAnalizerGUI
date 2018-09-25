using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using System.Reflection;
namespace CodeAnalizerGUI.Classes
{
    public class ControlFactory : IControlFactory 
    {
        public static ControlFactory Factory { get; private set; }
        private Dictionary<Type, Type> dic;

        public ControlFactory()
        {
            dic = new Dictionary<Type, Type>();
            Factory = this;
        }
        
        public UserControl Create(Type viewType, IControlsMediator mediator, object[] properties)
        {
            UserControl ret = Create(viewType, mediator);
            object tmp = ret.DataContext;
            InjectProperties(ref tmp, properties);

            return ret;
        }

        private bool InjectProperties(ref object obj, object[] properties)
        {
            bool found = false;
            PropertyInfo[] prop = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                found = false;
                foreach (var item in prop)
                {
                    if(property.GetType().IsSubclassOf(item.PropertyType)||property.GetType().Equals( item.PropertyType))
                    {
                        found = true;
                        item.SetValue(obj, property);
                    }
                }
                if (!found)
                    throw new InvalidOperationException("Given property doesnt match");
            }
            return true;
        }

        public void RegisterViewType(Type viewType, Type viewModelType)
        {
            if (viewType.BaseType != typeof(UserControl))
                throw new InvalidOperationException("Cannot add type of non-view-class");
            if (viewModelType.BaseType != typeof(ViewModel))
                throw new InvalidOperationException("Cannot add type of non-viewModel-class");
            if (dic.ContainsKey(viewType))
                throw new InvalidOperationException("Given view type has related viewModel type");

            dic.Add(viewType, viewModelType);
        }

        public UserControl Create(Type viewType, IControlsMediator mediator)
        {
            if (viewType.BaseType != typeof(UserControl))
                throw new InvalidOperationException("Cannot create instance of non-view-class object");
            if (!dic.ContainsKey(viewType))
                throw new InvalidOperationException("Given view type has no related viewModel type");

            UserControl view = (UserControl)Activator.CreateInstance(viewType);
            object viewModel = (ViewModel)Activator.CreateInstance(dic[viewType]);
            (viewModel as ViewModel).View = view;
            (viewModel as ViewModel).Mediator = mediator;
            view.DataContext = viewModel;

            return view;
        }
    }
}
