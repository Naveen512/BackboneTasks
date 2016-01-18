namespace BackboneSampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageColumnAddedToState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.States", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.States", "ImageName");
        }
    }
}
