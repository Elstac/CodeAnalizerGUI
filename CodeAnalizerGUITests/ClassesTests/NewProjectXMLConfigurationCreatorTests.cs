using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using CodeAnalizerGUI.ProjectModule;
using System.IO;
namespace CodeAnalizerGUITests.ClassesTests
{
    [TestFixture]
    class NewProjectXMLConfigurationCreatorTests
    {
        private NewProjectXMLConfigurationCreator creator;

        [Test]
        public void ReturnValidConfigurationAfterActOfCreation()
        {
            string name = "name";
            string des = "des";

            var expected = new ProjectConfig() { Name = name, Description = des, Files = null };
            var output =creator.CreateConfiguration(name, des, "CreatorTest");

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void CreateFileInExistingDirectory()
        {
            string name = "name", des = "des", dir = "D:\\CreatorTest";
            var expected = new ProjectConfig() { Name = name, Description = des, Files = null };
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);

            Directory.CreateDirectory(dir);
            
            creator.CreateConfiguration(name, des, dir);
            Assert.IsTrue(File.Exists(dir+"\\Configuration.xml"));
        }
        [Test]
        public void CreateFileInNewDirectory()
        {
            string name = "name", des = "des", dir = "D:\\CreatorTest";
            var expected = new ProjectConfig() { Name = name, Description = des, Files = null };
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);
            
            creator.CreateConfiguration(name, des, dir);
            Assert.IsTrue(File.Exists(dir + "\\Configuration.xml"));
        }
        
    }
}
