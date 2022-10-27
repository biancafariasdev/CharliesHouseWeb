using CharliesHouseWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (String.IsNullOrEmpty(sessaoUsuario)) return null;

            UserModel usuario = JsonConvert.DeserializeObject<UserModel>(sessaoUsuario);

            return View(usuario);

        }

    }
}
