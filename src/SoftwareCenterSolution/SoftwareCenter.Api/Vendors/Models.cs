using FluentValidation;

namespace SoftwareCenter.Api.Vendors
{
    public class Models
    {
        public record CreateVendorRequest
        {

            public string Name { get; init; } = string.Empty;
            public string Url { get; init; } = string.Empty;
            public CreateVendorPointOfContactRequest PointOfContact { get; init; } = new();
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

        public record CreateVendorPointOfContactRequest
        {
            public string Name { get; init; } = string.Empty;
            public string Phone { get; init; } = string.Empty;
            public string Email { get; init; } = string.Empty;
        };

        public class CreateVendorPointOfContactRequestValidator :
            AbstractValidator<CreateVendorPointOfContactRequest>
        {
            public CreateVendorPointOfContactRequestValidator()
            {
                RuleFor(p => p.Name).NotEmpty();

            }
        }

        public record VendorResponseModel(
            Guid Id,
            string AddedBy,
            string Name, string Url, CreateVendorPointOfContactRequest PointOfContact
            );
    }
}
