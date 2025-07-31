using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;
using static SoftwareCenter.Api.CatalogItems.Models;
using static SoftwareCenter.Api.Vendors.Models;

namespace SoftwareCenter.Api.CatalogItems;

public static class Api
{
    public static IEndpointRouteBuilder MapCatalogItems(this IEndpointRouteBuilder app)
    {

        app.MapPost("/vendors/{id:guid}/items", async (
            Guid id, 
            CatalogItemCreateRequest request,
            [FromServices] IValidator<CatalogItemCreateRequest> validator,
            IDocumentSession session,
            ILookupVendors vendorLookups) =>
        {
            // validate the stuff - see the issue.
            // create the entity
            bool noSuchVendor = await vendorLookups.CheckIfVendorExistsAsync(id);
            if(noSuchVendor)
            {
                return Results.NotFound();
            }

            var validationResults = await validator.ValidateAsync(request);
            if (!validationResults.IsValid)
            {
                return Results.BadRequest();
            }

            // from CatalogItemCreateRequest -> CatalogItemEntity
            var entity = request.MapToEntity(id);
            // save it to the database (side effect)
            session.Store(entity);
            await session.SaveChangesAsync();
            // create a response 
            var response = entity.MapToResponse();

            return Results.Ok(response);
        });
        return app;
    }

    public static IServiceCollection AddCatalogItems(this IServiceCollection services)
    {
       
        //services.AddScoped
        return services;
    }
}

public interface ILookupVendors
{
    Task<bool> CheckIfVendorExistsAsync(Guid id);
}