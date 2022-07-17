using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShortIT.Domain
{
    public class Link
    {
        [BsonId]
        public string _id { get; set; }

        [Display(Name = "URL")]
        public string url { get; set; }

        [Display(Name = "ShortURL")]
        public string shorturl { get; set; }

        [Display(Name = "Create at")]
        public string createAt { get; set; }
    }
}