using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UPT.Services;

namespace UPTWebAPI
{
    public class InvoicesJob : IJob
    {
        private IInvoicesService _invoicesService;
        public Task Execute(IJobExecutionContext context)
        {
            _invoicesService = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IInvoicesService)) as IInvoicesService;
            _invoicesService.InsertInvoices();

            return Task.CompletedTask;
        }
    }
}