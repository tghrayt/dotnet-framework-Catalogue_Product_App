using Catalogue_Produit_App.DAO;
using Catalogue_Produit_App.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Catalogue_Produit_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICategorieRepository, CategorieRepository>();
            container.RegisterType<ICategorieService, CategorieService>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}