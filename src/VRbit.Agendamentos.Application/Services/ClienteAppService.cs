using AutoMapper;
using System;
using System.Collections.Generic;
using VRbit.Agendamentos.Application.Interfaces;
using VRbit.Agendamentos.Application.ViewModels;
using VRbit.Agendamentos.Domain.Entities;
using VRbit.Agendamentos.Infra.Data.Repository;

namespace VRbit.Agendamentos.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.ClienteViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.EnderecoViewModel);

            cliente.Enderecos.Add(endereco);

            var clienteReturn = _clienteRepository.Adicionar(cliente);

            return Mapper.Map<ClienteEnderecoViewModel>(clienteReturn);
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteReturn = _clienteRepository.Atualizar(cliente);

            return Mapper.Map<ClienteViewModel>(clienteReturn);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public ClienteViewModel ObterPorCPF(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(email));
        }

        public ClienteViewModel ObterPorId(Guid Id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.SelecionarPorId(Id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.SelecionarTodos());
        }

        public void Remover(Guid Id)
        {
            _clienteRepository.Remover(Id);
        }
    }
}
