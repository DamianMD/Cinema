namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Mail", c => c.String());
            DropColumn("dbo.Customers", "CreditCardNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CreditCardNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Mail");
        }
    }
}
