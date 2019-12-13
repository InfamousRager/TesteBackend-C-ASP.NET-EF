using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteBackend8.Models
{
    public class TesteBackend8Context : DbContext
    {
        public TesteBackend8Context (DbContextOptions<TesteBackend8Context> options)
            : base(options)
        {
        }
        //public DbSet<TesteBackend8.Models.Turma> Turma { get; set; }

        public DbSet<Turma> Turma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }

    }
}
