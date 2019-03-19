using System;
using System.Collections.Generic;
using VRbit.Agendamentos.Application.ViewModels;

namespace VRbit.Agendamentos.Application.Interfaces
{
    public interface ITipoAgendamentoAppService : IDisposable
    {

        TipoAgendamentoViewModel Adicionar(TipoAgendamentoViewModel tipoAgendamentoViewModel);
        IEnumerable<TipoAgendamentoViewModel> ObterTodos();
        TipoAgendamentoViewModel Atualizar(TipoAgendamentoViewModel tipoAgendamentoViewModel);
        TipoAgendamentoViewModel SelecionarPorId(Guid id);
        void Remover(Guid id);
    }
}
