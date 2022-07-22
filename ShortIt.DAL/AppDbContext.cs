using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using ShortIT.Domain;

namespace ShortIt.DAL
{
    public class AppDbContext : IDbContext
    {
        private IMongoDatabase db;
        public IMongoCollection<Link> Links;
        public IMongoCollection<string> MaxIncrement;

        public AppDbContext()
        {
            string connectionString = "mongodb://localhost/ShortIT";
            string dbName = "ShortIT";
            string linkCollectionName = "Links";
            string incrementCollectionName = "MaxIncrement";

            MongoClient client = new MongoClient(connectionString);
            db = client.GetDatabase(dbName);
            Links = db.GetCollection<Link>(linkCollectionName);
            MaxIncrement = db.GetCollection<string>(incrementCollectionName);
        }
        //public async Task<List<Link>> GetLinks()
        //{
        //    var builder = new FilterDefinitionBuilder<Link>();
        //    var filter = builder.Empty;
        //    var res = await Links.FindAsync(new BsonDocument());
        //    return res.ToList();
        //}
    }
}   