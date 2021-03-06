﻿using System.Web.Http.Controllers;
using LibSearch.BL.Manager;
using LibSearch.BL.Validator;
using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Intefaces.Validator;
using LibSearch.Core.Model;
using LibSearch.Data;
using LibSearch.Data.Repository;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace LibSearch.CW.Installers
{
    public class AdminInstallerApi : IWindsorInstaller
    {
        private const string WebAssemblyName = "LibSearch";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(WebAssemblyName)
                .BasedOn<IHttpController>()
                .LifestylePerWebRequest());

            //Repository
            container.Register(Component.For<DataContext>().LifestyleSingleton());
            container.Register(
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());

            //Validator
            container.Register(
                Component.For(typeof(IValidator<User>)).ImplementedBy(typeof(UserValidator)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IValidator<Book>)).ImplementedBy(typeof(BookValidator)).LifestyleTransient());

            //Managers
            container.Register(Component.For(typeof(IManager<>)).ImplementedBy(typeof(Manager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IUserManager<>)).ImplementedBy(typeof(UserManager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IBookManager<>)).ImplementedBy(typeof(BookManager<>)).LifestyleTransient());
        }
    }
}
