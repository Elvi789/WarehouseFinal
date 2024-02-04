using Warehouse.Data;

namespace Warehouse.Repository
{
    public class ItemRepository
    {
        public readonly DatabaseContext _context;

        public ItemRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
        public void DeleteItem(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
        public Item GetItem(int id)
        {
            return _context.Items.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }
    }
}
