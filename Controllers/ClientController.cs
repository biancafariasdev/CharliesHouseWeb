using CharliesHouseWeb.Models;
using CharliesHouseWeb.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClientController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public IActionResult Index()
        {
            List<ClientModel> ListClient =_clienteRepositorio.BuscarTodos();
            return View(ListClient);
        }
        public IActionResult NewClient()
        {
            return View();
        }
        public IActionResult EditClient()
        {
            return View();
        }
        public IActionResult DeleteClientConfirm()
        {
            return View();
        }
        public IActionResult Novo(ClientModel clientModel)
        {
            _clienteRepositorio.Adicionar(clientModel);
            return RedirectToAction("Index");
        }

    }
}
