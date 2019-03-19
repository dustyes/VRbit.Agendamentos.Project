using System;

namespace VRbit.Agendamentos.Domain.Entities
{
    public class Agendamento
    {
        public Agendamento()
        {
            AgendamentoId = Guid.NewGuid();
        }

        public Guid AgendamentoId { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

        public Guid ApplicationUserId { get; set; }
        public Guid TipoAgendamentoId { get; set; }
        public Guid? ClienteId { get; set; }

        public virtual object ApplicationUser { get; set; } //ApplicationUser in other projects
        //https://softwareengineering.stackexchange.com/questions/276571/separating-asp-net-identityuser-from-my-other-entities
        //http://blog.rebuildall.net/2013/10/22/Moving_ASP_NET_Identity_model_into_another_assembly
        //https://stackoverflow.com/questions/38669833/moving-applicationuser-and-other-models-out-of-mvc-project
        public virtual TipoAgendamento TipoAgendamento { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
