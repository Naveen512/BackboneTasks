namespace BackboneSampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_in_StatePOCO : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "State_StateID", "dbo.States");
            DropIndex("dbo.Countries", new[] { "State_StateID" });
            CreateIndex("dbo.States", "CountryID");
            AddForeignKey("dbo.States", "CountryID", "dbo.Countries", "CountryID", cascadeDelete: true);
            DropColumn("dbo.Countries", "State_StateID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "State_StateID", c => c.Int());
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryID" });
            CreateIndex("dbo.Countries", "State_StateID");
            AddForeignKey("dbo.Countries", "State_StateID", "dbo.States", "StateID");
        }
    }
}
