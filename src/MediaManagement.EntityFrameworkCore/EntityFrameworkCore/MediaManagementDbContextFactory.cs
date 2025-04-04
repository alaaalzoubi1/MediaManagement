using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MediaManagement.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class MediaManagementDbContextFactory : IDesignTimeDbContextFactory<MediaManagementDbContext>
{
    public MediaManagementDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        MediaManagementEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<MediaManagementDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);
        
        return new MediaManagementDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MediaManagement.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
