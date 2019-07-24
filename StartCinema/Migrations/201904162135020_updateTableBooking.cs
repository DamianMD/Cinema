namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableBooking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "BookingForDate");
            DropColumn("dbo.Bookings", "SeatCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "SeatCount", c => c.String());
            AddColumn("dbo.Bookings", "BookingForDate", c => c.DateTime());
        }
    }
}
