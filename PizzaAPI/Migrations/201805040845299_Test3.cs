namespace PizzaAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderItems", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderItems", "UserId", c => c.Int(nullable: false));
        }
    }
}
