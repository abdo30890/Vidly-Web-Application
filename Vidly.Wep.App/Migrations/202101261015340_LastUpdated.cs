namespace Vidly.Wep.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "AddedDate", c => c.DateTime());
        }
    }
}
