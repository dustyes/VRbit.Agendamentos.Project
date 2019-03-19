using AutoMapper;
using System;
using System.Collections.Generic;
using VRbit.Agendamentos.Application.Interfaces;
using VRbit.Agendamentos.Application.ViewModels;
using VRbit.Agendamentos.Domain.Entities;
using VRbit.Agendamentos.Domain.Interfaces.Repository;
using VRbit.Agendamentos.Infra.Data.Repository;

namespace VRbit.Agendamentos.Application.Services
{
    public class TipoAgendamentoAppService : ITipoAgendamentoAppService
    {
        private readonly IRepository<TipoAgendamento> _tipoAgendamentoRepository;

        public TipoAgendamentoAppService()
        {
            _tipoAgendamentoRepository = new Repository<TipoAgendamento>();
        }

        public TipoAgendamentoViewModel Adicionar(TipoAgendamentoViewModel tipoAgendamentoViewModel)
        {
            var tipoAgendamento = Mapper.Map<TipoAgendamento>(tipoAgendamentoViewModel);
            var tipoAgendamentoReturn = _tipoAgendamentoRepository.Adicionar(tipoAgendamento);

            return Mapper.Map<TipoAgendamentoViewModel>(tipoAgendamentoReturn);
        }

        public TipoAgendamentoViewModel Atualizar(TipoAgendamentoViewModel tipoAgendamentoViewModel)
        {
            var tipoAgendamento = Mapper.Map<TipoAgendamento>(tipoAgendamentoViewModel);
            var tipoAgendamentoReturn = _tipoAgendamentoRepository.Atualizar(tipoAgendamento);

            return Mapper.Map<TipoAgendamentoViewModel>(tipoAgendamentoReturn);
        }

        public void Dispose()
        {
            _tipoAgendamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TipoAgendamentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoAgendamentoViewModel>>(_tipoAgendamentoRepository.SelecionarTodos());
        }

        public TipoAgendamentoViewModel SelecionarPorId(Guid id)
        {
            return Mapper.Map<TipoAgendamentoViewModel>(_tipoAgendamentoRepository.SelecionarPorId(id));
        }

        public void Remover(Guid id)
        {
            _tipoAgendamentoRepository.Remover(id);
        }
    }
}
