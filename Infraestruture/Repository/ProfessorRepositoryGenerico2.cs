using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using MongoDB.Driver;

namespace Infraestruture.Repository
{
    public class ProfessorRepositoryGenerico2 : AbstracoesProfessorRepository<Professor> , IProfessorRepository<Professor, int> 

    {
        public void create(Professor t)
        {
            _collection.InsertOne(t);
        }

        public void delete(int id)
        {
            var filter = Builders<Professor>.Filter.Eq("Id", id);

            _collection.DeleteOne(filter);
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

        public void Update(Professor t, int x)
        {
            var filter = Builders<Professor>.Filter.Eq("Id", t.Id);
            var filter2 = Builders<Professor>.Update.Set("Id", t.Id).Set("Nome", t.Nome).Set("CPF", t.CPF).Set("Identificacao", t.Identificacao);

            _collection.UpdateOne(filter, filter2);
        }
    }
    
}
