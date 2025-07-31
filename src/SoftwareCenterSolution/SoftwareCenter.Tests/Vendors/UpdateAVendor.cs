
using System.Security.Claims;
using Alba;
using Alba.Security;
using static SoftwareCenter.Api.Vendors.Models;

namespace SoftwareCenter.Tests.Vendors
{
    public class UpdateAVendor
    {
        [Fact]
        public async Task WeGetASuccessStatusCode()
        {
            var host = await AlbaHost.For<Program>(
                config =>
                {

                }, new AuthenticationStub().With("sub", "Jill Smith")

                );
            // start the API with our Program.cs, and host it in memory
            var vendorToCreate = new CreateVendorRequest
            {
                Name = "Microsoft",
                Url = "https://www.microsoft.com",

                PointOfContact = new CreateVendorPointOfContactRequest
                {
                    Name = "satya",
                    Email = "satya@microsoft.com",
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

            var postBodyResponse = await postResponse.ReadAsJsonAsync<VendorResponseModel>();

            Assert.NotNull(postBodyResponse);

            var newPointOfContact = new CreateVendorPointOfContactRequest
            {
                Name = "Mary",
                Email = "mary@outlook.com",
                Phone = "888 533-1432"
            };

            var putResponse = await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Put.Json(newPointOfContact).ToUrl($"/vendors/{postBodyResponse.Id}/point-of-contact");
                api.StatusCodeShouldBeOk();
            });

            var putResponseBody = await putResponse.ReadAsJsonAsync<VendorResponseModel>();

            Assert.NotNull(putResponseBody);


            Assert.Equal(postBodyResponse.Id, putResponseBody.Id);

            Assert.Equal(postBodyResponse.Name, putResponseBody.Name);

            Assert.NotEqual(postBodyResponse.PointOfContact, putResponseBody.PointOfContact);
        }

        [Fact]
        public async Task WeGetA400StatusCode()
        {
            var host = await AlbaHost.For<Program>(
                config =>
                {

                }, new AuthenticationStub().With("sub", "Jill Smith")

                );
            // start the API with our Program.cs, and host it in memory
            var vendorToCreate = new CreateVendorRequest
            {
                Name = "Microsoft",
                Url = "https://www.microsoft.com",

                PointOfContact = new CreateVendorPointOfContactRequest
                {
                    Name = "satya",
                    Email = "satya@microsoft.com",
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

            var postBodyResponse = await postResponse.ReadAsJsonAsync<VendorResponseModel>();

            Assert.NotNull(postBodyResponse);

            var newPointOfContact = new CreateVendorPointOfContactRequest
            {
                Name = "",
                Email = "mary@outlook.com",
                Phone = "888 533-1432"
            };

            var putResponse = await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Put.Json(newPointOfContact).ToUrl($"/vendors/{postBodyResponse.Id}/point-of-contact");
                api.StatusCodeShouldBe(400);
            });
        }

        [Fact]
        public async Task WeGetA404StatusCode()
        {
            var host = await AlbaHost.For<Program>(
                config =>
                {

                }, new AuthenticationStub().With("sub", "Jill Smith")

                );
            // start the API with our Program.cs, and host it in memory
            var vendorToCreate = new CreateVendorRequest
            {
                Name = "Microsoft",
                Url = "https://www.microsoft.com",

                PointOfContact = new CreateVendorPointOfContactRequest
                {
                    Name = "satya",
                    Email = "satya@microsoft.com",
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

            var postBodyResponse = await postResponse.ReadAsJsonAsync<VendorResponseModel>();

            Assert.NotNull(postBodyResponse);

            var newPointOfContact = new CreateVendorPointOfContactRequest
            {
                Name = "",
                Email = "mary@outlook.com",
                Phone = "888 533-1432"
            };

            var putResponse = await host.Scenario(api =>
            {
                api.WithClaim(new Claim(ClaimTypes.Role, "SoftwareCenter"));
                api.WithClaim(new Claim(ClaimTypes.Role, "Manager"));
                api.Put.Json(newPointOfContact).ToUrl($"/vendors/1/point-of-contact");
                api.StatusCodeShouldBe(404);
            });
        }
    };
}
