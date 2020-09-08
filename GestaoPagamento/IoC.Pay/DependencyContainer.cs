using AutoMapper;
using Domain.Pay.Services.CommandHandlers;
using Domain.Pay.Services.CommandHandlers.Interfaces;
using Domain.Pay.Services.QueryHandler;
using Domain.Pay.Services.QueryHandler.Interfaces;
using Integration.Pay.Interfaces;
using Integration.Pay.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Pay;
using Repository.Pay.Data;
using Repository.Pay.UnitOfWork;
using System;

namespace IoC.Pay
{
    public static class DependencyContainer
    {
        public static void RegisterDbContextSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(options =>
                    options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }

        public static void RegisterDbContextInMemory(this IServiceCollection services)
        {
            services.AddDbContext<PaymentDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<IPaymentDbContext, PaymentDbContext>(ServiceLifetime.Scoped);
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICriarPaymentHandler, CriarPaymentHandler>();
            services.AddScoped<IListarPaymentsHandler, ListarPaymentsHandler>();

            services.AddScoped<IWebHook, WebHook>();
            services.AddScoped<IPayAtOperatorService, PayAtOperatorService>();
        }
    }
}
