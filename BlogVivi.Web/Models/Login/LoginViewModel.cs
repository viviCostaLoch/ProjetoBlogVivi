using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogVivi.Web.Models.Login
{
    public class LoginViewModel
    {
        [DisplayName("Login")]
        [Required(ErrorMessage = "O Campo Login é  obrigatorio")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O Campo Senha  obrigatorio")]
        [DataType(DataType.Password)]
        public string senha { get; set; }

        [DisplayName("Lembrar")]
        public bool Lembrar { get; set; }
    }
}