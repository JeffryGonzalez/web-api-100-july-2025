using FluentValidation;

namespace SoftwareCenter.Api.CatalogItems
{
    public class Models
    {
        public class CreateCatalogItemRequestValidator : AbstractValidator<CatalogItemCreateRequest>
        {
            public CreateCatalogItemRequestValidator()
            {
                RuleFor(v => v.Name).NotEmpty().MinimumLength(3).MaximumLength(255);
                RuleFor(v => v.Description).NotEmpty().MinimumLength(3).MaximumLength(255);
                RuleFor(v => v.Version).NotNull();
            }
        }

        public record CatalogItemCreateRequest
        {
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Version { get; set; } = string.Empty;

            public CatalogItemEntity MapToEntity(Guid vendorId)
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
            public CatalogItemDetails MapToResponse()
            {
                return new CatalogItemDetails
                {
                    Id = Id,
                    Description = Description,
                    Name = Name,
                    Version = Version,
                };
            }
        }

    }
}
