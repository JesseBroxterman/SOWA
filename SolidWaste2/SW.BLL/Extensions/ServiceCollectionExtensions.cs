﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW.BLL.Services;

namespace SW.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolidWasteServices(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddTransient<IBillBlobService, BillBlobService>()
            .AddTransient<IBillMasterService, BillMasterService>()
            .AddTransient<IContainerService, ContainerService>()
            .AddTransient<ICustomerService, CustomerService>()
            .AddTransient<IKanPayService, KanPayService>()
            .AddTransient<IPaymentPlanService, PaymentPlanService>()
            .AddTransient<IServiceAddressService, ServiceAddressService>()
            .AddTransient<ITransactionService, TransactionService>()

            .Configure<KanPaySettings>(configuration.GetSection("KanPay"));

}
