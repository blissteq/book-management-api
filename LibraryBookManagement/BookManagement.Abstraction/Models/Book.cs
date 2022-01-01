using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Abstraction.Models
{
    [DataContract]
   public class Book
    {
        [BsonId]
     
        [DataMember]
        public string Id { get; set; }
        [BsonElement("Name")]
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int PublishYear { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public string ImageFile { get; set; }
        [DataMember]
        public decimal Price { get; set; }

    }
}
