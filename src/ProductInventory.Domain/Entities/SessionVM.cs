namespace ProductInventory.Domain.Entities
{
    public class SessionVM
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        protected SessionVM() { }
        public SessionVM(Guid idUser, string token)
        {
            Id = Guid.NewGuid();
            UserId = idUser;
            Token = token;
            CreatedAt = DateTime.Now;
        }
        public void Renew(string token)
        {
            Token = token;
            CreatedAt = DateTime.Now;
            ExpiresAt = DateTime.Now.AddMinutes(5);
        }
        public bool IsExpired()
        {
            return DateTime.Now > ExpiresAt;
        }
    }
}