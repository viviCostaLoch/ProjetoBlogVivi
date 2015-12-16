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
    public class ImagemConfig : EntityTypeConfiguration<Imagem>
    {
        public ImagemConfig()
        {
            ToTable("IMAGEM");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDIMAGEM")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Extensao)
                .HasColumnName("EXTENSAO")
                .IsRequired()
                .HasMaxLength(10);

            Property(x => x.Bytes)
               .HasColumnName("BYTES")
               .IsRequired();
              
            Property(x => x.IdPost)
                 .HasColumnName("IDPOST")
                 .IsRequired();

            HasRequired(x => x.Post)
                .WithMany()
                .HasForeignKey(x => x.IdPost);


        }
    }
}
