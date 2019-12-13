using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackend8.Models;
using Microsoft.EntityFrameworkCore;
using TesteBackend8.Services.Exceptions;

namespace TesteBackend8.Services
{
    public class AlunoService
    {
        private readonly TesteBackend8Context _context;


        public AlunoService(TesteBackend8Context context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> FindAllAsync()
        {
            return await _context.Aluno.ToListAsync(); //acessa a db de alunos e converte pra uma lista 
        }

        public async Task InsertAsync(Aluno obj)
        {
            //obj.Turma = _context.Turma.First();
            _context.Add(obj);  //adicionando aluno na db
           await  _context.SaveChangesAsync(); //salvando
        }

        public async Task<Aluno> FindByIdAsync(int id)
        {
            return await _context.Aluno.Include(obj => obj.Turma).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aluno obj)
        {
            bool hasAny = await _context.Aluno.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id Not Found.");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }

            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
