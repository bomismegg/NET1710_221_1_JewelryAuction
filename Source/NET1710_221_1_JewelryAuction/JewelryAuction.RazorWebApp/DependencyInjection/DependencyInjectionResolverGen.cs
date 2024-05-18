using JewelryAuction.Business.Services;
using JewelryAuction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.RazorWebApp.DependencyInjection
{
    public static class DependencyInjectionResolverGen
    {
        public static void InitializerDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<DbContext, NET1710_221_1_JewelryAuctionContext>();

            services.AddScoped<IAuctionRequestService, AuctionRequestService>();

            services.AddScoped<IAuctionRequestDetailService, AuctionRequestDetailService>();

            services.AddScoped<IAuctionResultService, AuctionResultService>();

            services.AddScoped<IAuctionSessionService, AuctionSessionService>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
        }
    }
}
