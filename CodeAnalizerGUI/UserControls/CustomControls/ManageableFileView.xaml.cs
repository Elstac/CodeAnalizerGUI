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
using CodeAnalizerGUI.Interfaces;
using System.ComponentModel;
using CodeAnalizerGUI.UserControls.MainWindowControls;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for ManageableFileView.xaml
    /// </summary>
    public partial class ManageableFileView : UserControl,ISubControlDataReciver
    {
        private List<string> files;
        IControlsMediator mediator;
        UserControl treeParent;
        public ManageableFileView()
        {
            files = new List<string>();
            InitializeComponent();
            FilesList.DataContext = this;
            FilesList.ItemsSource = files;
        }

        public void Resize()
        {
            Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Arrange(new Rect(0, 0, DesiredSize.Width, DesiredSize.Height));
            Button tmp;
            foreach (var button in MainGrid.Children)
            {
                if (button is Button)
                {
                    tmp = button as Button;
                    tmp.Width = ActualWidth / 2;
                }
            }
        }

        public UserControl TreeParent { get => treeParent; set => treeParent = value; }
        public List<string> Files { get => files;}
        public IControlsMediator Mediator { get => mediator; set => mediator = value; }

        private void RefreshFileList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(files);
            view.Refresh();
        }
        

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            FileExplorerControl fec = new FileExplorerControl();
            fec.Mediator = mediator;
            fec.TreeParent = treeParent;
            mediator.LoadContent(fec,this);
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (FilesList.SelectedItem == null)
                throw new NullReferenceException("No file has been selected");

            files.Remove( FilesList.SelectedItem.ToString());
            RefreshFileList();
        }

        public void ReciveData(object dataClass)
        {
            files.Add(dataClass.ToString());
            RefreshFileList();
        }
    }
}
