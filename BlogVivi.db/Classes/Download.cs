using BlogVivi.db.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogVivi.db.Classes
{
   public  class Download : ClasseBase
    {
        public string Ip { get; set; }
        public DateTime DataHora { get; set; }
        public int IdArquivo { get; set; }



        public virtual Arquivo Arquivo { get; set; }

    }

}
