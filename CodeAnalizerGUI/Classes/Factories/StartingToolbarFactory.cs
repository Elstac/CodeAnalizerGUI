﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using System.Windows.Input;
using Autofac;
namespace CodeAnalizerGUI.Classes
{
    class StartingToolbarFactory : ButtonsListFactory
    {
        public IControlsMediator Mediator { get; set; }
        public StartingToolbarFactory()
        {
            names = new string[] { "New Project", "Open Project" };
            commands = new ICommand[] { new SimpleCommand(NewProject), new SimpleCommand(OpenProject) };
        }
        private void NewProject()
        {
            var buttons = DIContainer.Container.Resolve<IButtonsListFactory>(new NamedParameter("listType", ListType.pCreation)).GenerateButtons();
            var view = Mediator.CreateControl(typeof(ButtonPanelView), Mediator, new object[] { buttons });
            Mediator.LoadMainControl(view);
        }

        private void OpenProject()
        {
            throw new NotImplementedException();
        }
    }
}