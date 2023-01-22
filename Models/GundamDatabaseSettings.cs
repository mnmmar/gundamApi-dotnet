namespace GundamApi.Models;

public class GundamDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    
    public string DatabaseName { get; set; } = null!;

    public string GundamsCollectionName { get; set; } = null!;
}