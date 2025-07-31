using FluentValidation;

namespace SoftwareCenter.Api.Vendors
{
    public class Models
    {

        #region Requests
        public record CreateVendorRequest
        {

            public string Name { get; init; } = string.Empty;
            public string Url { get; init; } = string.Empty;
            public CreateVendorPointOfContactRequest PointOfContact { get; set; } = new();
            //public VendorItemEntity MapToEntity(Guid vendorId)
            //{
            //    return new VendorItemEntity
            //    {
            //        Name = Name,
            //        Url = Url,
            //        PointOfContact = PointOfContact,
            //        Id = Guid.NewGuid(),
            //    };
            //}

        }

        public record CreateVendorPointOfContactRequest
        {
            public string Name { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
        };
        #endregion

        #region Responses
        public record CreateVendorResponse(
            Guid Id,
            string AddedBy,
            string Name, string Url, CreateVendorPointOfContactRequest PointOfContact
            );
        #endregion

        #region Validators
        public class CreateVendorPointOfContactRequestValidator :
            AbstractValidator<CreateVendorPointOfContactRequest>
        {
            public CreateVendorPointOfContactRequestValidator()
            {
                RuleFor(p => p.Name).NotEmpty();

            }
        }
        public class CreateVendorRequestValidator : AbstractValidator<CreateVendorRequest>
        {
            public CreateVendorRequestValidator()
            {
                RuleFor(v => v.Name).NotEmpty().MinimumLength(3).MaximumLength(255);
                RuleFor(v => v.Url).NotEmpty();
                RuleFor(v => v.PointOfContact).NotNull();
            }
        }
        #endregion


        // IP work for vendors to entity 
        public record VendorItemDetails
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Url { get; set; } = string.Empty;
            public CreateVendorPointOfContactRequest PointOfContact { get; init; } = new();

        }
        public class VendorItemEntity
        {
            public Guid Id { get; set; }
            public string AddedBy { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Url { get; set; } = string.Empty;
            public CreateVendorPointOfContactRequest PointOfContact { get; init; } = new();
            public VendorItemDetails MapToResponse()
            {
                return new VendorItemDetails
                {
                    Id = Id,
                    Name = Name,
                    Url = Url,
                    PointOfContact = PointOfContact,
                };
            }

        }
    }
}
