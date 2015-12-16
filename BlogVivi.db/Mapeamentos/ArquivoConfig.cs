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
    public class ArquivoConfig : EntityTypeConfiguration<Arquivo>
    {
        public ArquivoConfig()
        {
            ToTable("ARQUIVO");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDARQUIVO")
                 .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Extensao)
               .HasColumnName("EXTENSAO")
               .HasMaxLength(10)
               .IsRequired();

            Property(x => x.Bytes)
               .HasColumnName("BYTES")
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