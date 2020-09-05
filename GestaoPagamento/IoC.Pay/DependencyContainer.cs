using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Pay.Data;
using System.Reflection;

namespace IoC.Pay
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<PaymentDbContext>(options =>
                    options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<IPaymentDbContext, PaymentDbContext>(ServiceLifetime.Scoped);
        }
    }
}
