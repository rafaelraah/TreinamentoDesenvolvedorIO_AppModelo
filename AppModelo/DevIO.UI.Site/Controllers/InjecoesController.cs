using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class InjecoesController : Controller
    {
        public OperacaoService OperacaoService1 { get; }
        public OperacaoService OperacaoService2 { get; }

        public InjecoesController(OperacaoService operacaoService1, OperacaoService operacaoService2)
        {
            OperacaoService1 = operacaoService1;
            OperacaoService2 = operacaoService2;
        }

        public IActionResult Index()
        {
            string PrimeiraInstancia = "Primeira Instância" +
                                       "\nTransient: " + OperacaoService1.Transient.OperacaoID +
                                       "\nScoped: " + OperacaoService1.Scoped.OperacaoID +
                                       "\nSingleton: " + OperacaoService1.Singleton.OperacaoID +
                                       "\nSingleton Instance: " + OperacaoService1.SingletonInstance.OperacaoID;

            string SegundaInstancia = "\n\nSegunda Instância" +
                                        "\nTransient: " + OperacaoService2.Transient.OperacaoID +
                                        "\nScoped: " + OperacaoService2.Scoped.OperacaoID +
                                        "\nSingleton: " + OperacaoService2.Singleton.OperacaoID +
                                        "\nSingleton Instance: " + OperacaoService2.SingletonInstance.OperacaoID;

            
            string retorno = PrimeiraInstancia + Environment.NewLine + SegundaInstancia;
            return View(model: retorno);
        }
    }
}