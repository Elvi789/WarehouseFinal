using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



        [ForeignKey("ItemTypeId")]
       
        
        public int? ItemTypeId { get; set; }

        public virtual ItemType ItemType { get; set; }


       
    }
    
}
