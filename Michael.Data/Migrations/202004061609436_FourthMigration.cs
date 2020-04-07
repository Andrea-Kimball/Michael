namespace Michael.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "EraId", "dbo.Eras");
            DropIndex("dbo.Albums", new[] { "EraId" });
            AlterColumn("dbo.Albums", "EraId", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "EraId");
            AddForeignKey("dbo.Albums", "EraId", "dbo.Eras", "EraId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "EraId", "dbo.Eras");
            DropIndex("dbo.Albums", new[] { "EraId" });
            AlterColumn("dbo.Albums", "EraId", c => c.Int());
            CreateIndex("dbo.Albums", "EraId");
            AddForeignKey("dbo.Albums", "EraId", "dbo.Eras", "EraId");
        }
    }
}
