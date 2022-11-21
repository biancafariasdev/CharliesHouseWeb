using CharliesHouseWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UserModel BuscarPorLogin(string login);
        UserModel BuscarPorEmailLogin(string email, string login);
        UserModel ListarPorId(int id);
        List<UserModel> BuscarTodos();
        UserModel Adicionar(UserModel user);
        UserModel Atualizar(UserModel user);
        UserModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool DeleteUser(int id);

    }
}
