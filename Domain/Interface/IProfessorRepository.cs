using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public interface  IProfessorRepository <T, X>
    {
        public void create(T t);

        public T get(X x);

        public void delete(X x);

        public void Update(T t, X x);

    }
}
