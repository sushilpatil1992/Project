using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using FinalProject.Data.Interfaces;
using FinalProject.Data.Repository;
using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Mvc;

namespace FinalProject.Ioc.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            //container.LoadConfiguration();
            // TODO: Register your types here
            container.RegisterType<IProductService,ProductService>();           
            container.RegisterType<IProductRepository, ProductDalRepository>();
            container.RegisterType<ICategoryRepository, CategoryDalRepository>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICustomerRepository, CustomerDalRepository>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IOrderRepository, OrderDalRepository>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderDetailsRepository, OrderDetailsDalRepository>();
            container.RegisterType<IOrderDetailsService, OrderDetailsService>();
            container.RegisterType<IPaymentRepository, PaymentDalRepository>();
            container.RegisterType<IPaymentService, PaymentService>();
            container.RegisterType(typeof(UserManager<>),
            new InjectionConstructor(typeof(IUserStore<>)));
            container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType<IdentityUser, ApplicationUser>(new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, ApplicationDbContext>(new ContainerControlledLifetimeManager());
       }
    }
}
