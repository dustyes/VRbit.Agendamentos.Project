using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VRbit.Agendamentos.Application.ViewModels
{
    public class TipoAgendamentoViewModel
    {
        public TipoAgendamentoViewModel()
        {
            TipoAgendamentoId = Guid.NewGuid();
        }

        [Key]
        public Guid TipoAgendamentoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo interno")]
        [DisplayName("Interno")]
        public bool Interno { get; set; }

    }
}
