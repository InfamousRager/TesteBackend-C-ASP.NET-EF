using System.Collections.Generic;


namespace TesteBackend8.Models.ViewModels
{
    public class AlunoFormViewModel
    {
        public Aluno Aluno { get; set; }
        public ICollection<Turma> Turmas{ get; set; }
    }
}
