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
using System.ComponentModel;
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Interfaces;
using System.IO;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for NewContributorControl.xaml
    /// </summary>
    public partial class NewContributorControl : UserControl, IFamilyMember,IFileExplorerUser
    {
        private string contributorName = "name";
        private string lastName = "lastname";
        private string pathToImage;
        private List<string> files = new List<string>() {};
        private IFamilyMember treeParent;
        public NewContributorControl(IFamilyMember par)
        {
            InitializeComponent();
            ContributorImage.Source = StringToImageConverter.Convert(Directory.GetCurrentDirectory() + "\\plus.png").Source;
            FileList.TreeParent = this;
            Control tmp;
            treeParent = par;
           

            foreach (var item in IdPanel.Children)
            {
                if (!(item is Control))
                    continue;
                tmp = item as Control;
                tmp.DataContext = this;
            }
        }

        public string ContributorName { get => contributorName; set => contributorName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public List<string> Files { get => files; }
        public string PathToImage { get => pathToImage; set => pathToImage = value; }

        private void ChoseImageButtonClick(object sender, RoutedEventArgs e)
        {
            Window point = null;
            GetParent(ref point);
            FileExplorerWindow win = new FileExplorerWindow(this, point,new string[] {".jpg", ".png", ".bmp"});
            win.Show();
            point.Hide();
        }
        
        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            if (PathToImage == null)
                PathToImage = Directory.GetCurrentDirectory() + "\\nofile.png";

            string[] files = FileList.Files.ToArray();
            ContributorsControl parent = treeParent as ContributorsControl;
            parent.AddContributor(contributorName+" "+LastName,PathToImage,files);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            throw new InvalidOperationException();
        }

        public void GetParent<T>(ref T ret)where T:class
        {
            if (treeParent is T)
            {
                ret = treeParent as T;
                return;
            }
            treeParent.GetParent(ref ret);
        }

        public void GetChildren<T>(ref T ret) where T : class
        {
            throw new InvalidOperationException("Operation not suported");
        }

        public void GetFileExplorerResults(string retPath)
        {
            PathToImage = retPath;
            ContributorImage.Source = StringToImageConverter.Convert(retPath).Source;
        }
    }
}
