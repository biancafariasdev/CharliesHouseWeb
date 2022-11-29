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
        public ClientModel ListarPorId(int id)
        {
            return _dataContext.Client.FirstOrDefault(x => x.Id == id);
        }
        public List<ClientModel> BuscarTodos(int id)
        {
            return _dataContext.Client.Where(x => x.Id == id).ToList();
        }
        public ClientModel Atualizar(ClientModel client)
        {
            ClientModel clientDB = ListarPorId(client.Id);
            if (clientDB == null) throw new Exception("Houve um erro na atualização do cliente.");

            clientDB.ClientName = client.ClientName;
            clientDB.ClientEmail = client.ClientEmail;
            clientDB.ClientContact = client.ClientContact;

            _dataContext.Update(clientDB);
            _dataContext.SaveChanges();

            return clientDB;
        }
        public bool DeleteClient(int id)
        {
            ClientModel clientDB = ListarPorId(id);
            if (clientDB == null) throw new Exception("Houve um erro ao deletar o cliente.");

            _dataContext.Client.Remove(clientDB);
            _dataContext.SaveChanges();

            return true;

        }
    }
}
