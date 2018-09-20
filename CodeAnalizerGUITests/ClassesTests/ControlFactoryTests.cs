using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using NUnit.Framework;
using System.Windows.Controls;
namespace CodeAnalizerGUITests.ClassesTests
{
    [TestFixture]
    class ControlFactoryTests
    {
        private ControlFactory fac;
        [Test]
        public void RegisterNotView()
        {
            Action<Type,Type>toTest= fac.RegisterViewType;

            Assert.Throws<InvalidOperationException>(() => toTest(typeof(int), typeof(ViewModel)));
        }
        [Test]
        public void RegisterNotViewModel()
        {
            Action<Type,Type>toTest= fac.RegisterViewType;

            Assert.Throws<InvalidOperationException>(() => toTest(typeof(GitBinderControl), typeof(int)));
        }
        
    }
}
