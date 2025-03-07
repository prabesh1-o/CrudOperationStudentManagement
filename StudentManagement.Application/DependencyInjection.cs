using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // For MediatR 12+ as previous ones are discontinued
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            // For AutoMapper (recent version that accepts Assembly)
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
