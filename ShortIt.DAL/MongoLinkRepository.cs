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

        public async Task<IEnumerable<Link>> GetFullLink(string shortUrl)
        {
            var filter = new BsonDocument("shorturl", shortUrl);
            var res = await _db.Links.FindAsync(filter);
            return await res.ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetShortLink(string fullUrl)
        {
            var filter = new BsonDocument("url", fullUrl);
            var res = await _db.Links.FindAsync(filter);
            return await res.ToListAsync();
        }
    }
}
