using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogVivi.Web.Models.Blog
{
    public class DetalhesPostViewModel
    {
        public int id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime datadepublicacao { get; set; }
        public DateTime horadepublicacao { get; set; }
        public string Resumo { get; set; }
        public string descricao { get; set; }
        public Boolean Visivel { get; set; }
        public List<string> Tags { get; set; }

        /*cadastar comentaio*/
        [DisplayName("Nome")]
        [StringLength(100,ErrorMessage ="o campo deve possuir no máximo {1} caracteres!")]
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string ComentarioNome { get; set; }

        [DisplayName("E-mail")]
        [StringLength(100, ErrorMessage ="O campo E-mail deve possuir {1} caracteres!")]
        [EmailAddress(ErrorMessage ="E-mail invalido!")]
        public string ComentarioEmail { get; set; }
        public string ComentarioDescricao { get; set; }
        public string ComentarioPaginaWeb { get; set; }
    }
}