using AutoMapper;
using VRbit.Agendamentos.Application.ViewModels;
using VRbit.Agendamentos.Domain.Entities;

namespace VRbit.Agendamentos.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
            CreateMap<TipoAgendamento, TipoAgendamentoViewModel>();
        }
    }
}
