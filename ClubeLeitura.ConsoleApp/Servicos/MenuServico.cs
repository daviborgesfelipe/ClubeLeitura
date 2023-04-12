using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Servicos
{
    internal class MenuServico
    {
        public void MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("Clube da Leitura");
            Console.WriteLine();
            Console.WriteLine("Selecione a opcao desejada");
            Console.WriteLine();
            Console.WriteLine("[1] Menu amigos");
            Console.WriteLine("[2] Menu revistas");
            Console.WriteLine("[3] Menu emprestimos");
            Console.WriteLine();
        }
        public void MenuAmigo() 
        {
            Console.Clear();
            Console.WriteLine("Menu amigo");
            Console.WriteLine();
            Console.WriteLine("Selecione a opcao desejada");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar um amigo");
            Console.WriteLine("[2] Vizualizar todos os amigos");
            Console.WriteLine("[3] Vizualizar amigo por id");
            Console.WriteLine("[4] Editar um amigo");
            Console.WriteLine("[5] Excluir um amigo");
            Console.WriteLine();
        }
        public void MenuRevistas() 
        {
            Console.Clear();
            Console.WriteLine("Menu revistas");
            Console.WriteLine();
            Console.WriteLine("Selecione a opcao desejada");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar uma revista");
            Console.WriteLine("[2] Vizualizar todas as revistas");
            Console.WriteLine("[3] Vizualizar revistas por id");
            Console.WriteLine("[4] Editar uma revista");
            Console.WriteLine("[5] Excluir uma revista");
            Console.WriteLine();
        }
    }
}
