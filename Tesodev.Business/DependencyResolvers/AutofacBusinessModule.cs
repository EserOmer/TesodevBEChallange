using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Business.Abstract;
using Tesodev.Business.Concrete;
using Tesodev.Core.Utilities.Interceptors;
using Tesodev.DataAccess.Abstract;
using Tesodev.DataAccess.Concrete;

namespace Tesodev.Business.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<OrderDal>().As<IOrderDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<CustomerDal>().As<ICustomerDal>();

            builder.RegisterType<ProductDal>().As<IProductDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
