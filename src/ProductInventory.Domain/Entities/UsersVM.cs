namespace ProductInventory.Domain.Entities
{
    public class UsersVM
    {
        public Guid Id { get; private set; }
        public int User { get; private set; }
        public string Email { get; private set; }
        public byte[] Password { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        protected UsersVM() { }
        public UsersVM(string email, byte[] pass)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = pass;
            IsActive = true;
            CreatedAt = DateTime.Now;
        }
        public void Deactivate() { IsActive = false; }
    }
}