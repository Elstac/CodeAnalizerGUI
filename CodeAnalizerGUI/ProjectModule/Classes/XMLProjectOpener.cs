using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using CodeAnalizerGUI.DataSavingModule;

namespace CodeAnalizerGUI.ProjectModule
{
    class XMLProjectOpener : IProjectOpener
    {
        private IVMMediator mediator;
        private ILoadBehavior<ProjectConfig> fileLoader;

        public XMLProjectOpener(IVMMediator mediator, ILoadBehavior<ProjectConfig> fileLoader)
        {
            this.mediator = mediator;
            this.fileLoader = fileLoader;
        }

        public void OpenProject(string path)
        {
            var config = fileLoader.Load(path);

            Properties.Settings.Default.ProjectPath = config.Directory;

            mediator.NotifyColleagues(MVVMMessage.ProjectCreated, config);
        }
    }
}
