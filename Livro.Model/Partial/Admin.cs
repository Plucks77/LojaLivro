using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Livro.Model
{
    [MetadataType(typeof(MD_Admin))]
    public partial class Admin
    {
        internal class MD_Admin
        {
            [DisplayName("Nome")]
            [Required(ErrorMessage = "Preencha o nome.")]
            public string Nome { get; set; }

            [DisplayName("Login")]
            [Required(ErrorMessage = "Preencha o login.")]
            public string Login { get; set; }

            [DisplayName("Senha")]
            [Required(ErrorMessage = "Preencha a senha.")]
            //[DataType(DataType.Password)]
            public string Senha { get; set; }

            [DisplayName("Email")]
            [Required(ErrorMessage = "Preencha o email.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [DisplayName("Telefone")]
            [Required(ErrorMessage = "Preencha o telefone.")]
            [DataType(DataType.PhoneNumber)]
            public string Telefone { get; set; }

        }

    }
}
