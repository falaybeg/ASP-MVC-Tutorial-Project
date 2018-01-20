namespace ExamplesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationCustomerName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "SignUpFee", c => c.Short(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MemberShipTypes", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "SignUpFree", c => c.Short(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.MemberShipTypes", "SignUpFee");
        }
    }
}
