namespace Michael.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixthmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Songs", "ReleaseYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "ReleaseYear", c => c.Int(nullable: false));
        }
    }
}
