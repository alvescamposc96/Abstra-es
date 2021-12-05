using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infraestruture.Repository
{
   public abstract class AbstracoesProfessorRepository<T>
    {
        public readonly IMongoCollection<T> _collection;



        public AbstracoesProfessorRepository()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


            var mongoconnectionstring = config.GetSection("CONECTION_STRING").Value;

            MongoClient dbClient = new MongoClient(mongoconnectionstring);

            var database = dbClient.GetDatabase(typeof(T).ToString());
            var collection = database.GetCollection<T>(typeof(T).ToString());

            _collection = collection;
        }
    }
}
