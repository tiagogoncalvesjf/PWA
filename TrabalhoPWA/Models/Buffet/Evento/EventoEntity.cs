using System;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Situacao;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public TipoEvento TipoEvento { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public String HoraInicio { get; set; }
        public String HoraTermino { get; set; }
        public ClienteEntity Cliente { get; set; }
        public SituacaoEvento SituacaoEvento { get; set; }
        public String Local { get; set; }
        public String Endereco { get; set; }
        public String Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        
        
    }
}