using Warehouse.Data;
using Warehouse.Repository;

namespace Warehouse.Service
{
    public class ItemService : IItemService
    {
        public readonly ItemRepository _itemRepository;

        public ItemService(ItemRepository  repo)
        {
            _itemRepository = repo;
        }
        public void Add(Item item)
        {
            _itemRepository.CreateItem(item);
        }
        public void Update(Item item)
        {
            _itemRepository.UpdateItem(item);
        }
        public void Delete(Item item)
        {
            _itemRepository.DeleteItem(item);
        }
        public Item Get(int id)
        {
            return _itemRepository.GetItem(id);
        }
        public List<Item> GetAll()
        {
            return _itemRepository.GetAllItems();
        }
    }
}
