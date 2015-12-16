using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogVivi.Web.Models.Usuarios
{
    public class CadastrarUsuariosViewModel
    {
        [DisplayName("Código")]
        public int id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Campo Nome é  obrigatorio")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "A quantidade de caracteres no campo deve ser entre {2} e {1}")]
        public string Nome { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "O Campo Login é  obrigatorio")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "A quantidade de caracteres no campo deve ser entre {2} e {1}")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O Campo  Senha  obrigatorio")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A quantidade de caracteres no campo deve ser entre {2} e {1}")]
        public string Senha { get; set; }

        [DisplayName("Confirmar Senha")]
        [Required(ErrorMessage = "O Campo  confirmar Senha  obrigatorio")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A quantidade de caracteres no campo deve ser entre {2} e {1}")]
        [Compare("Senha", ErrorMessage = "O campo senha é obrigatório.")]
        public string ConfirmarSenha { get; set; }

    }
}