using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddAplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR((typeof(ServiceRegistiration).Assembly));
        }
    }
}
