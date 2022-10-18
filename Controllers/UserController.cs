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
        public IActionResult DeleteUserConfirm(int id)
        {
            UserModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult DeleteUser(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.DeleteUser(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário deletado com sucesso";

                }
                else
                {
                    TempData["MensagemErro"] = "Ops! Não conseguimos apagar o seu usuário.";

                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! Não conseguimos apagar o seu usuário. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");

            }


        }
        public IActionResult EditUser(int id)
        {
            UserModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Alterar(UserSemSenhaModel userSemSenhaModel)
        {
            try
            {
                UserModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UserModel()
                    {
                        Id = userSemSenhaModel.Id,
                        Nome = userSemSenhaModel.Nome,
                        Login = userSemSenhaModel.Login,
                        Email = userSemSenhaModel.Email,
                        Perfil = userSemSenhaModel.Perfil
                    };
                    usuario=_usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops! Não conseguimos atualizar o usuário. Por favor tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
