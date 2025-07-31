namespace SoftwareCenter.Api.Vendors
{
    public class Dtos
    {
        public record VendorItemResponseDto(Guid Id, string Name, 
            string Url, CreateVendorPointOfContactRequest PointOfContact
        );
    }
}
