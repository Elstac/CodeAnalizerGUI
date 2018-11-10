using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CodeAnalizerGUI.DataSavingModule;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;

namespace CodeAnalizerGUI.Classes
{
    public static class DIContainer
    {
        private static IContainer container;

        public static IContainer Container { get => container;}

        public static void InitializeContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Assembly assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().AsSelf();

            builder.RegisterGeneric(typeof(XmlDataSaver<>)).As(typeof(ISaveBehavior<>));
            builder.RegisterGeneric(typeof(XmlDataLoader<>)).As(typeof(ILoadBehavior<>));

            builder.Register(c => new DataManager() { ContributorLoader = c.Resolve<ILoadBehavior<ContributorModel[]>>(),
                                                      ContributorSaver = c.Resolve<ISaveBehavior<ContributorModel[]>>()});

            container = builder.Build();
           
        }

    }
}
