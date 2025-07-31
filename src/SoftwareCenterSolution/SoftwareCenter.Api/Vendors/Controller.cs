using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareCenter.Api.CatalogItems;

namespace SoftwareCenter.Api.Vendors;


[Authorize] // no longer allow anonymous people to do anything here.
public class Controller(IDocumentSession session) : ControllerBase
{

    // this is the method you should call when a POST /vendors is received.
    [HttpPost("/vendors")]
    [Authorize(Policy = "CanAddVendor")]
    public async Task<ActionResult> AddAVendorAsync(
        [FromBody] CreateVendorRequest request,
        [FromServices] IValidator<CreateVendorRequest> validator,
        CancellationToken token)
    {
        //if(!ModelState.IsValid)
        // {
        //     return BadRequest(ModelState);
        // }

        var validationResults = await validator.ValidateAsync(request);
        if (!validationResults.IsValid)
        {
            return BadRequest(validationResults);
        }
        // validation
        // You can't add a vendor with the same name more than once.
        // field validation - what is required, what is optional, what are the rules for the required things
        // domain validation - we don't already have a vendor with that same name
        // 
        // we have to "save it" somewhere. 

        // Mapping Code (copy from one object to another)
        
        var response = new VendorItemResponse(
            Guid.NewGuid(),
            User.Identity!.Name!,
            request.Name,
            request.Url,
            request.PointOfContact
            );
        session.Store(response); // I would to add a vendor
        //                         // I want to update this other table, maybe 
        await session.SaveChangesAsync();
        return Ok(response.MapToDto());
    }


    [HttpGet("/vendors/{id:guid}")]
    public async Task<ActionResult> GetVendorByIdAsync(Guid id, CancellationToken token)
    {
        // look that thing up in the database.
        var response = await session
            .Query<VendorItemResponse>()
            .Where(v => v.Id == id)
            .SingleOrDefaultAsync();

        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response.MapToDto());
        }
    }

    [HttpGet("/vendors")]
    public async Task<ActionResult> GetAllVendorsAsync(CancellationToken token)
    {
        var vendors = await session.Query<VendorItemResponse>().ToListAsync();

        return Ok(vendors);
    }

    [HttpPut("/vendors/{id:guid}/point-of-contact")]
    [Authorize(Policy = "CanUpdateVendorPointofContact")]
    public async Task<ActionResult> UpdateVendorPointOfContactAsync(
        [FromRoute] Guid id, 
        [FromBody] CreateVendorPointOfContactRequest request, 
        [FromServices] ILookupVendors vendorLookupService, 
        [FromServices] IValidator<CreateVendorPointOfContactRequest> validator
    )
    {
        var validationResults = await validator.ValidateAsync(request);
        if (!validationResults.IsValid)
        {
            return BadRequest(validationResults);
        }

        if (!await vendorLookupService.CheckIfVendorExistsAsync(id))
        {
            return NotFound();
        }

        var vendor = await vendorLookupService.GetVendorByIdAsync(id);
        
        var updatedVendorPointOfContact = vendor! with { PointOfContact =  request };

        session.Update(updatedVendorPointOfContact);
        await session.SaveChangesAsync();
        return NoContent();
    }

}