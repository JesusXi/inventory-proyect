namespace ProductInventory.Application.Interfaces
{
    public interface IPassService
    {
        byte[] Hash(string pass);
        bool Verify(string pass, byte[] passHash);
    }
}
