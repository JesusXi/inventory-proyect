using ProductInventory.Application.Services
namespace ProductInventory.Tests.Pass
{
    public class PassServiceTests
    {
        [Fact]
        public void Hash_And_Verify_Should_Work()
        {
            var service = new PassService();
            var pass = "123456";
            var hash = service.Hash(pass);
            Assert.True(service.Verify(pass, hash));
            Assert.False(service.Verify("wrong", hash));
        }
    }
}
