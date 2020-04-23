using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository; //Teste no construtor
        private IPedidoRepository _pedidoRepository2; //Teste na action

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            var pedido = _pedidoRepository.ObterPedido();
            return View();
        }

        /*Apenas por fins de conhecimento, também é possível utilizar o FromService diretamente na Action, ao invés da chamada no construtor.
          Não sendo recomendado, apenas em situações muito específicas quando não se pode alterar um construtor, por exemplo.*/
        [Route("Index2")]
        [Route("[controller]/Index2")]
        public IActionResult Index2([FromServices] IPedidoRepository pedidoRepository2)
        {
            _pedidoRepository2 = pedidoRepository2;
            var pedido = _pedidoRepository.ObterPedido();
            return View("Index");
        }

    }
}
