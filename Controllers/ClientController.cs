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
        public IActionResult EditClient(int id)
        {
            ClientModel client =_clienteRepositorio.ListarPorId(id);
            return View(client);
        }
        public IActionResult DeleteClientConfirm(int id)
        {
            ClientModel client = _clienteRepositorio.ListarPorId(id);
            return View(client);
        }
        public IActionResult DeleteClient (int id)
        {
            _clienteRepositorio.DeleteClient(id);
            return RedirectToAction("Index");
        }
        public IActionResult Novo(ClientModel clientModel)
        {
            _clienteRepositorio.Adicionar(clientModel);
            return RedirectToAction("Index");
        }
        public IActionResult Alterar(ClientModel clientModel)
        {
            _clienteRepositorio.Atualizar(clientModel);
            return RedirectToAction("Index");
        }
    }
}
