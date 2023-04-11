using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Entidades
{
    internal class Caixa
    {
        public string LocalArmazenamento { get; set; }
        public Caixa(string localArmazenamento)
        {
            this.LocalArmazenamento = localArmazenamento;
        }
    }
}
