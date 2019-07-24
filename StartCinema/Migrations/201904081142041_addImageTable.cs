namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "MovieImage_Id", c => c.Int());
            CreateIndex("dbo.Movies", "MovieImage_Id");
            AddForeignKey("dbo.Movies", "MovieImage_Id", "dbo.MovieImages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieImage_Id", "dbo.MovieImages");
            DropIndex("dbo.Movies", new[] { "MovieImage_Id" });
            DropColumn("dbo.Movies", "MovieImage_Id");
            DropColumn("dbo.Movies", "ImageId");
            DropTable("dbo.MovieImages");
        }
    }
}
