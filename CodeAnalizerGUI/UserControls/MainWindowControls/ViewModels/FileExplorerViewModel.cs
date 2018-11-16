using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.UserControls.MainWindowControls;
using System.IO;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class FileExplorerViewModel:ViewModel
    {
        private bool newSequence = true;

        private object selectedFile;
        private string[] formats;
        private ObservableCollection<TreeViewItem> treeItems;
        

        public FileExplorerViewModel()
        {
            treeItems = new ObservableCollection<TreeViewItem>();
            LoadTree();
            if (treeItems.Count == 0)
                throw new InvalidOperationException("No drive has been loaded");
            selectedFile = treeItems[0];

            SelectCommand = new SimpleCommand(Select);
            ExitCommand = new SimpleCommand(Exit);
        }

        #region Properties
        public ICommand SelectCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public object SelectedFile { get => selectedFile.ToString(); set => selectedFile = value; }
        public string[] Formats { get => formats; set => formats = value; }
        public ObservableCollection<TreeViewItem> TreeItems { get => treeItems; set => treeItems = value; }
        #endregion

        private void LoadTree()
        {
            treeItems.Clear();
            foreach (var name in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = name;
                item.Tag = name;
                item.Expanded += new RoutedEventHandler(FolderExpanded);
                item.GotFocus += new RoutedEventHandler(FolderFocused);
                item.Items.Add(new TreeViewItem());
                treeItems.Add(item);
            }
        }

        private TreeViewItem CreateNode(string text, bool isDir)
        {
            TreeViewItem ret = new TreeViewItem();
            ret.Header = text.Substring(text.LastIndexOf("\\") + 1);
            ret.Tag = text;
            ret.GotFocus += new RoutedEventHandler(FolderFocused);
            if (isDir)
            {
                ret.Expanded += new RoutedEventHandler(FolderExpanded);
                ret.Items.Add(new TreeViewItem());
            }

            return ret;
        }

        private void Select()
        {
            mediator.SendData(selectedFile);
            mediator.CloseControl();
        }

        private void Exit()
        {
            mediator.BreakOperation();
            mediator.CloseControl();
        }

        void FolderExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count != 1)
                return;
            item.Items.Clear();

            foreach (string dir in Directory.GetDirectories(item.Tag.ToString()))
            {
                if (isHidden(dir))
                    continue;
                if (formats != null && !IsInFormat(dir))
                    continue;

                item.Items.Add(CreateNode(dir, true));
            }

            foreach (string file in Directory.GetFiles(item.Tag.ToString()))
            {
                if (isHidden(file))
                    continue;
                if (formats != null && !IsInFormat(file))
                    continue;

                item.Items.Add(CreateNode(file, false));
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
                if (selectedFile.ToString().Contains(item.Tag.ToString()))
                    return;
            }
            selectedFile = item.Tag.ToString();
            newSequence = false;
        }

        private bool isHidden(string path)
        {
            if (File.Exists(path))
                return new FileInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
            if (Directory.Exists(path))
                return new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
            throw new FileNotFoundException("File: " + path + " doesnt exist");
        }
        private bool IsInFormat(string path)
        {
            if (Directory.Exists(path))
                return true;
            foreach (var format in formats)
            {
                if (path.EndsWith(format))
                    return true;
            }
            return false;
        }
    }
}
