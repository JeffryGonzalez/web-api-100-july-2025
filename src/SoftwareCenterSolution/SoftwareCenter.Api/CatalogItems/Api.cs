using FluentValidation;
using Marten;
using SoftwareCenter.Api.Vendors;

namespace SoftwareCenter.Api.CatalogItems;

public static class Api
{
    public static IEndpointRouteBuilder MapCatalogItems(this IEndpointRouteBuilder app)
    {

        app.MapPost("/vendors/{id:guid}/items", async (
            Guid id, 
            CatalogItemCreateRequest request, 
            IDocumentSession session,
            ILookupVendors vendorLookups,
            IValidator<CatalogItemCreateRequest> validator) =>
        {
            //Make sure it is valid, otherwise sending a 400
            var validationResults = await validator.ValidateAsync(request);
            if (!validationResults.IsValid)
            {
                {
                    var errors = validationResults.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                    return Results.ValidationProblem(errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage }));
                }

            }

            // validate the stuff - see the issue.
            // create the entity
            bool noSuchVendor = await vendorLookups.CheckIfVendorExistsAsync(id);
            if(noSuchVendor)
            {
                return Results.NotFound();
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

public record CatalogItemCreateRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public  CatalogItemEntity MapToEntity(Guid vendorId)
    {
        return new CatalogItemEntity
        {

            Id = Guid.NewGuid(),
            VendorId = vendorId,
            Created = DateTimeOffset.UtcNow,
            Description = Description,
            Name = Name,
            Version = Version,
        };
    }
}


public class CreateCatalogIemRequestValidator : AbstractValidator<CatalogItemCreateRequest>
{
    public CreateCatalogIemRequestValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters.")
            .MaximumLength(350).WithMessage("Description must not exceed 350 characters.");

        RuleFor(v => v.Version)
            .NotEmpty().WithMessage("Version is required.");

    }
}


public record CatalogItemDetails
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

  
}

public class CatalogItemEntity
{
    public Guid Id { get; set; }
    public Guid VendorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public DateTimeOffset Created { get; set; }
    public  CatalogItemDetails MapToResponse()
    {
        return new CatalogItemDetails
        {
            Id = Id,
            Description =Description,
            Name = Name,
            Version = Version,
        };
    }
}

public interface ILookupVendors
{
    Task<bool> CheckIfVendorExistsAsync(Guid id);
}