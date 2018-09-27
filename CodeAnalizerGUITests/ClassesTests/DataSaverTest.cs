using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using NUnit.Framework;
using Moq;
namespace CodeAnalizerGUITests.ClassesTests
{
    [TestFixture]
    class DataSaverTest
    {
        private IDataSaver saver;
        private Mock<IDataSaver> globalSaverMock;
        [SetUp]
        public void Initialize()
        {
            globalSaverMock = new Mock<IDataSaver>();
            saver = new DataSaver(globalSaverMock.Object);
        }
        [Test]
        public void SaveModelsList()
        {

            Model[] expected = new ContributorModel[]
            {
                new ContributorModel(),
                new ContributorModel(),
                new ContributorModel()
            };

            foreach (var item in expected)
            {
                saver.AddModel(item);
            }
            Model[] output = saver.GetModel();
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void LoadEmptySaverList()
        {
            Model[] expected = new Model[] { };
            Model[] output = saver.GetModel();
            Assert.AreEqual(expected, output);
            
        }
        [Test]
        public void SaveDataInGlobalSaver()
        {
            Model[] expected = new ContributorModel[]
            {
                new ContributorModel(),
                new ContributorModel(),
                new ContributorModel()
            };

            foreach (var item in expected)
            {
                saver.AddModel(item);
            }

            saver.SaveData();
            globalSaverMock.Verify(x => x.AddModel(It.IsAny<Model>()), Times.Exactly(3));
        }

        [Test]
        public void TrySaveNoModelsTest()
        {
            saver.SaveData();
            globalSaverMock.Verify(x => x.AddModel(It.IsAny<Model>()), Times.Exactly(0));
        }
    }
}
