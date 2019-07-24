namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableBokingMovieId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieSeats", "MoviePlayId", "dbo.MoviePlays");
            DropForeignKey("dbo.MovieSeats", "BookingId", "dbo.Bookings");
            DropIndex("dbo.MovieSeats", new[] { "BookingId" });
            DropIndex("dbo.MovieSeats", new[] { "MoviePlayId" });
            AddColumn("dbo.MovieSeats", "MovieId", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieSeats", "BookingId", c => c.Int());
            CreateIndex("dbo.MovieSeats", "BookingId");
            CreateIndex("dbo.MovieSeats", "MovieId");
            AddForeignKey("dbo.MovieSeats", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.MovieSeats", "BookingId", "dbo.Bookings", "Id");
            DropColumn("dbo.MovieSeats", "MoviePlayId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieSeats", "MoviePlayId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MovieSeats", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.MovieSeats", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieSeats", new[] { "MovieId" });
            DropIndex("dbo.MovieSeats", new[] { "BookingId" });
            AlterColumn("dbo.MovieSeats", "BookingId", c => c.Int(nullable: false));
            DropColumn("dbo.MovieSeats", "MovieId");
            CreateIndex("dbo.MovieSeats", "MoviePlayId");
            CreateIndex("dbo.MovieSeats", "BookingId");
            AddForeignKey("dbo.MovieSeats", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieSeats", "MoviePlayId", "dbo.MoviePlays", "Id", cascadeDelete: true);
        }
    }
}
