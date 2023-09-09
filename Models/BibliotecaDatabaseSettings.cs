namespace BibliotecaAPI.Models;

public class BibliotecaDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string LivrosCollectionName { get; set; } = null!;
}