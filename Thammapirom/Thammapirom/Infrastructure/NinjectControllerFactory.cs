using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Thammapirom.Concrete;
using Thammapirom.Models;
using Thammapirom.Abstract;
using Moq;
using System.Collections.Generic;
namespace Thammapirom.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IWelcomeImageRepository>().To<EFWelcomeImageRepository>();
           ninjectKernel.Bind<IGalleryImageRepository>().To<EFGalleryImageRepository>();
           ninjectKernel.Bind<IBackgroundRepository>().To<EFBackgroundRepository>();
           ninjectKernel.Bind<IActivityClipRepository>().To<EFActivityClipRepository>();
           ninjectKernel.Bind<IDhammaQARepository>().To<EFDhammaQARepository>();
           ninjectKernel.Bind<IAnnualEventRepository>().To<EFAnnualEventRepository>();
           ninjectKernel.Bind<IOtherEventRepository>().To<EFOtherEventRepository>();
           ninjectKernel.Bind<IContactRepository>().To<EFContactRepository>();
        }
    }
}