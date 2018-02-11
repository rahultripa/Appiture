using System;
using System.Reflection;
using Autofac;
using TinyMvvm.Autofac;
using TinyMvvm.IoC;
using TinyNavigationHelper;
using Xamarin.Forms;
using Appitecture.Core.Requests;

namespace Appitecture {
    
    public static class Bootstrapper {
        public static void Initialize() {
            var builder = new ContainerBuilder();

            var asm = typeof(App).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(asm).Where(x => x.Name.EndsWith("View", StringComparison.Ordinal));

            var coreAssembly = Assembly.Load("Appitecture.Core");

            builder.RegisterAssemblyTypes(coreAssembly).Where(x => x.Name.EndsWith("ViewModel", StringComparison.Ordinal));

            var navigationHelper = new TinyNavigationHelper.Forms.FormsNavigationHelper(Application.Current);
            navigationHelper.RegisterViewsInAssembly(asm);
            builder.RegisterInstance<INavigationHelper>(navigationHelper);
             builder.RegisterType<GetLoginRequests>();
         
             builder.RegisterType<GetAssistantRequest>();
            builder.RegisterType<GetAssistantsRequest>();
            builder.RegisterType<GetBookAssistantsRequest>();
            builder.RegisterType<GetHistoryAssistantsRequest>();
             var container = builder.Build();
            var resolver = new AutofacResolver(container);
            Resolver.SetResolver(resolver);

            TinyMvvm.Forms.TinyMvvm.Initialize();
       //    navigationHelper.SetRootView("AssistantMapView");
         navigationHelper.SetRootView("LoginView");
        }
    }
}
