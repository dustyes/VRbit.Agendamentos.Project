using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using VRbit.Agendamentos.Domain.Entities;

namespace VRbit.Agendamentos.Infra.Data.EntityConfig
{
    //FLUENT API

    public class TipoAgendamentoConfig : EntityTypeConfiguration<TipoAgendamento>
    {
        public TipoAgendamentoConfig()
        {
            HasKey(c => c.TipoAgendamentoId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("varchar");

            Property(c => c.Interno)
                .IsRequired();

            ToTable("TipoAgendamentos");

        }
    }
}
