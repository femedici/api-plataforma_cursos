using MongoDB.Driver;

public class MeuMongo
{
    public IMongoDatabase DB {get;}

    public MeuMongo(IConfiguration configuration)
    {
        try
        {
            var client = new MongoClient(configuration["ConnectionStrings:MeuMongo"]);
            DB = client.GetDatabase("meuDB");
        }
        catch (Exception ex)
        {
            throw new MongoException("Não foi possivel se conectar ao MongoDB", ex);
        }
    }
}