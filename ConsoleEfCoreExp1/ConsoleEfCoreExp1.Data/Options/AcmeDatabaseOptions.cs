using System.ComponentModel.DataAnnotations;

namespace ConsoleEfCoreExp1.Data;

public class AcmeDatabaseOptions
{
    [Required]
    public string ConnectionString { get; set; }
    public bool RunMigrationsOnStartup { get; set; } = false;
}