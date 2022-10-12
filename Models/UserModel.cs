using CharliesHouseWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuário")]
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
