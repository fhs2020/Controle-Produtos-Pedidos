namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camponome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NomeUsuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NomeUsuario");
        }
    }
}
