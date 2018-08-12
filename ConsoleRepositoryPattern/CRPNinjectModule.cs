using CRP.Domain.Infrastructure;
using CRP.Storage;
using Ninject.Modules;

namespace ConsoleRepositoryPattern
{
    public class CRPNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<CRPDbContext>().ToSelf().InSingletonScope();
            Bind<IRepository>().To<Repository>().InSingletonScope();

            //Bind<IRepository>().To<Repository>().InSingletonScope().WithConstructorArgument("context", new OCMDbContext());
            //Bind<IRepository>().To<Repository>().InSingletonScope().WithConstructorArgument("context", new OCMDbContext());
        }
    }
}
