namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlueBadge.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlueBadge.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Technicians.AddOrUpdate(
            //  p => p.FullName,
            //  new Technician { FirstName = "Andrew Peters" },
            //  new Technician { FirstName = "Brice Lambson" },
            //  new Technician { FirstName = "Rowan Miller" }
            //);
            //

            
        }
    }
}
