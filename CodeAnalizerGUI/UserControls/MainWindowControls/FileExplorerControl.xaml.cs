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
using CodeAnalizer;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.Views
{
    /// <summary>
    /// Interaction logic for FileExplorerControl.xaml
    /// </summary>
    public partial class FileExplorerControl : UserControl
    {
        //private IControlsMediator mediator;
        //private bool newSequence = true;
        //private string[] formats;
        //private string retPath;
        //private UserControl treeParent;
        //internal IControlsMediator Mediator {set => mediator = value; }
        //public string[] Formats { get => formats;
        //    set
        //    {
        //        formats = value;
        //        LoadTree();
        //    }
        //}
        //public UserControl TreeParent { get => treeParent; set => treeParent = value; }

        public FileExplorerControl()
        {

            InitializeComponent();
        }

        //private void LoadTree()
        //{
        //    fileTree.Items.Clear();
        //    foreach (var name in Directory.GetLogicalDrives())
        //    {
        //        TreeViewItem item = new TreeViewItem();
        //        item.Header = name;
        //        item.Tag = name;
        //        item.Expanded += new RoutedEventHandler(FolderExpanded);
        //        item.GotFocus += new RoutedEventHandler(FolderFocused);
        //        item.Items.Add(new TreeViewItem());
        //        fileTree.Items.Add(item);

        //    }

        //}

        //private TreeViewItem CreateNode(string text, bool isDir)
        //{
        //    TreeViewItem ret = new TreeViewItem();
        //    ret.Header = text.Substring(text.LastIndexOf("\\") + 1);
        //    ret.Tag = text;
        //    ret.GotFocus += new RoutedEventHandler(FolderFocused);
        //    ret.MouseDoubleClick += new MouseButtonEventHandler(SelectButtonClick);
        //    if (isDir)
        //    {
        //        ret.Expanded += new RoutedEventHandler(FolderExpanded);
        //        ret.Items.Add(new TreeViewItem());
        //    }

        //    return ret;
        //}

        //#region HelpingMethods
        //private bool isHidden(string path)
        //{
        //    if (File.Exists(path))
        //        return new FileInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
        //    if (Directory.Exists(path))
        //        return new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
        //    throw new FileNotFoundException("File: " + path + " doesnt exist");
        //}
        //private bool IsInFormat(string path)
        //{
        //    if (Directory.Exists(path))
        //        return true;
        //    foreach (var format in formats)
        //    {
        //        if (path.EndsWith(format))
        //            return true;
        //    }
        //    return false;
        //}
        //#endregion

        //#region Events
        //void FolderExpanded(object sender, RoutedEventArgs e)
        //{
        //    TreeViewItem item = (TreeViewItem)sender;
        //    if (item.Items.Count != 1)
        //        return;
        //    item.Items.Clear();

        //    foreach (string dir in Directory.GetDirectories(item.Tag.ToString()))
        //    {
        //        if (isHidden(dir))
        //            continue;
        //        if (formats != null && !IsInFormat(dir))
        //            continue;

        //        item.Items.Add(CreateNode(dir, true));
        //    }

        //    foreach (string file in Directory.GetFiles(item.Tag.ToString()))
        //    {
        //        if (isHidden(file))
        //            continue;
        //        if (formats != null && !IsInFormat(file))
        //            continue;

        //        item.Items.Add(CreateNode(file, false));
        //    }
        //}

        //void FolderFocused(object sender, RoutedEventArgs e)
        //{
        //    TreeViewItem item = sender as TreeViewItem;

        //    if (!newSequence)
        //    {
        //        if (item.Parent is TreeView)
        //        {
        //            newSequence = true;
        //            return;
        //        }
        //        if (retPath.Contains(item.Tag.ToString()))
        //            return;
        //    }
        //    retPath = item.Tag.ToString();
        //    newSequence = false;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //}

        //private void SelectButtonClick(object sender, RoutedEventArgs e)
        //{
        //    mediator.SendData(retPath);
        //    mediator.LoadContent(treeParent);
        //}

        //#endregion
    }
}
