using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackend8.Models;

namespace TesteBackend8.Data
{
    public class SeedingService
    {
        private TesteBackend8Context _context;

        public SeedingService(TesteBackend8Context context)
        {
            _context = context;
        }

        public void Seed()
        {

            if (_context.Turma.Any() ||
                _context.Aluno.Any())
            {
                return; // verificando se tem algum dado na db
            }

            Turma t1 = new Turma(1, "Turma 1");
            Turma t2 = new Turma(2, "Turma 2");
            Turma t3 = new Turma(3, "Turma 2");

            Aluno a1 = new Aluno(1, "Teste1", 5.1, 6.2, 7.3, 8.4,t1);
            Aluno a2 = new Aluno(2, "Teste2", 5.2, 6.3, 7.4, 8.5,t2);
            Aluno a3 = new Aluno(3, "Teste3", 5.3, 6.4, 7.5, 8.6,t3);
            Aluno a4 = new Aluno(4, "Teste4", 5.4, 6.5, 7.6, 8.7, t1);
            Aluno a5 = new Aluno(5, "Teste5", 5.5, 6.6, 7.7, 8.8,t2);
            Aluno a6 = new Aluno(6, "Teste6", 5.6, 6.7, 7.8, 8.9,t3);

            _context.Turma.AddRange(t1, t2, t3);
            _context.Aluno.AddRange(a1, a2, a3, a4, a5, a6);

            _context.SaveChanges();


        }
    }
}
