using ShortIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortIt.DAL
{
    public interface IRepository<T> 
        where T : class
    {
        public Task<string> GetFullUrl(string? shortUrl);
        public Task<string> GetShortUrl(string? fullUrl);
        public Task<string> CutUrl(string? url);
        public Task<string> InsertUrl(string id, string url, string shortUrl);
    }
}
