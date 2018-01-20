namespace ExamplesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirtdateOfCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers Set Birthdate=13/12/2017 where Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
