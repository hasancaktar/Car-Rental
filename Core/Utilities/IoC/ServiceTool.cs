using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{//ioc: injectionları kontrol ettiğimiz nokta demek


    public class ServiceTool
    {
        //webapi'de veya autofac'taoluşturduğumuz injectionları oluşturabilmemize yarıyor
        public static IServiceProvider ServiceProvider { get; private set; }
        //.netin servicecollection yani servislerini kullanarak bu servisleri build et.
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider=services.BuildServiceProvider();
            return services;
        }
    }
}
