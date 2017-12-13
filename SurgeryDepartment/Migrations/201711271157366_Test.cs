namespace SurgeryDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiseaseSymptoms",
                c => new
                    {
                        DiseaseId = c.Int(nullable: false),
                        SymptomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiseaseId, t.SymptomId })
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.Symptoms", t => t.SymptomId, cascadeDelete: true)
                .Index(t => t.DiseaseId)
                .Index(t => t.SymptomId);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientDiseases",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        DiseaseId = c.Int(nullable: false),
                        Prise = c.Int(nullable: false),
                        Patient_CardNumber = c.Int(),
                    })
                .PrimaryKey(t => new { t.PatientId, t.DiseaseId })
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_CardNumber)
                .Index(t => t.DiseaseId)
                .Index(t => t.Patient_CardNumber);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        CardNumber = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Sex = c.String(),
                        Diagnosis = c.String(),
                        Address = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardNumber)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxCapacity = c.Int(nullable: false),
                        Type = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        RoomId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomId, t.EmployeeId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Post = c.String(),
                        Sex = c.String(),
                        Address = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Shedule = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        PatientDiseaseId = c.Int(nullable: false),
                        PatientDisease_PatientId = c.Int(),
                        PatientDisease_DiseaseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.PatientDiseases", t => new { t.PatientDisease_PatientId, t.PatientDisease_DiseaseId })
                .Index(t => t.EmployeeId)
                .Index(t => new { t.PatientDisease_PatientId, t.PatientDisease_DiseaseId });
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Services", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Treatments", new[] { "PatientDisease_PatientId", "PatientDisease_DiseaseId" }, "dbo.PatientDiseases");
            DropForeignKey("dbo.Treatments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Services", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Patients", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.PatientDiseases", "Patient_CardNumber", "dbo.Patients");
            DropForeignKey("dbo.PatientDiseases", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.DiseaseSymptoms", "SymptomId", "dbo.Symptoms");
            DropForeignKey("dbo.DiseaseSymptoms", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Treatments", new[] { "PatientDisease_PatientId", "PatientDisease_DiseaseId" });
            DropIndex("dbo.Treatments", new[] { "EmployeeId" });
            DropIndex("dbo.Services", new[] { "EmployeeId" });
            DropIndex("dbo.Services", new[] { "RoomId" });
            DropIndex("dbo.Patients", new[] { "RoomId" });
            DropIndex("dbo.PatientDiseases", new[] { "Patient_CardNumber" });
            DropIndex("dbo.PatientDiseases", new[] { "DiseaseId" });
            DropIndex("dbo.DiseaseSymptoms", new[] { "SymptomId" });
            DropIndex("dbo.DiseaseSymptoms", new[] { "DiseaseId" });
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Treatments");
            DropTable("dbo.Employees");
            DropTable("dbo.Services");
            DropTable("dbo.Rooms");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientDiseases");
            DropTable("dbo.Symptoms");
            DropTable("dbo.DiseaseSymptoms");
            DropTable("dbo.Diseases");
        }
    }
}
