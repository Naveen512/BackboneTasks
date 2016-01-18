namespace BackboneSampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_in_StatePOCO1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "CountryName", c => c.String());
            DropColumn("dbo.Countries", "StateName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "StateName", c => c.String());
            DropColumn("dbo.Countries", "CountryName");
        }
    }
}
