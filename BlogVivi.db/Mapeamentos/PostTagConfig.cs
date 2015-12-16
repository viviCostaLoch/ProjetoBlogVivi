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
    class PostTagConfig : EntityTypeConfiguration<PostTag>
    {
        public PostTagConfig()
        {
            ToTable("POSTTAG");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDTAGPOST")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdTag)
                .HasColumnName("IDTAG")
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.IdPost)
                .HasColumnName("IDPOST")
                .IsRequired();

            HasRequired(x => x.Post)
                .WithMany()
                .HasForeignKey(x => x.IdPost);

            HasRequired(x => x.TagClass)
               .WithMany()
               .HasForeignKey(x => x.IdTag);






        }
    }
}
