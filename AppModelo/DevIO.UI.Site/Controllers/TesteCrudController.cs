using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Rafael Nascimento",
                DataNascimento = DateTime.Now,
                Email = "rafael@teste.com.br"
            };

            //Add
            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            //Buscar
            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "rafael@teste.com.br");
            var alunos = _contexto.Alunos.Where(a => a.Nome == "Rafael");

            //Atualizar
            aluno.Nome = "Amanda";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();
            
            //Remover
            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View();
        }
    }
}
