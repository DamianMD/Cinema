namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSeatCountBookigModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "SeatCount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "SeatCount");
        }
    }
}
