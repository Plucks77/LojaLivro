using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model
{
    [MetadataType(typeof(MD_Cliente))]
    public partial class Cliente
    {
        internal class MD_Cliente
        {           
            public int ID { get; set; }

            [DisplayName("Nome")]
            [Required(ErrorMessage ="Preencha o nome.")]
            public string Nome { get; set; }

            [DisplayName("Login")]
            [Required(ErrorMessage = "Preencha o Login.")]
            public string Login { get; set; }

            [DisplayName("Senha")]
            [Required(ErrorMessage = "Preencha a senha.")]
            [DataType(DataType.Password)]
            public string Senha { get; set; }

            [DisplayName("Telefone")]
            [Required(ErrorMessage = "Preencha o telefone.")]
            [DataType(DataType.PhoneNumber)]
            public string Telefone { get; set; }

            [DisplayName("Email")]
            [Required(ErrorMessage = "Preencha o email.")]   
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [DisplayName("Endereço")]
            [Required(ErrorMessage = "Preencha o endereço.")]
            public string Endereco { get; set; }

            [DisplayName("CPF")]
            [Required(ErrorMessage = "Preencha o CPF.")]            
            public string CPF { get; set; }
        }
    }
}
