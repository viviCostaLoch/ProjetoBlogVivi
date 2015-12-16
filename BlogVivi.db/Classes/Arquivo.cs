using BlogVivi.db.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogVivi.db.Classes
{
  public  class Arquivo : ClasseBase
    {
       
        public string Nome { get; set; }
        public string Extensao { get; set; }
        public byte [] Bytes { get; set; }
        public int IdPost { get; set; }

        public virtual Post Post { get; set; }
    }
}
