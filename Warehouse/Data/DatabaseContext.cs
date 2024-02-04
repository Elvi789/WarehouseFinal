using Microsoft.EntityFrameworkCore;

namespace Warehouse.Data
{
    public class DatabaseContext:DbContext //krijimi i nje klasae databaseContext e cila do te trazhgoje nga DbContext e entityFrameworckCore
    {
        public DatabaseContext(DbContextOptions options) : base(options)  //construcktori
        { }
        public DbSet<Warehouse> Warehouses { get; set; } //shtimi i tabeles warehouse ne database
        public DbSet<Item> Items { get; set; } //shtimi i tabeles warehouse ne database
        public DbSet<ItemType> ItemTypes { get; set; } //shtimi i tabeles itemtype ne database
        public DbSet<ItemStatus> ItemStatuses { get; set; } //shtimi i tabeles itemtype ne database


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            builder.Entity<ItemType>()
             .HasMany(e => e.Items)
             .WithOne(e => e.ItemType)
             .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
