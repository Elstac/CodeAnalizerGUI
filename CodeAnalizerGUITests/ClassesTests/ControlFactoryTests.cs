using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Views;
using CodeAnalizerGUI.Abstractions;
using NUnit.Framework;
using System.Windows.Controls;
using System.Reflection;
namespace CodeAnalizerGUITests.ClassesTests
{
    [TestFixture]
    class ControlFactoryTests
    {
        class TestClass
        {
            public string classDep { get; set; }
            public IControlFactory interaceDep { get; set; }
            public ControlsMediator subClassDep { get; set; }
            public GenericInterface<int> genericInterfaceDep{ get; set; }
        }
        interface GenericInterface<T>
        {

        }
        class GenericImplementation: TestClass,GenericInterface<List<string>>, GenericInterface<int>
        {

        }
        private ControlFactory fac;

        [SetUp]
        public void SetUpFactory()
        {
            fac = new ControlFactory();
        }

        [Test]
        public void RegisterNotView()
        {
                Action<Type, Type> toTest = fac.RegisterViewType;

                Assert.Throws<InvalidOperationException>(() => toTest(typeof(int), typeof(ViewModel)));
        }
        [Test]
        public void RegisterNotViewModel()
        {
            Action<Type,Type>toTest= fac.RegisterViewType;

            Assert.Throws<InvalidOperationException>(() => toTest(typeof(GitBinderControl), typeof(int)));
        }
        

        [Test]
        public void InjectClassTest()
        {
            TestClass ss = new TestClass();
            ss.classDep = null;
            Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject obj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(fac);
            obj.Invoke("InjectProperties", ss, new object[] { "dd" });

            Assert.AreEqual("dd", ss.classDep);
        }

        [Test]
        public void InjectInterfaceTest()
        {
            TestClass ss = new TestClass();
            ControlFactory expected = new ControlFactory();

            Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject obj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(fac);
            obj.Invoke("InjectProperties", ss, new object[] { expected });

            Assert.AreEqual(expected, ss.interaceDep);
        }

        [Test]
        public void InjectSubClass()
        {
            TestClass ss = new TestClass();
            MainWindowControlsMediator expected = new MainWindowControlsMediator(null);
            Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject obj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(fac);
            obj.Invoke("InjectProperties", ss, new object[] { expected });

            Assert.AreEqual(expected, ss.subClassDep);
        }
        [Test]
        public void InjectGenericInterface()
        {
            TestClass ss = new TestClass();
            GenericImplementation expected = new GenericImplementation();
            Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject obj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(fac);
            obj.Invoke("InjectProperties", ss, new object[] { expected });

            Assert.AreEqual(expected, ss.genericInterfaceDep);
        }
    }
}
