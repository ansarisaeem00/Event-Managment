namespace BackendApi2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackendApi2ApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deatails", "FacultyCordinator", c => c.String());
            AddColumn("dbo.Deatails", "StudentCordinator", c => c.String());
            AddColumn("dbo.Deatails", "Sponsor", c => c.String());
            AddColumn("dbo.Deatails", "TechSupport", c => c.String());
            AddColumn("dbo.Deatails", "Guest", c => c.String());
            AddColumn("dbo.Deatails", "ResoursePerson", c => c.String());
            AddColumn("dbo.Deatails", "Outcome", c => c.String());
            AddColumn("dbo.Deatails", "Budget", c => c.String());
            AddColumn("dbo.Deatails", "EnrollId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deatails", "EnrollId");
            DropColumn("dbo.Deatails", "Budget");
            DropColumn("dbo.Deatails", "Outcome");
            DropColumn("dbo.Deatails", "ResoursePerson");
            DropColumn("dbo.Deatails", "Guest");
            DropColumn("dbo.Deatails", "TechSupport");
            DropColumn("dbo.Deatails", "Sponsor");
            DropColumn("dbo.Deatails", "StudentCordinator");
            DropColumn("dbo.Deatails", "FacultyCordinator");
        }
    }
}
