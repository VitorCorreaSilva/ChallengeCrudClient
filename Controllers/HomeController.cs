using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudChallengeClient.Models;

namespace CrudChallengeClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            LivroModel objLivro = new LivroModel();
            ViewBag.ListaLivros = objLivro.ListarTodosLivros();

            return View();
        }

        [HttpGet]
        public IActionResult Registrar(int? id)
        {
            if (id != null)
            {
                ViewBag.Registro = new LivroModel().Carregar(id);
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["ClienteID"] = id.ToString();
            return View();
        }

        public IActionResult ExcluirLivro(int id)
        {
            new LivroModel().Excluir(id);
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(LivroModel dados)
        {
            dados.Inserir();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
