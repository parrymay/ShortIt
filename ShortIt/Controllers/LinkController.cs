using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ShortIt.DAL;
using ShortIT.Domain;
using System.Text.Json;

namespace ShortIt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly ILogger<LinkController> _logger;
        private readonly IRepository<Link> _repo;

        public LinkController(ILogger<LinkController> logger, IRepository<Link> linkService)
        {
            _logger = logger;
            _repo = linkService;
        }

        [HttpGet]
        public string GetFullLink(string fullLink)
        {
            var res = _repo.GetFullLink(fullLink);
            return res.Result.ToJson();
        }

        public string GetShortLink(string shotrLink)
        {
            var res = _repo.GetShortLink(shotrLink);
            return res.Result.ToJson();
        }
    }
}