using BibliotecaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BibliotecaAPI.Services;

public class LivrosService
{
    private readonly IMongoCollection<Livro> _livrosCollection;

    public LivrosService(
        IOptions<BibliotecaDatabaseSettings> bibliotecaDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bibliotecaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bibliotecaDatabaseSettings.Value.DatabaseName);

        _livrosCollection = mongoDatabase.GetCollection<Livro>(
            bibliotecaDatabaseSettings.Value.LivrosCollectionName);
    }

    public async Task<List<Livro>> GetAsync() =>
        await _livrosCollection.Find(_ => true).ToListAsync();

    public async Task<Livro?> GetAsync(string id) =>
        await _livrosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Livro newLivro) =>
        await _livrosCollection.InsertOneAsync(newLivro);

    public async Task UpdateAsync(string id, Livro updatedLivro) =>
        await _livrosCollection.ReplaceOneAsync(x => x.Id == id, updatedLivro);

    public async Task RemoveAsync(string id) =>
        await _livrosCollection.DeleteOneAsync(x => x.Id == id);
}