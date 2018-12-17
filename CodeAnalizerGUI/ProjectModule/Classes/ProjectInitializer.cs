using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.ProjectModule;
using CodeAnalizerGUI.Interfaces;

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
            throw new NotImplementedException();
        }
    }
}
