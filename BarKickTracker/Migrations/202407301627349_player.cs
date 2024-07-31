namespace BarKickTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class player : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        PlayerPosition = c.String(),
                        TeamID = c.Int(nullable: false),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        TeamBio = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                        VenueLocation = c.String(),
                    })
                .PrimaryKey(t => t.VenueID);
            
            CreateTable(
                "dbo.VenuesTeams",
                c => new
                    {
                        Venues_VenueID = c.Int(nullable: false),
                        Teams_TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Venues_VenueID, t.Teams_TeamID })
                .ForeignKey("dbo.Venues", t => t.Venues_VenueID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Teams_TeamID, cascadeDelete: true)
                .Index(t => t.Venues_VenueID)
                .Index(t => t.Teams_TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.VenuesTeams", "Teams_TeamID", "dbo.Teams");
            DropForeignKey("dbo.VenuesTeams", "Venues_VenueID", "dbo.Venues");
            DropIndex("dbo.VenuesTeams", new[] { "Teams_TeamID" });
            DropIndex("dbo.VenuesTeams", new[] { "Venues_VenueID" });
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropTable("dbo.VenuesTeams");
            DropTable("dbo.Venues");
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}
