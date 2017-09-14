namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValorTotal_Class_Pedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "ValorTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "ValorTotal");
        }
    }
}
