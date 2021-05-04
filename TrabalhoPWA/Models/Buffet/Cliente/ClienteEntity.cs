using System;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public TipoCliente tipo { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Email { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimasAlteracoes { get; set; }
        
        

    }
}