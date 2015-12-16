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
    class VisitaConfig : EntityTypeConfiguration<Visita>
    {
        public VisitaConfig()
        {
            ToTable("VISITA");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDVISITA")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Ip)
                .HasColumnName("IP")
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.DataHora)
                .HasColumnName("DATAHORA")
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
