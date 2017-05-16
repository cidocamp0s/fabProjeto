namespace fabProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationsFAB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.usuarioDTOes", newName: "Usuários");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Usuários", newName: "usuarioDTOes");
        }
    }
}
