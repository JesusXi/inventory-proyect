using Microsoft.Extensions.Configuration;
namespace ProductInventory.Tests.Helpers
{
    public static class TestConfiguration
    {
        public static IConfiguration CreateJwtConfig()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { "Jwt:Key", "THIS_IS_A_VERY_LONG_TEST_KEY_123456789" },
                { "Jwt:Issuer", "ProductInventory.Api" },
                { "Jwt:Audience", "ProductInventory.Client" }
            };
            return new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings!).Build();
        }
    }
}
