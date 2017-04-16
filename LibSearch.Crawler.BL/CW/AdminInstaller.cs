using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LibSearch.Crawler.BL.Interfaces.Manager;
using LibSearch.Crawler.BL.Interfaces.Repository;
using LibSearch.Crawler.BL.Interfaces.Service;
using LibSearch.Crawler.BL.Manager;
using LibSearch.Crawler.BL.Services;

namespace LibSearch.Crawler.BL.CW
{
    public class AdminInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRepository>().ImplementedBy<Repository.Repository>().LifestyleTransient());

            container.Register(
                Component.For<IInostrankabooksService>().ImplementedBy<InostrankabooksService>().LifestyleTransient());


            container.Register(
                Component.For<IInostrankabooksManager>().ImplementedBy<InostrankabooksManager>().LifestyleTransient());

        }
    }
}
