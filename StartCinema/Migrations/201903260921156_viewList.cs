namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieShovingViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CinemaId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CinemaId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieShovingViewModels", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieShovingViewModels", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.MovieShovingViewModels", new[] { "MovieId" });
            DropIndex("dbo.MovieShovingViewModels", new[] { "CinemaId" });
            DropTable("dbo.MovieShovingViewModels");
        }
    }
}
