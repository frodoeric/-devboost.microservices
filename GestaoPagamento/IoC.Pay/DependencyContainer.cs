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
using System.Reflection;

namespace IoC.Pay
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<PaymentDbContext>(options =>
                    options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

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
