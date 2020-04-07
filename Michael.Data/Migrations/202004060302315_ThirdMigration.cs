namespace Michael.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eras", "Name", c => c.String());
            DropColumn("dbo.Albums", "MJE");
            DropColumn("dbo.Eras", "MJE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Eras", "MJE", c => c.Int(nullable: false));
            AddColumn("dbo.Albums", "MJE", c => c.Int(nullable: false));
            DropColumn("dbo.Eras", "Name");
        }
    }
}
