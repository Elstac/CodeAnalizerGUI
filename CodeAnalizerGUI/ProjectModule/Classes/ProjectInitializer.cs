using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.ProjectModule;
using CodeAnalizerGUI.Interfaces;
using System.IO;

namespace CodeAnalizerGUI.Classes
{
    public class ProjectInitializer : IProjectInitializer
    {
        private ILogicHolder logicHolder;
        private INewProjectConfigurationCreator confCreator;
        private IVMMediator mediator;

        public ProjectInitializer(ILogicHolder logicHolder, INewProjectConfigurationCreator confCreator,IVMMediator mediator)
        {
            this.logicHolder = logicHolder;
            this.confCreator = confCreator;
            this.mediator = mediator;
        }

        public void Initialize(string name, string description, string directory)
        {
            if(directory==null)
                throw new NullReferenceException("Directory cannot be null");
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException("Given directory doesnt exists");
            if (name == null || name == "")
                throw new NullReferenceException("Given name is invalid");

            var config = confCreator.CreateConfiguration(name, description, directory);

            Directory.CreateDirectory(directory + "\\Resources");

            logicHolder.ResetHolder();

            mediator.NotifyColleagues(MVVMMessage.ProjectCreated, config);
        }
    }
}
