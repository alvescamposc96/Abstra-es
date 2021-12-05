using System;
using Domain;
using Infraestruture;

namespace Abstracoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Professor professor = new Professor();
            ProfessorRepositoryGenerico professorgenerico = new ProfessorRepositoryGenerico();

            professor.Id = 1;
            professor.Nome = "Cris";
            professor.CPF = "1234567890";
            professor.Identificacao = 9087;



            professorgenerico.create(professor);
        }
    }
}
