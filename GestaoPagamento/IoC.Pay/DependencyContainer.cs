using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pay.API;

namespace IoC.Pay
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
