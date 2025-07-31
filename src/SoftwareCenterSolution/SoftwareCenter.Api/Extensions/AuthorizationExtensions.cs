using Microsoft.AspNetCore.Authorization;

namespace SoftwareCenter.Api.Extensions
{
    public static class AuthorizationExtensions
    {
        public static AuthorizationBuilder AddSoftwareCenterAuthPolicies(this AuthorizationBuilder builder)
        {
            return builder.AddPolicy("CanAddVendor", pol =>
            {
                pol.RequireRole("Manager");
                pol.RequireRole("SoftwareCenter");
            })
            .AddPolicy("CanUpdateVendorPointofContact", pol =>
            {
                pol.RequireRole("Manager");
            });
        }
    }
}
