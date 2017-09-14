namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Class_Pedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "Pedido_PedidoID", "dbo.Pedidoes");
            DropIndex("dbo.Produtoes", new[] { "Pedido_PedidoID" });
            DropColumn("dbo.Produtoes", "Pedido_PedidoID");
            DropTable("dbo.Pedidoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        UsuarioID = c.String(),
                        DataPedido = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoID);
            
            AddColumn("dbo.Produtoes", "Pedido_PedidoID", c => c.Int());
            CreateIndex("dbo.Produtoes", "Pedido_PedidoID");
            AddForeignKey("dbo.Produtoes", "Pedido_PedidoID", "dbo.Pedidoes", "PedidoID");
        }
    }
}
