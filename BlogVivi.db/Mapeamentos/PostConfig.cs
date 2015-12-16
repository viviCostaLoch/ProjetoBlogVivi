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
    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            ToTable("POST");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDPOST")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Autor)
                .HasColumnName("AUTOR")
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.DataPublicacao)
                .HasColumnName("DATAPUBLICACAO")
                .IsRequired();

            Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();

            Property(x => x.Resumo)
                .HasColumnName("RESUMO")
                .IsRequired()
                .HasMaxLength(1000);

            Property(x => x.Titulo)
                .HasColumnName("TITULO")
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Visivel)
                .HasColumnName("VISIVEL")
                .IsRequired();

           HasMany(x => x.Arquivo)
                .WithOptional()
                .HasForeignKey(x => x.IdPost) ;

            HasMany(x => x.Imagem)
               .WithOptional()
               .HasForeignKey(x => x.IdPost);

            HasMany(x => x.PostTag)
               .WithOptional()
               .HasForeignKey(x => x.IdPost);

            HasMany(x => x.Visita)
               .WithOptional()
               .HasForeignKey(x => x.IdPost);

            HasMany(x => x.Comentario)
               .WithOptional()
               .HasForeignKey(x => x.IdPost);


        }
    }
}
