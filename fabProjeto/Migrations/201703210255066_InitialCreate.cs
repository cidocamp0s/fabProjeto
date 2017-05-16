namespace fabProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.usuarioDTOes",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Senha = c.String(),
                        Administrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.usuarioDTOes");
        }
    }
}
