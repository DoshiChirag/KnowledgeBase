namespace ContactManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "AddressType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Address", "AddressType");
        }
    }
}
