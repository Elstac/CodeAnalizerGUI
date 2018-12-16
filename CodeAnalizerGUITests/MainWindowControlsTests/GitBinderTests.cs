using System;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Models;
using NUnit.Framework;
namespace CodeAnalizerGUITests
{
    [TestFixture]
    public class GitBinderTests
    {
        //private GitBinderViewModel viewModel;
        //private GitAuthorModel selected;
        //private TestMediator mediator;
        //[OneTimeSetUp]
        //public void LoadControl()
        //{
            
        //    selected = new GitAuthorModel("4", "4", 4);
        //    GitAuthorModel[] arr = new GitAuthorModel[]
        //    {
        //        new GitAuthorModel("1","1",1),
        //        new GitAuthorModel("2","2",2),
        //        new GitAuthorModel("3","3",3),
        //        selected
        //    };
        //    viewModel = new GitBinderViewModel();
        //    viewModel.Authors = new System.Collections.ObjectModel.ObservableCollection<GitAuthorModel>(arr);
        //}
        //[SetUp]
        //public void MediatorSetUp()
        //{
        //    mediator = new TestMediator();
        //    viewModel.Mediator = mediator;
        //}
        //[Test]
        //public void PassSelectedTest()
        //{
        //    viewModel.SelectedAuthor = selected;
        //    viewModel.Select();
        //    Assert.AreEqual(3, mediator.recivedData);
        //}
        //[Test]
        //public void NotSelectedSendTest()
        //{
        //    viewModel.SelectedAuthor = null;
        //    Assert.Throws(typeof(NullReferenceException), new TestDelegate(viewModel.Select));
        //}

        //[Test]
        //public void CloseTest()
        //{
        //    viewModel.Close();
        //    Assert.AreEqual(null, mediator.recivedData);
        //}
    }
}
