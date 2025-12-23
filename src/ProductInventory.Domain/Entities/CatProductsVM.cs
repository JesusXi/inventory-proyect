namespace ProductInventory.Domain.Entities
{
    public class CatProductsVM
    {
        public int Id { get; private set; }
        public int IdCategory { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime EdithAt { get; private set; }
        private CatProductsVM() { }
        public CatProductsVM(int idCategory, string name, string description)
        {
            IdCategory = idCategory;
            Name = name;
            Description = description;

        }
        public void Update(CatProductsVM catProducts)
        {
            IdCategory = catProducts.IdCategory;
            Name = catProducts.Name;
            Description = catProducts.Description;
        }
        public void Deactivate()
        {
            Active = false;
        }
    }
}