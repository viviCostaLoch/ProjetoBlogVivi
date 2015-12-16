using BlogVivi.db.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogVivi.db.Classes
{
    public class Post : ClasseBase
    {
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Descricao { get; set; }
        public String Resumo { get; set; }
        public String Titulo { get; set; }
        public Boolean Visivel { get; set; }

        public virtual IList<Visita> Visita { get; set; }
        public virtual IList<PostTag> PostTag { get; set; }
        public virtual IList<Comentario> Comentario { get; set; }
        public virtual IList<Imagem> Imagem { get; set; }
        public virtual IList<Arquivo> Arquivo { get; set; }
    }
}
