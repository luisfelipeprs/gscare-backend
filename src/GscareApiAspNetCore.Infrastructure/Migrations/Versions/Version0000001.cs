using FluentMigrator;

namespace GscareApiAspNetCore.Infrastructure.Migrations.Versions;

[Migration(1, "Create table to sabe the user's information")]
//public class Version0000001 : ForwardOnlyMigration
public class Version0000001 : VersionBase
{
    public override void Up()
    {
        CreateTable("Users_Test")
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable();
    }
}
