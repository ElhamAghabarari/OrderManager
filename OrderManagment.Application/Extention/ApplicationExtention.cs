using Microsoft.Extensions.DependencyInjection;
using OrderManagment.Application.Interface;
using OrderManagment.Application.Service;
using OrderManagment.Application.Service.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Extention
{
    public static class ApplicationExtention
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();

            services.AddHostedService<ConsumerService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationExtention)));
        }
    }
}
