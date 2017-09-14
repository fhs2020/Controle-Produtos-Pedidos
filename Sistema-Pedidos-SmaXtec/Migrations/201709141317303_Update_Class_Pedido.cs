namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Class_Pedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "QuantidadeBase", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "QuantRepetidor", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "QuantSensorClimatico", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "QuantAplicador", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "QuantSensor", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "QuantSensorPrimium", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "DataPedido", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pedidoes", "ProdutoId", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "Produto_ProdutoID", c => c.Int());
            AddColumn("dbo.Produtoes", "Pedido_Id", c => c.Int());
            CreateIndex("dbo.Pedidoes", "Produto_ProdutoID");
            CreateIndex("dbo.Produtoes", "Pedido_Id");
            AddForeignKey("dbo.Pedidoes", "Produto_ProdutoID", "dbo.Produtoes", "ProdutoID");
            AddForeignKey("dbo.Produtoes", "Pedido_Id", "dbo.Pedidoes", "Id");
            DropColumn("dbo.Pedidoes", "ClienteNome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidoes", "ClienteNome", c => c.String(nullable: false));
            DropForeignKey("dbo.Produtoes", "Pedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "Produto_ProdutoID", "dbo.Produtoes");
            DropIndex("dbo.Produtoes", new[] { "Pedido_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Produto_ProdutoID" });
            DropColumn("dbo.Produtoes", "Pedido_Id");
            DropColumn("dbo.Pedidoes", "Produto_ProdutoID");
            DropColumn("dbo.Pedidoes", "ProdutoId");
            DropColumn("dbo.Pedidoes", "DataPedido");
            DropColumn("dbo.Pedidoes", "QuantSensorPrimium");
            DropColumn("dbo.Pedidoes", "QuantSensor");
            DropColumn("dbo.Pedidoes", "QuantAplicador");
            DropColumn("dbo.Pedidoes", "QuantSensorClimatico");
            DropColumn("dbo.Pedidoes", "QuantRepetidor");
            DropColumn("dbo.Pedidoes", "QuantidadeBase");
        }
    }
}
