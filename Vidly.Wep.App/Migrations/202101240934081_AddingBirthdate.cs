namespace Vidly.Wep.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '1999-12-12' WHERE Customers.Id= 1");
        }
        
        public override void Down()
        {
        }
    }
}
