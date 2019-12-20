using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TesteBackend8.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ter entre {2} e {1}")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} Requerido")]
        [Display(Name = "Nota1")]
        public double Nota1 { get; set; }
        [Required(ErrorMessage = "{0} Requerido")]
        [Display(Name = "Nota2")]
        public double Nota2 { get; set; }
        [Required(ErrorMessage = "{0} Requerido")]
        [Display(Name = "Nota3")]
        public double Nota3 { get; set; }
        [Display(Name = "Nota4")]
        public Nullable<double> Nota4 { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public double Media { get; set; }


        public Aluno()
        {
        }

        public Aluno(int id, string nome, double nota1, double nota2, double nota3, double nota4, Turma turma,double media)
        {
            Id = id;
            Nome = nome;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            Nota4 = nota4;
            Turma = turma;
            Media = media;
         
            
        }
       
        public double calcMedia(double nota1,double nota2,double nota3,double nota4,double media)
        {
            media = 0;
            return  Media = (nota1 + nota2 + nota3 + nota4) / 4;
        }


       


    }
}
