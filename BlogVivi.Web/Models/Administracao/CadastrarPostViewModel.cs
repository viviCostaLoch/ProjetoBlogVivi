using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogVivi.Web.Models.Administracao
{
    public class CadastrarPostViewModel

    {
        [DisplayName("Código")]
        public int id { get; set; }

       [DisplayName("Titulo")]
       [Required(ErrorMessage ="O Campo titulo é  obrigatorio")]
       [StringLength(100,MinimumLength =2,ErrorMessage ="A quantidade de caracteres no campo deve ser entre {2} e {1}")]
        public string Titulo { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "O Campo Autor é  obrigatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A quantidade de caracteres no campo deve ser entre {2} e {1}")]
        public string Autor { get; set; }

        [DisplayName("Data de Publicação")]
        [Required(ErrorMessage = "O Campo ~data de publicação é  obrigatorio")]
        public DateTime datadepublicacao { get; set; }

        [DisplayName("Hora de Publicação")]
        [Required(ErrorMessage = "O Campo hora de publicação é  obrigatorio")]
        public DateTime horadepublicacao { get; set; }

        [DisplayName("Resumo")]
        [Required(ErrorMessage = "O Campo Resumo é  obrigatorio")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "A quantidade de caracteres no campo deve ser entre {2} e {1}")]
        public string Resumo { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O Campo Descrição é  obrigatorio")]
        public string descricao { get; set; }

        [DisplayName("Visivel")]
        [Required(ErrorMessage = "O Campo visivel é  obrigatorio")]
        public Boolean Visivel { get; set; }

        public List<string> Tags { get; set; }
    }
}