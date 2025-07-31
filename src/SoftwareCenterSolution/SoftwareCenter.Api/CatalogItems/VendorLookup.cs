
using Marten;
using SoftwareCenter.Api.Vendors;
using static SoftwareCenter.Api.Vendors.Models;

namespace SoftwareCenter.Api.CatalogItems;

public class VendorLookup(IDocumentSession session) : ILookupVendors
{
    public async Task<bool> CheckIfVendorExistsAsync(Guid id)
    {
        var item =  await session.Query<VendorResponseModel>().Where(v => v.Id == id).SingleOrDefaultAsync();

        return item == null;
    }
}
