using CharliesHouseWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Repositorio
{
    public interface IClienteRepositorio
    {
        ClientModel ListarPorId(int id);
        List<ClientModel> BuscarTodos();
        ClientModel Adicionar(ClientModel cliente);
        ClientModel Atualizar(ClientModel client);
        bool DeleteClient(int id);

    }
}
