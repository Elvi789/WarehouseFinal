namespace Warehouse.Data
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<Item> Items { get; set; }
    }
}
