using CharliesHouseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CharliesHouseWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar (LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if(loginModel.Login == "adm" && loginModel.Senha == "123")
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    TempData["MensagemErro"] = $"Ops! Não conseguimos seu login. Tente novament";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos seu login. Tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
