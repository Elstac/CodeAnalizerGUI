using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUIs
{
    class FamContentControl : ContentControl, IFamilyMember
    {
        public FamContentControl():base()
        {

        }
        public void GetParent<T>(ref T ret) where T : class
        {
            if (Parent is T)
            {
                ret = Parent as T;
                return;
            }
            IFamilyMember par = Parent as IFamilyMember;
            par.GetParent<T>(ref ret);
        }

        public void GetChildren<T>(ref T ret) where T : class
        {
            throw new InvalidOperationException("Operation not suported");
        }
    }
}
