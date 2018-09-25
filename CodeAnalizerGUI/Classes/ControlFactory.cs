using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;

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

        public UserControl Create(Type viewType, IControlsMediator mediator)
        {
            if (viewType.BaseType != typeof(UserControl))
                throw new InvalidOperationException("Cannot create instance of non-view-class object");
            if (!dic.ContainsKey(viewType))
                throw new InvalidOperationException("Given view type has no related viewModel type");

            UserControl view =(UserControl) Activator.CreateInstance(viewType);
            ViewModel viewModel = (ViewModel)Activator.CreateInstance(dic[viewType]);
            viewModel.Mediator = mediator;
            viewModel.View = view;
            view.DataContext = viewModel;

            return view;
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
        
    }
}
