namespace StartCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameCinema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cinemas", "CinemaName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cinemas", "CinemaName");
        }
    }
}
