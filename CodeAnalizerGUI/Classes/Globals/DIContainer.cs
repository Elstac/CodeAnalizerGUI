using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CodeAnalizerGUI.DataSavingModule;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.ViewModels;
namespace CodeAnalizerGUI.Classes
{
    
    public static class DIContainer
    {
        private static IContainer container = null;

        public static IContainer Container { get => container;}

        public static void InitializeContainer()
        {
            if (container != null)
                return;

            ContainerBuilder builder = new ContainerBuilder();
            Assembly assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().AsSelf();

            builder.RegisterType<MainWindowControlsMediator>().As<IControlsMediator>();
            
            builder.RegisterGeneric(typeof(XmlDataSaver<>)).As(typeof(ISaveBehavior<>));
            builder.RegisterGeneric(typeof(XmlDataLoader<>)).As(typeof(ILoadBehavior<>));

            builder.Register(c => new DataManager() { ContributorLoader = c.Resolve<ILoadBehavior<ContributorModel[]>>(),
                                                      ContributorSaver = c.Resolve<ISaveBehavior<ContributorModel[]>>()});

            builder.Register(c => new FileCollector(Properties.Settings.Default.ProjectPath)).As<IFileCollector>();
            builder.Register<IButtonsListFactory>((c, p) =>
            {
                var type = p.Named<ListType>("listType");
               
                switch (type)
                {
                    case ListType.start:
                        return new StartingToolbarFactory();
                    case ListType.pCreation:
                        return new ProjectCreationButtonsFactory();
                    default:
                        return new StartingToolbarFactory();
                }
            });
            container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
          
    }
}
