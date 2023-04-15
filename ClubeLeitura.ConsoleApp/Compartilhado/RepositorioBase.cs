using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    internal class RepositorioBase
    {
        internal int Id { get; set; } = 4;
        internal List<object> _listaRegistro = new List<object>();
        internal void IncrementarId()
        {
            this.Id++;
        }
    }
}
