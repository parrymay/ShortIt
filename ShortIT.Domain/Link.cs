using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShortIT.Domain
{
    public class Link
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string inctrement { get; set; }
        
        public string visitCount { get; set; }

        public string url { get; set; }

        public string shorturl { get; set; }

        public string createAt { get; set; }
    }
}