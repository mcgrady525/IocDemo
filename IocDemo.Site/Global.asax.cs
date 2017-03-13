using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IocDemo.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Autofac初始化
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //也可以不直接引用IocDemo.Dao.dll和IocDemo.Service.dll
            //var bufferDao = System.IO.File.ReadAllBytes(@"D:\sources.github\test\IocDemo\DLL\IocDemo.Dao.dll");
            //var bufferService = System.IO.File.ReadAllBytes(@"D:\sources.github\test\IocDemo\DLL\IocDemo.Service.dll");
            //Assembly daoAssembly = Assembly.Load(bufferDao);
            //Assembly serviceAssembly = Assembly.Load(bufferService);

            //这种方式需要直接引用Dao和Service，但是比较方便
            builder.RegisterAssemblyTypes(typeof(IocDemo.Service.TestService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IocDemo.Dao.TestDao).Assembly).Where(t => t.Name.EndsWith("Dao")).AsImplementedInterfaces();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
