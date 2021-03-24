using System;
using System.Collections.Generic;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteService
    {
        public List<ClienteEntity> ObterClientes()
        {
            var listadeClientes = new List<ClienteEntity>();

            listadeClientes.Add(new ClienteEntity()
            {
                Id = 1,
                Nome = "Leonardo",
                DataDeNascimento = new DateTime(1986, 12, 1)
            });
            
            listadeClientes.Add(new ClienteEntity()
            {
                Id = 2,
                Nome = "Tiago",
                DataDeNascimento = new DateTime(1992, 09, 14)
            });
            
            return listadeClientes;

        }
    }
}