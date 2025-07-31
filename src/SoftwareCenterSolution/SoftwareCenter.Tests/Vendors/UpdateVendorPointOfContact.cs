using System.Net;
using System.Security.Claims;
using Alba;
using Alba.Security;
using SoftwareCenter.Api.Vendors;

namespace SoftwareCenter.Tests.Vendors
{
    public class UpdateVendorPointOfContact
    {
        [Fact]
        public async Task MustMeetSercurityPolicyToUpdateVendorPointOfContact()
        {
            var host = await AlbaHost.For<Program>(
                cfg => { }, new AuthenticationStub());

            var vendorId = Guid.NewGuid();
            var pointOfContact = new CreateVendorPointOfContactRequest
            {
                Name = "Ryan",
                Email = "ryan@aol.com",
                Phone = "800-123-4567"
            };

            var putResponse = await host.Scenario(api =>
            {
                api.Put.Json(pointOfContact).ToUrl($"/vendors/{vendorId}/point-of-contact");
                api.StatusCodeShouldBe(403);
            });
        }

        [Fact]
        public async Task MustHaveProperAuthToUpdateVendorPointofContact()
        {
            var host = await AlbaHost.For<Program>();

            var vendorId = Guid.NewGuid();
            var pointOfContact = new CreateVendorPointOfContactRequest
            {
                Name = "Ryan",
                Email = "ryan@aol.com",
                Phone = "800-123-4567"
            };

            var putResponse = await host.Scenario(api =>
            {
                api.Put.Json(pointOfContact).ToUrl($"/vendors/{vendorId}/point-of-contact");
                api.StatusCodeShouldBe(401);
            });
        }

        [Fact]
        public async Task WeGetABadRequest()
        {
            var host = await AlbaHost.For<Program>(
            config =>
            {

            }, new AuthenticationStub().With("sub", "Jane Doe")

            );

            var vendorId = Guid.NewGuid();
            var pointOfContact = new CreateVendorPointOfContactRequest
            {
                Name = "",
                Email = "ryan@microsoft.com",
                Phone = "888 555-1212"
            };

            var putResponse = await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Put.Json(pointOfContact).ToUrl($"/vendors/{vendorId}/point-of-contact");

                api.StatusCodeShouldBe(HttpStatusCode.BadRequest);
            });
        }

        [Fact]
        public async Task WeGetANotFound()
        {
            var host = await AlbaHost.For<Program>(
            config =>
            {

            }, new AuthenticationStub().With("sub", "Jane Doe")

            );

            var vendorId = Guid.Empty;
            var pointOfContact = new CreateVendorPointOfContactRequest
            {
                Name = "Ryan",
                Email = "ryan@microsoft.com",
                Phone = "888 555-1212"
            };

            var putResponse = await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Put.Json(pointOfContact).ToUrl($"/vendors/{vendorId}/point-of-contact");

                api.StatusCodeShouldBe(HttpStatusCode.NotFound);
            });
        }

        [Fact]
        public async Task WeCanUpdatePointOfContactInfo()
        {
            var host = await AlbaHost.For<Program>(
            config =>
            {

            }, new AuthenticationStub().With("sub", "Jane Doe")

            );

            var vendorToCreate = new CreateVendorRequest
            {
                Name = "Red Hat",
                Url = "https://www.redhat.com",

                PointOfContact = new CreateVendorPointOfContactRequest
                {
                    Name = "ryan",
                    Email = "ryan@redhat.com",
                    Phone = "888 555-1212"
                }
            };
            var postResponse = await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Post.Json(vendorToCreate).ToUrl("/vendors");

                api.StatusCodeShouldBeOk();
            });

            var postBodyResponse = await postResponse.ReadAsJsonAsync<CreateVendorResponse>();

            Assert.NotNull(postBodyResponse);

            var updatedPointOfContact = new CreateVendorPointOfContactRequest
            {
                Email = "bill@redhat.com",
                Name = "Billy Bob",
                Phone = "800-123-4567"
            };

            await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Put.Json(updatedPointOfContact).ToUrl($"/vendors/{postBodyResponse.Id}/point-of-contact");

                api.StatusCodeShouldBe(HttpStatusCode.NoContent);
            });

            var getVendorByIdResponse = await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Get.Url($"/vendors/{postBodyResponse.Id}");

                api.StatusCodeShouldBeOk();
            });

            var getVendorByIdBodyResponse = await getVendorByIdResponse.ReadAsJsonAsync<CreateVendorResponse>();
            Assert.NotNull(getVendorByIdBodyResponse);

            Assert.Equal(updatedPointOfContact, getVendorByIdBodyResponse.PointOfContact);
        }
    }
}
