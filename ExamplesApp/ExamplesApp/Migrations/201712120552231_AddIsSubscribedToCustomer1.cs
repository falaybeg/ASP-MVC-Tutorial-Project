namespace ExamplesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToCustomer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Surname", c => c.String());
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
    }
}
