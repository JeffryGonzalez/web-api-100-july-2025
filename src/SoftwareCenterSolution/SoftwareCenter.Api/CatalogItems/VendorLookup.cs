
using System.Linq.Expressions;
using Marten;
using SoftwareCenter.Api.Vendors;

namespace SoftwareCenter.Api.CatalogItems;

public class VendorLookup(IDocumentSession session) : ILookupVendors
{
    public async Task<bool> CheckIfVendorExistsAsync(Guid id)
    {
        var item = await QueryVendorByIdAsync(id);

        return item is not null;
    }

    public async Task<VendorItemResponse?> GetVendorByIdAsync(Guid id) => await QueryVendorByIdAsync(id);
    

    private async Task<VendorItemResponse?> QueryVendorByIdAsync(Guid id)
    {
        return await session.Query<VendorItemResponse>()
                            .Where(v => v.Id == id)
                            .SingleOrDefaultAsync();
    }
}
