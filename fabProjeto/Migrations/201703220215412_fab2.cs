namespace fabProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fab2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuários", "nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuários", "nome");
        }
    }
}
