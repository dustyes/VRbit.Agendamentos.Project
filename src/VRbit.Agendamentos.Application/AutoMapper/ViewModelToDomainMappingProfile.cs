using AutoMapper;
using VRbit.Agendamentos.Application.ViewModels;
using VRbit.Agendamentos.Domain.Entities;

namespace VRbit.Agendamentos.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();
            CreateMap<TipoAgendamentoViewModel, TipoAgendamento>();
        }
    }
}
