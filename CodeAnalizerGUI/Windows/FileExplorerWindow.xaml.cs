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
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for FileExplorerWindow.xaml
    /// </summary>
    public partial class FileExplorerWindow : Window
    {
        bool newSequence = true;
        string retPath = null;
        private IFileExplorerUser user;
        public FileExplorerWindow(IFileExplorerUser userClass, Window owner)
        {
            InitializeComponent();
            LoadTree();
            user = userClass;
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
            DirectoryInfo info;
            foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
            {
                if (isHidden(s))
                    continue;
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
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (retPath == null)
                return;
            user.GetFileExplorerResults(retPath);
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            Owner.Show();
            Owner.Focus();
            base.OnClosed(e);
        }
        private bool isHidden(string path)
        {
            if (File.Exists(path))
                return new FileInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
            if (Directory.Exists(path))
                return new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
            throw new FileNotFoundException("File: " + path + " doesnt exist");
        }
        
    }
}
