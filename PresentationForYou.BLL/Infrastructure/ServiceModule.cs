using Ninject.Modules;
using PresentationForYou.DAL.Interfaces;
using PresentationForYou.DAL.Repositories;

namespace PresentationForYou.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}