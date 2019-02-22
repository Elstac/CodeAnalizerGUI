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
            
            builder.RegisterGeneric(typeof(XmlDataSaver<>)).As(typeof(ISaveBehavior<>));
            builder.RegisterGeneric(typeof(XmlDataLoader<>)).As(typeof(ILoadBehavior<>));
            
            builder.Register<IButtonsListFactory>((c, p) =>
            {
                var type = p.Named<ListType>("listType");

                switch (type)
                {
                    case ListType.start:
                        return container.Resolve<OpenedProjecToolbarFactory>();
                    case ListType.pCreation:
                        return container.Resolve<ProjectCreationButtonsFactory>();
                    case ListType.pOpend:
                        return container.Resolve<OpenedProjecToolbarFactory>();
                    case ListType.navigation:
                        return container.Resolve<NavigationButtonsGenerator>();
                    default:
                        return container.Resolve<StartingToolbarFactory>();
                }
            });

            builder.RegisterType<VMMediator>().As<IVMMediator>().SingleInstance();
            builder.RegisterType<LogicHolder>().As<ILogicHolder>().SingleInstance();
            builder.Register<IFileCollector>(c => { return new FileCollector(Properties.Settings.Default.ProjectPath+"\\Resources\\"); });

            builder.Register<Func<NewContributorViewModel>>(c => { return () => {
                return container.Resolve<NewContributorViewModel>(new NamedParameter("fileList"
                                                                    ,container.Resolve<IManageableFileList>(
                                                                        new NamedParameter("allowedFormats",new string[] {".cs",".xaml.cs",".xaml" }))));
            };
            } );

            builder.Register<Func<ContributorModel, ContributorDetailsViewModel>>(c =>
            {
                return (ContributorModel cm) =>
                {
                     return container.Resolve<ContributorDetailsViewModel>(
                     new NamedParameter("generator", container.Resolve<GeneralStatisticsGenerator>(
                         new NamedParameter("miner",container.Resolve<ILogicHolder>().GetFileMiner(
                             cm.PathsToFiles.ToArray(),false)))),
                     new NamedParameter("contributor", cm));
                };
            });
            
            container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }
}
