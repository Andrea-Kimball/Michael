namespace Michael.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class byteAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "SongAudio", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "SongAudio");
        }
    }
}
