using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
   public class Professor
    {
        [BsonElement]
        [BsonId]
        public int Id { get; set; }

        [BsonElement]

        public string Nome { get; set; }

        [BsonElement]

        public string CPF { get; set; }

        [BsonElement]

        public int Identificacao { get; set; }

    }
}
