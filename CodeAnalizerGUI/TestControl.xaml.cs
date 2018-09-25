using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for TestControl.xaml
    /// </summary>
    public partial class TestControl : UserControl
    {
        struct test
        {
            private string vName;
            private string vValue;
            public string VName { get => vName; set => vName = value; }
            public string VValue { get => vValue; set => vValue = value; }
        }
        public TestControl()
        {
            InitializeComponent();
            test t = new test();
            t.VName = "dupa";
            t.VValue = "chuj";
            lv.Items.Add(t);
            lv.Items.Add(t);
        }
    }
}
