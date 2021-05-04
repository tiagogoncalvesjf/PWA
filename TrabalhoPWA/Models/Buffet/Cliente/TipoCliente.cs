using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Buffet.Cliente
{
    public class TipoCliente
    {
       
        public int Id { get; protected set; }
        private string Descricao  { get; set; }
    }
}