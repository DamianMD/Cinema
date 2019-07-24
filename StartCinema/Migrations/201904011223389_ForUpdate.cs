namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieImage_Id", "dbo.MovieImages");
            DropIndex("dbo.Movies", new[] { "MovieImage_Id" });
            AddColumn("dbo.Movies", "Image", c => c.String());
            DropColumn("dbo.Movies", "MovieImageId");
            DropColumn("dbo.Movies", "MovieImage_Id");
            DropTable("dbo.MovieImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImgName = c.String(),
                        ImgPath = c.String(),
                        Width = c.Int(nullable: false),
                        Lenght = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MovieImage_Id", c => c.Guid());
            AddColumn("dbo.Movies", "MovieImageId", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Image");
            CreateIndex("dbo.Movies", "MovieImage_Id");
            AddForeignKey("dbo.Movies", "MovieImage_Id", "dbo.MovieImages", "Id");
        }
    }
}
