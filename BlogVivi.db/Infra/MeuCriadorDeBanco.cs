using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogVivi.db.Infra
{
  public  class MeuCriadorDeBanco : DropCreateDatabaseAlways<ConexaoBanco>// mudar o dropcreate database
    {
        protected override void Seed(ConexaoBanco context)
        {
            context.Usuarios.Add(new Classes.Usuario { Login = "ADM", Nome = "Administrador", Senha = "admin" });
            base.Seed(context);
        }
    }
}
