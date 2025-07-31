
using Alba;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using SoftwareCenter.Api.CatalogItems;
using FluentValidation.TestHelper;

namespace SoftwareCenter.Tests.CatalogItems;

[Trait("Category", "UnitIntegration")]
public  class AddingACatalogItem
{
    [Fact]
    public async Task CanAddACatalogItemWhenTheVendorExists()
    {
        var catalogItem = new CatalogItemCreateRequest
        {
            Description = "Code Editor",
            Name = "Visual Studio Code",
            Version = "1.28.0"
        };
        var fakeVendorId = Guid.NewGuid();
        var host = await AlbaHost.For<Program>(config =>

        {
            config.ConfigureTestServices(services =>
            {
                var fakeVendorLookup = Substitute.For<ILookupVendors>();
                fakeVendorLookup.CheckIfVendorExistsAsync(fakeVendorId).Returns(Task.FromResult(false));
                services.AddScoped<ILookupVendors>( _ => fakeVendorLookup);
            });
        });

        var postReponse = await host.Scenario(api =>
        {
            api.Post.Json(catalogItem).ToUrl($"/vendors/{fakeVendorId}/items");
            api.StatusCodeShouldBeOk();
        });

    }

    [Fact]
    public async Task CannotAddACatalogItemForAVendorThatDoesNotExist()
    {
        var catalogItem = new CatalogItemCreateRequest
        {
            Description = "Code Editor",
            Name = "Visual Studio Code",
            Version = "1.28.0"
        };
        var fakeVendorId = Guid.NewGuid();
        var host = await AlbaHost.For<Program>(config =>
        {
            config.ConfigureTestServices(services =>
            {
                var fakeVendorLookup = Substitute.For<ILookupVendors>();
                fakeVendorLookup.CheckIfVendorExistsAsync(fakeVendorId).Returns(Task.FromResult(true));
                services.AddScoped<ILookupVendors>(_ => fakeVendorLookup);
            });
        });

        var postReponse = await host.Scenario(api =>
        {
            api.Post.Json(catalogItem).ToUrl($"/vendors/{fakeVendorId}/items");
            api.StatusCodeShouldBe(404);
        });

    }
}

public class CatalogItemEntityValidationTests
{
    [Theory]
    [Trait("Category", "UnitTest")]
    [MemberData(nameof(InvalidCatalogItem))]
    public void InvalidCatalogItemEntityValidations(CatalogItemCreateRequest catalogItem)
    {
        var validator = new CatalogItemEntityValidator();
        var validations = validator.TestValidate(catalogItem);
        Assert.False(validations.IsValid);
    }

    [Theory]
    [Trait("Category", "UnitTest")]
    [MemberData(nameof(ValidCatalogItem))]
    public void ValidShowValidations(CatalogItemCreateRequest catalogItem)
    {
        var validator = new CatalogItemEntityValidator();
        var validations = validator.TestValidate(catalogItem);
        Assert.True(validations.IsValid);
    }

    private static readonly int DescriptionMinLength = 10;
    private static readonly int DescriptionMaxLength = 500;
    private static readonly int NameMinLength = 3;
    private static readonly int NameMaxLength = 100;

    public static IEnumerable<object[]> InvalidCatalogItem() =>
        new[]
        {
            new object[] { new CatalogItemCreateRequest() },
            new object[]
            {
                new CatalogItemCreateRequest()
                {
                    Name = new string('x', NameMinLength - 1),
                    Description = new string('x', DescriptionMinLength),
                    Version = ""
                }
            },
            new object[]
            {
                new CatalogItemCreateRequest()
                {
                    Name = new string('X', NameMaxLength + 1),
                    Description = new string('X', DescriptionMaxLength + 1),
                    Version = ""
                }
            },
        };

    public static IEnumerable<object[]> ValidCatalogItem() =>
        new[]
        {
            new object[]
            {
                new CatalogItemCreateRequest()
                {
                    Name = new string('X', NameMaxLength),
                    Description = new string('X', DescriptionMaxLength),
                    Version = "1.0"
                }
            },
            new object[]
            {
                new CatalogItemCreateRequest()
                {
                    Name = new string('X', NameMinLength),
                    Description = new string('X', DescriptionMinLength),
                    Version = "v1.0.1"
                }
            },
        };
}

//public class StubbedReturnsNoVendorLookup : ILookupVendors
//{
//    public Task<bool> CheckIfVendorExistsAsync(Guid id)
//    {
//        return Task.FromResult( false );
//    }
//}

//public class StubbedReturnsYesVendorLookup : ILookupVendors
//{
//    public Task<bool> CheckIfVendorExistsAsync(Guid id)
//    {
//        return Task.FromResult(true);
//    }
//}