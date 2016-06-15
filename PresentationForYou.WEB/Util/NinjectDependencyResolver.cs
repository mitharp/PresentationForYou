using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using BudgetApp.BLL.Interfaces;
using BudgetApp.BLL.Services;
using BudgetApp.BLL.DTO;

namespace BudgetApp.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IService<UserDTO>>().To<SourceService>();
            kernel.Bind<IService<TransactionDTO>>().To<TransactionService>();
        }
    }
}
