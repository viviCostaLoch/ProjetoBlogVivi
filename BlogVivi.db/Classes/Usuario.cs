using BlogVivi.db.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogVivi.db.Classes
{
   public class Usuario : ClasseBase

    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
