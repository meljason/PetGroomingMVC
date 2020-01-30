namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mystuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroomBookings", "OwnerID", "dbo.Owners");
            DropForeignKey("dbo.PetOwners", "Owner_OwnerID", "dbo.Owners");
            DropIndex("dbo.PetOwners", new[] { "Owner_OwnerID" });
            DropPrimaryKey("dbo.Owners");
            AddColumn("dbo.Owners", "firstName", c => c.String());
            AddColumn("dbo.Owners", "lastName", c => c.String());
            AddColumn("dbo.Owners", "address", c => c.String());
            AddColumn("dbo.Owners", "workPhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Owners", "homePhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Owners", "OwnerID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Owners", "ownerID");
            CreateIndex("dbo.PetOwners", "Owner_ownerID");
            AddForeignKey("dbo.GroomBookings", "OwnerID", "dbo.Owners", "ownerID", cascadeDelete: true);
            AddForeignKey("dbo.PetOwners", "Owner_ownerID", "dbo.Owners", "ownerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetOwners", "Owner_ownerID", "dbo.Owners");
            DropForeignKey("dbo.GroomBookings", "OwnerID", "dbo.Owners");
            DropIndex("dbo.PetOwners", new[] { "Owner_ownerID" });
            DropPrimaryKey("dbo.Owners");
            AlterColumn("dbo.Owners", "OwnerID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Owners", "homePhoneNumber");
            DropColumn("dbo.Owners", "workPhoneNumber");
            DropColumn("dbo.Owners", "address");
            DropColumn("dbo.Owners", "lastName");
            DropColumn("dbo.Owners", "firstName");
            AddPrimaryKey("dbo.Owners", "OwnerID");
            CreateIndex("dbo.PetOwners", "Owner_OwnerID");
            AddForeignKey("dbo.PetOwners", "Owner_OwnerID", "dbo.Owners", "OwnerID", cascadeDelete: true);
            AddForeignKey("dbo.GroomBookings", "OwnerID", "dbo.Owners", "OwnerID", cascadeDelete: true);
        }
    }
}
