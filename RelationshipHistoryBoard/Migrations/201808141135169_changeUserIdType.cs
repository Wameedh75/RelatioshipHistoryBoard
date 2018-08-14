namespace RelationshipHistoryBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserIdType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FeedBacks", new[] { "User_Id" });
            DropColumn("dbo.FeedBacks", "UserId");
            RenameColumn(table: "dbo.FeedBacks", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.FeedBacks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.FeedBacks", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FeedBacks", new[] { "UserId" });
            AlterColumn("dbo.FeedBacks", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FeedBacks", name: "UserId", newName: "User_Id");
            AddColumn("dbo.FeedBacks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.FeedBacks", "User_Id");
        }
    }
}
