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
    /// Interaction logic for GlobalStatsControl.xaml
    /// </summary>
    public partial class GlobalStatsControl : UserControl
    {
        public GlobalStatsControl(List<string> globalStats)
        {
            InitializeComponent();
            LoadPanel(globalStats);
        }

        private void LoadPanel(List<string> stats)
        {
            TextBlock block;

            foreach (var item in stats)
            {
                block = new TextBlock();
                block.Text = item;
                block.Tag = item.Substring(0, item.IndexOf(":") - 1);
                block.Margin = new Thickness(0, 10, 0, 10);
                block.FontSize = 14;
                block.TextWrapping = TextWrapping.WrapWithOverflow;
                MainPanel.Children.Add(block);

            }
        }
    }
}
