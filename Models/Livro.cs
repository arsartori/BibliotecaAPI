using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BibliotecaAPI.Models;

public class Livro
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Titulo")]
    public string Titulo { get; set; } = null!;

    public decimal Valor { get; set; }

    public string Categoria { get; set; } = null!;

    public string Autor { get; set; } = null!;
}