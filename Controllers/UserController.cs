using CharliesHouseWeb.Models;
using CharliesHouseWeb.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UserController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UserModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Novo(UserModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! Não conseguimos cadastrar o cliente. Por favor tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
