using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using CodeAnalizerGUI.Classes;
namespace CodeAnalizerGUITests.ClassesTests
{
    [TestFixture]
    class FileCollectorTests
    {
        private FileCollector imCol;
        private string resPath ="D:\\Tests\\";
        private string testFile = "D:\\t.txt";
        [OneTimeSetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(resPath);
            imCol = new FileCollector(resPath);
        }
        [Test]
        public void MoveFileTest()
        {
            File.Create(testFile).Close();
            imCol.MoveToResources(testFile);
            Assert.IsTrue(File.Exists(resPath + "t.txt")&&File.Exists(testFile));
        }
        [Test]
        public void MoveIncorrectFile()
        {
            Func<string,string> toTest = imCol.MoveToResources;
            Assert.Throws<FileNotFoundException>(()=>toTest("D:\\Dupa.dupa"));
        }
        [Test]
        public void MoveFileWithExistingName()
        {
            string path = "D:\\XD.txt";
            File.Create(resPath + "XD.txt").Close();
            File.Create(path).Close();

            imCol.MoveToResources(path);

            Assert.IsTrue(File.Exists(path) && File.Exists(resPath + "XD(1).txt"));
        }
        [Test]
        public void ReturnPathToMovedFileTest()
        {
            string path = resPath + "t.txt";
            if (File.Exists(path))
                File.Delete(path);

            Assert.AreEqual( imCol.MoveToResources(testFile), path);
        }

        [OneTimeTearDown]
        public void ClearFiles()
        {
            File.Delete("D:\\XD.txt");
            File.Delete(testFile);
            Directory.Delete(resPath, true);
        }
    }
}
