namespace EpicTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusiness : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "BusinessId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "ApplicationUserId");
            CreateIndex("dbo.Employees", "BusinessId");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "BusinessId", "dbo.Businesses", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropForeignKey("dbo.Employees", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "BusinessId" });
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropColumn("dbo.Employees", "BusinessId");
            DropColumn("dbo.Employees", "ApplicationUserId");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
            DropTable("dbo.Businesses");
        }
    }
}
