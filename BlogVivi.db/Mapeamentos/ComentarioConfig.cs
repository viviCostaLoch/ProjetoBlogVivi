using BlogVivi.db.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogVivi.db.Mapeamentos
{
    public class ComentarioConfig : EntityTypeConfiguration<Comentario>
    {
        public ComentarioConfig()
        {
            ToTable("COMENTARIO");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDCOMENTARIO")
                 .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();

            Property(x => x.AdmPost)
               .HasColumnName("ADMPOST")
               .IsRequired();

            Property(x => x.Email)
               .HasColumnName("EMAIL")
               .HasMaxLength(100);

            Property(x => x.PaginaWeb)
               .HasColumnName("PAGINAWEB")
               .HasMaxLength(100);

            Property(x => x.Nome)
               .HasColumnName("NOME")
               .HasMaxLength(100)
               .IsRequired();

            Property(x => x.IdPost)
              .HasColumnName("IDPOST")
              .IsRequired();

            HasRequired(X => X.Post)// especifica se a chave é obrigatoria
            .WithMany()// definiu que tem muitos arquivos para o post
            .HasForeignKey(x => x.IdPost);







        }
    }
}
