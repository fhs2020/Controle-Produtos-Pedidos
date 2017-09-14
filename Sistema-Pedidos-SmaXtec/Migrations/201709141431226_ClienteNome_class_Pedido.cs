namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteNome_class_Pedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "NomeVendedor", c => c.String());
            AddColumn("dbo.Pedidoes", "ClienteNome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "ClienteNome");
            DropColumn("dbo.Pedidoes", "NomeVendedor");
        }
    }
}
