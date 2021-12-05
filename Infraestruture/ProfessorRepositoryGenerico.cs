using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infraestruture
{
    public class ProfessorRepositoryGenerico : IProfessorRepository<Professor , int >
    {

        private readonly IMongoCollection<Professor> _collection;


        public ProfessorRepositoryGenerico()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


            var mongoconnectionstring = config.GetSection("CONECTION_STRING").Value;

            MongoClient dbClient = new MongoClient(mongoconnectionstring);

            var database = dbClient.GetDatabase("Professor");
            var collection = database.GetCollection<Professor>("Professor");

            _collection = collection;




        }

        public void create(Professor t)
        {
            _collection.InsertOne(t);
        }

        public Professor get(int id)
        {
            var filter = Builders<Professor>.Filter.Eq("ID", id);


            var retorno = _collection.Find(filter).ToList().FirstOrDefault();

            if (retorno == null)
            {
                throw new NullReferenceException("Objeto é nulo");
            }


            return retorno;

        }

        public void delete(int id)
        {

            var filter = Builders<Professor>.Filter.Eq("Id", id);

            _collection.DeleteOne(filter);
        }

        public void Update(Professor t, int x)
        {
            var filter = Builders<Professor>.Filter.Eq("Id", t.Id);
            var filter2 = Builders<Professor>.Update.Set("Id", t.Id).Set("Nome", t.Nome).Set("CPF", t.CPF).Set("Identificacao", t.Identificacao);

            _collection.UpdateOne(filter, filter2);

        }


    }
}
