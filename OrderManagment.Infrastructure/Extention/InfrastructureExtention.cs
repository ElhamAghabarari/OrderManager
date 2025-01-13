using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagment.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Infrastructure.Extention
{
    public static class InfrastructureExtention
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<OrderDbContext>(options =>
                            options.UseNpgsql(configuration.GetConnectionString("LocalhostConnection")));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
