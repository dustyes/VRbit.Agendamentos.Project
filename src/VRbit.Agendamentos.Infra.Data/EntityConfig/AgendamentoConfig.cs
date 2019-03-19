using System.Data.Entity.ModelConfiguration;
using VRbit.Agendamentos.Domain.Entities;

namespace VRbit.Agendamentos.Infra.Data.EntityConfig
{
    public class AgendamentoConfig : EntityTypeConfiguration<Agendamento>
    {
        public AgendamentoConfig()
        {
            HasKey(c => c.AgendamentoId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("varchar");

            Property(c => c.DataHoraInicio)
                .IsRequired();

            Property(c => c.DataHoraFim)
                .IsRequired();

            Property(c => c.Endereco)
                .IsRequired();

            Property(c => c.TipoAgendamentoId)
                .IsRequired();

            ToTable("Agendamentos");
        }

    }
}
