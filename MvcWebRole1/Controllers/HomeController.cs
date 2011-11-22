using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.StorageClient;
using MvcWebRole1.Models;

namespace MvcWebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            DataSource ds = new DataSource();
            DateTime data = System.DateTime.UtcNow.Date;
            List<Contato> contatos = (from c in ds.Contexto.Contato select c)
                // REMOVER A LINHA ABAIXO PARA O PRIMEIRO TESTE
                .Where(p => p.Data >= data)
                .ToList();
            return View(contatos);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarRegistros(FormCollection collection)
        {
            string botao = collection["criarRegistros"];
            Contato contato = new Contato 
            {
                Nome = "Contato " + System.Guid.NewGuid(),
                Telefone = "Telefone " + System.Guid.NewGuid()
            };
            switch (botao)
            {
                case "Criar registros sem data":
                    break;
                case "Criar registros com data":
                    // REMOVER A LINHA ABAIXO PARA O PRIMEIRO TESTE
                    contato.Data = System.DateTime.UtcNow.Date;
                    break;
            }
            DataSource ds = new DataSource();
            ds.Contexto.AddObject("Contato", contato);
            ds.Contexto.SaveChanges();
            return RedirectToAction("");
        }
    }
}
