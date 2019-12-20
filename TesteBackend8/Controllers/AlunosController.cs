using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteBackend8.Models;
using TesteBackend8.Models.ViewModels;
using TesteBackend8.Services;
using TesteBackend8.Services.Exceptions;

namespace TesteBackend8.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AlunoService _alunoService;
        private readonly TurmaService _turmaService;


        public AlunosController(AlunoService alunoService, TurmaService turmaService)
        {
            _alunoService = alunoService;
            _turmaService = turmaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _alunoService.FindAllAsync();  //aqui a gente lista os alunos
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var turmas = await _turmaService.FindAllAsync();
            var viewModel = new AlunoFormViewModel { Turmas = turmas };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                var  turmas = await _turmaService.FindAllAsync();
                var viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
                return View(viewModel);
            }
            await _alunoService.InsertAsync(aluno);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error),new { message = "Id não foi fornecido" });
            }

            var obj = await _alunoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _alunoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int?id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" }); 
            }

            var obj = await _alunoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" }); 
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var obj = await _alunoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Turma> turmas = await _turmaService.FindAllAsync();
            AlunoFormViewModel viewModel = new AlunoFormViewModel { Aluno = obj, Turmas = turmas };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id,Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                var turmas = await _turmaService.FindAllAsync();
                var viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
                return View(viewModel);
            }

            if (id!=aluno.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não se correspondem" });
            }
            try
            {
                await _alunoService.UpdateAsync(aluno);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            /*catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }*/
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
