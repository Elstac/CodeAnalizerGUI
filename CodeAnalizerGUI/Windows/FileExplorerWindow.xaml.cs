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
using System.Windows.Shapes;
using System.IO;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for FileExplorerWindow.xaml
    /// </summary>
    public partial class FileExplorerWindow : Window ,IUIWindow
    {
        bool newSequence = true;
        string retPath = null;
        private UIBus mainBus;
        public FileExplorerWindow(UIBus bus, Window owner)
        {
            InitializeComponent();
            LoadTree();
            mainBus = bus;
            Owner = owner;
        }

        private void LoadTree()
        {
            foreach (var name in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = name;
                item.Tag = name;
                item.Expanded += new RoutedEventHandler(FolderExpanded);
                item.GotFocus += new RoutedEventHandler(FolderFocused);
                item.Items.Add(new TreeViewItem());
                fileTree.Items.Add(item);
            }
            
        }

        void FolderExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count != 1)
                return;
            item.Items.Clear();
            
            foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
            {
                TreeViewItem subitem = new TreeViewItem();
                subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                subitem.Tag = s;
                subitem.Expanded += new RoutedEventHandler(FolderExpanded);
                subitem.GotFocus += new RoutedEventHandler(FolderFocused);

                subitem.Items.Add(new TreeViewItem());
                item.Items.Add(subitem);
            }
        }

        void FolderFocused(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;

            if (!newSequence)
            {
                if (item.Parent is TreeView)
                {
                    newSequence = true;
                    return;
                }
                if (retPath.Contains(item.Tag.ToString()))
                    return;
            }
            retPath = item.Tag.ToString();
            newSequence = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            
            Owner.Focus();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (retPath == null)
                return;
            mainBus.FileExplorerResult(retPath);
        }

        public void SetBus(UIBus bus)
        {
            this.mainBus = bus;
        }
    }
}
