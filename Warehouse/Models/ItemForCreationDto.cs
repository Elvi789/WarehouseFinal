using Warehouse.Data;

namespace Warehouse.Models
{
    public class ItemForCreationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ItemTypeId { get; set; } // kjo do te mbaje vleren e item type id qe do na zgjidhet nga view


        public virtual List<ItemType> ItemTypes { get; set; }
    }
}
