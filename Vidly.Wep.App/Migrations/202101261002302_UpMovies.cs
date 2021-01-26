namespace Vidly.Wep.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Update  Movies SET Name='Coco', AddedDate='2012-02-01',ReleaseDate='2010-02-01',NumberInStock=5,GenreId=1  where Id = 1") ;
            Sql("Update  Movies SET Name='King Kong', AddedDate='2012-02-01',ReleaseDate='2010-02-01',NumberInStock=6,GenreId=2  where Id = 2") ;
            Sql("Update  Movies SET Name='Thor', AddedDate='2012-02-01',ReleaseDate='2010-02-01',NumberInStock=7,GenreId=3  where Id = 3") ;
            Sql("Update  Movies SET Name='Tenet', AddedDate='2012-02-01',ReleaseDate='2010-02-01',NumberInStock=8,GenreId=4  where Id = 4") ;
            Sql("Update  Movies SET Name='Fighter', AddedDate='2012-02-01',ReleaseDate='2010-02-01',NumberInStock=9,GenreId=5  where Id = 5") ;
        }

        public override void Down()
        {
        }
    }
}
