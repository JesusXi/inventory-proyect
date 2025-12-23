namespace ProductInventory.Domain.Entities
{
    public class CatCategoryVM
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime EdithAt { get; private set; }
        private CatCategoryVM() { }
        public record CategoryUpdate(string name, string description);
        public CatCategoryVM(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void Update(CategoryUpdate catCategory)
        {
            Name = catCategory.name;
            Description = catCategory.description;
        }
        public void Deactivate()
        {
            Active = false;
        }
    }
}