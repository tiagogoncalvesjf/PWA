using System;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Models.Buffet.Convidado

{
    public class ConvidadoEntity
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public EventoEntity Evento { get; set; }
        public string Situacao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        
    }


}