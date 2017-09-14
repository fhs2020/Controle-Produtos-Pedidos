namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_MyProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
