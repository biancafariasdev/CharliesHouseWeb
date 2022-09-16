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
            try
            {
                bool apagado =_clienteRepositorio.DeleteClient(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente deletado com sucesso";

                }
                else
                {
                    TempData["MensagemErro"] = "Ops! Não conseguimos apagar o seu contato.";

                }
                return RedirectToAction("Index");   
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! Não conseguimos apagar o seu contato. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");

            }


        }
        public IActionResult Novo(ClientModel clientModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(clientModel);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("NewClient");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! Não conseguimos cadastrar o cliente. Por favor tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Alterar(ClientModel clientModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(clientModel);
                    TempData["MensagemSucesso"] = "Cliente atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("EditClient", clientModel);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! Não conseguimos atualizar o cliente. Por favor tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
           
        }
    }
}
