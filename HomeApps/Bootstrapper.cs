using System.Web.Mvc;
using HomeApps.Controllers;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace HomeApps
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            container.RegisterType<IHelloer, HelloerA>();
            container.RegisterType<IController, AdminController>("Helloer");

            return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}