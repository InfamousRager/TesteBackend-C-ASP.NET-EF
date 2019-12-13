using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackend8.Models;
using Microsoft.EntityFrameworkCore;

namespace TesteBackend8.Services
{
    public class TurmaService
    {
        private readonly TesteBackend8Context _context;


        public TurmaService(TesteBackend8Context context)
        {
            _context = context;
        }

        public async Task<List<Turma>> FindAllAsync()
        {
            return  await _context.Turma.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
