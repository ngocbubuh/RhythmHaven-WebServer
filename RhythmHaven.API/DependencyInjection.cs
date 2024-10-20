﻿using AspNetCoreRateLimit;
using RhythmHaven.API.Middlewares;
using RhythmHaven.Repository;
using RhythmHaven.Repository.Repositories.Interfaces;
using RhythmHaven.Service.Services;
using RhythmHaven.Service.Services.Interfaces;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace RhythmHaven.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IAuthenService, AuthenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITransactionService, TransactionService>();

            // add Middleware
            services.AddExceptionHandler<ExceptionHandlerMiddleware>();
            services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();
            services.AddProblemDetails();

            // add Brute Force setting
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            return services;
        }
    }
}
