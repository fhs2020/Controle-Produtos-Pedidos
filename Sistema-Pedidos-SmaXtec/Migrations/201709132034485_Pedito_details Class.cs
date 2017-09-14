namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedito_detailsClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(),
                        ClienteID = c.Int(nullable: false),
                        ClienteNome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        DataPedido = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.OrderDetails", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.OrderDetails", new[] { "ProdutoId" });
            DropIndex("dbo.OrderDetails", new[] { "PedidoId" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteID" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Pedidoes");
        }
    }
}
