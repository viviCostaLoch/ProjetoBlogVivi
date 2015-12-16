using BlogVivi.db.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogVivi.db.Classes
{
    public class PostTag : ClasseBase
    {
        public String IdTag { get; set; }
        public int IdPost { get; set; }

        public virtual Post Post { get; set; }
        public virtual TagClass TagClass { get; set; }
    }
}
