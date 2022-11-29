using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do cliente")]
        public string ClientName { get; set; }
        [Required(ErrorMessage ="Digite o e-mail do cliente")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é válido.")]
        public string ClientEmail { get; set; }
        [Phone(ErrorMessage = "O e-mail informado não é válido.")]
        [Required(ErrorMessage ="Digite o contato do cliente")]
        public string ClientContact { get; set; }
        public int? UserId { get; set; }
        public UserModel Usuario { get; set; }

    }
}
