namespace DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BusinessModel;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.InvoiceModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.InvoiceModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.StaffTypes.Count() < 1)
            {
                context.StaffTypes.Add(new StaffType
                {
                    Name = "Admin"
                });
                context.SaveChanges();
            }

            if (context.OrderStatus.Count() < 1)
            {
                context.OrderStatus.AddRange(new List<OrderStatus>
                {
                    new OrderStatus { Status="Intiated" },
                    new OrderStatus {Status="Shipped"},
                    new OrderStatus {Status = "Delivered"},
                });
            }
        }
    }
}
