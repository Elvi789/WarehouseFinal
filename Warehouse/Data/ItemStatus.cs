namespace Warehouse.Data
{
    public class ItemStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool inWarehouse { get; set; }

        public bool InvolvePayments { get; set; }
        public string ItemStatusColor { get; set; }
    }
}
