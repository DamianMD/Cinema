namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            AddColumn("dbo.Bookings", "Name", c => c.String());
            AddColumn("dbo.Bookings", "Phone", c => c.String());
            AddColumn("dbo.Bookings", "Mail", c => c.String());
            AddColumn("dbo.Bookings", "Description", c => c.String());
            AddColumn("dbo.Bookings", "Cola", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bookings", "Popcorn", c => c.Boolean(nullable: false));
            DropColumn("dbo.Bookings", "CustomerId");
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Mail = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bookings", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "Popcorn");
            DropColumn("dbo.Bookings", "Cola");
            DropColumn("dbo.Bookings", "Description");
            DropColumn("dbo.Bookings", "Mail");
            DropColumn("dbo.Bookings", "Phone");
            DropColumn("dbo.Bookings", "Name");
            CreateIndex("dbo.Bookings", "CustomerId");
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
