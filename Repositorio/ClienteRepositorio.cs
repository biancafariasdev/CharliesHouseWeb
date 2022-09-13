using CharliesHouseWeb.Data;
using CharliesHouseWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DataContext _dataContext;
        public ClienteRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public ClientModel Adicionar(ClientModel client)
        {
            _dataContext.Client.Add(client);
            _dataContext.SaveChanges();
            return client;
        }

        public List<ClientModel> BuscarTodos()
        {
            return _dataContext.Client.ToList();
        }
    }
}
