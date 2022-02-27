using System;
using System.Data.Entity;
using System.Linq;
using BusinessModel;

namespace DataAccess
{
    public class InvoiceModel : DbContext
    {
        // Your context has been configured to use a 'InvoiceModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccess.InvoiceModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InvoiceModel' 
        // connection string in the application configuration file.
        public InvoiceModel()
            : base("name=InvoiceModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderXStatus> OrderXStatus { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationDetails> QuotationDetails { get; set; }
        public DbSet<StaffType> StaffTypes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}