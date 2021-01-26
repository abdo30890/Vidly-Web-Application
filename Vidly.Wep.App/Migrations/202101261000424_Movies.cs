namespace Vidly.Wep.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Movies (Name, AddedDate,ReleaseDate,NumberInStock,GenreId) VALUES ('IronMan','2012-02-01','2010-02-01',5,1)");
            Sql("insert into Movies (Name, AddedDate,ReleaseDate,NumberInStock,GenreId) VALUES ('LOTR','2012-02-01','2010-02-01',6,2)");
            Sql("insert into Movies (Name, AddedDate,ReleaseDate,NumberInStock,GenreId) VALUES ('Extraction','2012-02-01','2010-02-01',2,3)");
            Sql("insert into Movies (Name, AddedDate,ReleaseDate,NumberInStock,GenreId) VALUES ('Hulk','2012-02-01','2010-02-01',8,4)");
            Sql("insert into Movies (Name, AddedDate,ReleaseDate,NumberInStock,GenreId) VALUES ('The Hobbit','2012-02-01','2010-02-01',7,5)");

        }

        public override void Down()
        {
        }
    }
}
