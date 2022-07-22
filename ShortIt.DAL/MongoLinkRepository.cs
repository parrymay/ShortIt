using MongoDB.Bson;
using ShortIT.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortIt.DAL
{
    public class MongoLinkRepository : IRepository<Link>
    {
        private readonly AppDbContext _db;
        public MongoLinkRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<string> CutUrl(string? url)
        {
            if (url == null) return null;//bad request
            var filter = new BsonDocument("url", url);
            var res = await _db.Links.FindAsync(filter);
            if (res != null) return null;
            //_db.Links.
            return "ok";
        }

        public async Task<string> InsertUrl(string id, string url, string shortUrl)
        {
            if (url == null) return null;
            var filter = new BsonDocument("url", url);
            var res = _db.Links.FindSync(filter).ToListAsync();
            if (res != null) return "Занято";
            await _db.Links.InsertOneAsync
                (
                new Link()
                    {
                        _id = id,
                        url = url,
                        shorturl = shortUrl,
                        createAt = DateTime.Now.ToString()
                    }
                );
            return "ok"; //responce
        }

        public async Task<string> GetFullUrl(string? shortUrl)
        {
            if (shortUrl == null) return null;
            var filter = new BsonDocument("shorturl", shortUrl);
            var res = await _db.Links.FindAsync(filter);
            return res.ToListAsync().Result[0]?.url;
        }

        public async Task<string> GetShortUrl(string? fullUrl)
        {
            if (fullUrl == null) return null;
            var filter = new BsonDocument("url", fullUrl);
            var res = await _db.Links.FindAsync(filter);
            return res.ToListAsync().Result[0]?.shorturl;
        }

        //public async Task<string> GetMaxIncrement()
        //{   
        //    _db.Links.FindAsync(new BsonDocument());
        //    _db.max
        //}
    }
}
