namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BookingForDate = c.DateTime(),
                        BookingMadeDate = c.DateTime(),
                        SeatCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        CreditCardNumber = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviePlays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieSeats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RowSeatId = c.Int(nullable: false),
                        RefSeatStatusId = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false),
                        MoviePlayId = c.Int(nullable: false),
                        DateMovie = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.MoviePlays", t => t.MoviePlayId, cascadeDelete: true)
                .ForeignKey("dbo.RefSeatStatus", t => t.RefSeatStatusId, cascadeDelete: true)
                .ForeignKey("dbo.RowSeats", t => t.RowSeatId, cascadeDelete: true)
                .Index(t => t.RowSeatId)
                .Index(t => t.RefSeatStatusId)
                .Index(t => t.BookingId)
                .Index(t => t.MoviePlayId);
            
            CreateTable(
                "dbo.RefSeatStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RowSeats", "SeatNumber", c => c.Int(nullable: false));
            DropColumn("dbo.RowSeats", "SeatCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RowSeats", "SeatCount", c => c.Int(nullable: false));
            DropForeignKey("dbo.MovieSeats", "RowSeatId", "dbo.RowSeats");
            DropForeignKey("dbo.MovieSeats", "RefSeatStatusId", "dbo.RefSeatStatus");
            DropForeignKey("dbo.MovieSeats", "MoviePlayId", "dbo.MoviePlays");
            DropForeignKey("dbo.MovieSeats", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MovieSeats", new[] { "MoviePlayId" });
            DropIndex("dbo.MovieSeats", new[] { "BookingId" });
            DropIndex("dbo.MovieSeats", new[] { "RefSeatStatusId" });
            DropIndex("dbo.MovieSeats", new[] { "RowSeatId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropColumn("dbo.RowSeats", "SeatNumber");
            DropTable("dbo.RefSeatStatus");
            DropTable("dbo.MovieSeats");
            DropTable("dbo.MoviePlays");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
