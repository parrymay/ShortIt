using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ShortIt.DAL;
using ShortIT.Domain;
using ShortIT.Service;
using System.Text.Json;

namespace ShortIt.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly ILogger<LinkController> _logger;
        private readonly IRepository<Link> _repo;
        private readonly IUrlCutter urlCutter;

        public LinkController(ILogger<LinkController> logger, IRepository<Link> linkService)
        {
            _logger = logger;
            _repo = linkService;    
        }

        [HttpGet]
        //[Route("Full")]
        public string? Index(string shortUrl)
        {
            return "hello!";
        }


        [HttpGet]
        //[Route("Full")]
        public string? GetFullUrl(string url)
        {
            var res = _repo.GetFullUrl(url);
            if (res == null)
            {

                //string shortUrl = urlCutter.Encode(id);
                //_repo.InsertUrl(id, url, shortUrl);
            }
            return res?.Result?.ToJson();
        }

        [HttpGet]
        //[Route("Short")]
        public string GetShortUrl(string url)
        {
            var res = _repo.GetShortUrl(url);
            if (res == null)
            {
                //int increment = _repo.
                //string shortUrl = urlCutter.Encode()
            }
            return res.Result.ToJson();
        }
    }
}