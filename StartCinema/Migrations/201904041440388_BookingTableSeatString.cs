namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingTableSeatString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "SeatCount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "SeatCount", c => c.Int(nullable: false));
        }
    }
}
