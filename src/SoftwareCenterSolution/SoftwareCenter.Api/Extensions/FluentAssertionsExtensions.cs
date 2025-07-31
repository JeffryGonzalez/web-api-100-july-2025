using FluentValidation;
using SoftwareCenter.Api.CatalogItems;
using SoftwareCenter.Api.Vendors;

namespace SoftwareCenter.Api.Extensions
{
    public static class FluentAssertionsExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateVendorRequest>, CreateVendorRequestValidator>();
            services.AddScoped<IValidator<CreateVendorPointOfContactRequest>, CreateVendorPointOfContactRequestValidator>();
            services.AddScoped<IValidator<CatalogItemCreateRequest>, CreateCatalogItemCreateRequestValidator>();

            return services;
        }
    }
}
