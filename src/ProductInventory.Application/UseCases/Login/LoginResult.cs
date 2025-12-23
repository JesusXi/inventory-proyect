namespace ProductInventory.Application.UseCases.Login
{
    public record LoginResult(string Token, DateTime ExpiresAt);
}
