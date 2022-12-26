using CharliesHouseWeb.Data;
using CharliesHouseWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _dataContext;
        public UsuarioRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public UserModel Adicionar(UserModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _dataContext.Users.Add(usuario);
            _dataContext.SaveChanges();
            return usuario;
        }
        public UserModel ListarPorId(int id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }
        public List<UserModel> BuscarTodos()
        {
            return _dataContext.Users
            .Include(x => x.Clientes)
            .ToList();
        }
        public UserModel Atualizar(UserModel usuario)
        {
            UserModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário.");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _dataContext.Update(usuarioDB);
            _dataContext.SaveChanges();

            return usuarioDB;
        }
        public UserModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UserModel usuariodb = ListarPorId(alterarSenhaModel.Id);
            if (usuariodb == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado");

            if (!usuariodb.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere.");

            if (usuariodb.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual.");

            usuariodb.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuariodb.DataAtualizacao = DateTime.Now;

            _dataContext.Users.Update(usuariodb);
            _dataContext.SaveChanges();

            return usuariodb;
        }
        public bool DeleteUser(int id)
        {
            UserModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new Exception("Houve um erro ao deletar o usuário.");

            _dataContext.Users.Remove(usuarioDB);
            _dataContext.SaveChanges();

            return true;

        }

        public UserModel BuscarPorLogin(string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel BuscarPorEmailLogin(string email, string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }
    }
}
