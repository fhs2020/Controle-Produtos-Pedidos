namespace Sistema_Pedidos_SmaXtec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Class_Cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        RG = c.Int(nullable: false),
                        EnderecoResidencial = c.String(),
                        EnderecoRural = c.String(),
                        Documento = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        MyProperty = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
