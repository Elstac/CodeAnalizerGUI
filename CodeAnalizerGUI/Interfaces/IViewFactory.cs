using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI
{
    public interface IViewFactory
    {
        UserControl CreateView(Type type);
    }
}
