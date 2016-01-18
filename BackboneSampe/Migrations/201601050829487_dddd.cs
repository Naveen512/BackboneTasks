namespace BackboneSampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        State_StateID = c.Int(),
                    })
                .PrimaryKey(t => t.CountryID)
                .ForeignKey("dbo.States", t => t.State_StateID)
                .Index(t => t.State_StateID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        Descriptions = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "State_StateID", "dbo.States");
            DropIndex("dbo.Countries", new[] { "State_StateID" });
            DropTable("dbo.States");
            DropTable("dbo.Countries");
        }
    }
}
