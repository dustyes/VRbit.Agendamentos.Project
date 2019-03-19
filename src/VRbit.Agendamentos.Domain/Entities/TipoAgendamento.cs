using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRbit.Agendamentos.Domain.Entities
{
    public class TipoAgendamento
    {
        public TipoAgendamento()
        {
            TipoAgendamentoId = Guid.NewGuid();
        }

        public Guid TipoAgendamentoId { get; set; }
        public string Descricao { get; set; }
        public bool Interno { get; set; }

    }
}
