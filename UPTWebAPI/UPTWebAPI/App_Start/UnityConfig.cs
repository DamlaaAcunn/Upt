using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using UPT.Services;
using System.Web.Mvc;
using Unity;

namespace UPTWebAPI.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new Microsoft.Practices.Unity.UnityContainer();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IInvoicesService, InvoicesService>();
            container.RegisterType<IPaymentService, PaymentService>();
            container.RegisterType<IDepositService, DepositService>();
            container.RegisterType<IUserService, UserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}