using CharliesHouseWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Helper
{
   public interface ISessao
    {
        void CriarSessao(UserModel usuario);
        void RemoverSessaoUsuario();
        UserModel BuscarSessaoUsuario();
    }
}
