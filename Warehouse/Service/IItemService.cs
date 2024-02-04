using Warehouse.Data;

namespace Warehouse.Service
{
    public interface IItemService
    {
        void Add(Item item);
        void Update(Item item);
        void Delete(Item item);
        Item Get(int id);
        List<Item> GetAll();
    }
}
