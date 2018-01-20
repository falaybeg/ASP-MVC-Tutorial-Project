namespace ExamplesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailabilityOfMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvailable = Stock");

        }

        public override void Down()
        {
        }
    }
}
