namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BoxOffice = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.ScreenDetails",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        ScreenName = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ActorId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Bio = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ScreenDetails", new[] { "ActorId" });
            DropIndex("dbo.ScreenDetails", new[] { "MovieId" });
            DropForeignKey("dbo.ScreenDetails", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.ScreenDetails", "MovieId", "dbo.Movies");
            DropTable("dbo.Actors");
            DropTable("dbo.ScreenDetails");
            DropTable("dbo.Movies");
        }
    }
}
