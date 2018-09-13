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
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Classes.MinorClasses;
using CodeAnalizerGUI.Interfaces;
using System.IO;
using CodeAnalizerGUI.UserControls.MainWindowControls;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for ContributorsControl.xaml
    /// </summary>
    public partial class ContributorsControl : UserControl,IFamilyMember,ISubControlDataReciver
    {
        private IFamilyMember treeParent;
        private IControlsMediator mediator;
        private Button AddButton;
        private int buttonCounter = 0;
        public IFamilyMember TreeParent { set => treeParent = value; }
        internal IControlsMediator Mediator { set => mediator = value; }

        public ContributorsControl()
        {
            InitializeComponent();
            LoadAddButton();
            MainPanel.Children.Add(AddButton);
        }

        private void LoadAddButton()
        {
            AddButton = new Button();
            Image plus = StringToImageConverter.Convert(Directory.GetCurrentDirectory() + "\\plus.png");
            plus.Stretch = Stretch.Fill;
            AddButton.Width = 64;
            AddButton.Height = 64;
            AddButton.Content = plus;
            AddButton.Click += new RoutedEventHandler(AddButtonClick);
            AddButton.Margin = new Thickness(10, 10, 10, 0);
        }

        public void AddNewButton(string name,Image image)
        {
            UIElementCollection children = MainPanel.Children;
            ButtonWithDescription newButton = new ButtonWithDescription(image, name, new RoutedEventHandler(ContributoButtonClick));
            newButton.Tag = buttonCounter++;
            newButton.Margin = new Thickness(10, 10, 10, 0);
            children.RemoveAt(children.Count - 1);
            children.Add(newButton);
            children.Add(AddButton);
        }

        private void ContributoButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ContributorDetailsControl cdc = new ContributorDetailsControl();
            
            int index = int.Parse(button.Tag.ToString());

            cdc.Contributor = UIBus.mainBus.ContributorManager.Contributors[index];
            Image tmpImg = (Image)button.Content;
            cdc.ContributorImage = tmpImg.Source;
            cdc.LoadContent();

            mediator.LoadContent(cdc);

        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            NewContributorControl ncc = new NewContributorControl();
            ncc.TreeParent = this;
            ncc.Mediator = mediator;
            mediator.LoadContent(ncc,this);            
        }

        public void AddContributor(string name, string pathToImage, string[] files)
        {
            UIBus.mainBus.AddContributor(name, files);
        }

        public void GetParent<T>(ref T ret) where T : class
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

        public void ReciveData(object dataClass)
        {
            ContributorDisplay contributorDisplay = dataClass as ContributorDisplay;

            Image img = StringToImageConverter.Convert(contributorDisplay.pathToImage);
            AddNewButton(contributorDisplay.name, img);
        }
    }
}
