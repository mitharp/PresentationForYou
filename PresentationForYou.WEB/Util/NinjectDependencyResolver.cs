using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.BLL.Services;
using PresentationForYou.BLL.DTO;

namespace PresentationForYou.WEB.Util
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
            kernel.Bind<IService<UserDTO>>().To<UserService>();
        }
    }
}
