using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        public RepositorioEmprestimo _repositorioEmprestimo = null;
        public RepositorioRevista _repositorioRevista = null;
        public RepositorioAmigo _repositorioAmigo = null;

        public int InteragirMenuEmprestimos()
        {
            Console.Clear();
            Console.WriteLine("Menu emprestimos");
            Console.WriteLine();
            Console.WriteLine("Selecione a opcao desejada");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar uma emprestimo");
            Console.WriteLine("[2] Vizualizar todos os emprestimos");
            Console.WriteLine("[3] Editar um emprestimo");
            Console.WriteLine("[4] Finalizar um emprestimo");
            Console.WriteLine("[5] Menu inicial");
            Console.WriteLine();
            int opcaoMenuEmprestimo = Convert.ToInt32(Console.ReadLine());
            return opcaoMenuEmprestimo;
        }
        internal bool VisualizarEmprestimo(bool mensagemVoltarMenuInicial)
        {
            List<Emprestimo> listaEmprestimo = _repositorioEmprestimo.ListarTodos();
            if(listaEmprestimo.Count == 0) { return false; }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-10} | {4} ",
                    "Id", "Amigo", "Revista", "Inicio", "Devolucao");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (Emprestimo emprestimo in listaEmprestimo)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-10} | {4} ",
                    emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Revista.Titulo, emprestimo.DataInicio, emprestimo.DataDevolucao);
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
            return true;
        }
        internal void ExcluirEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("Excluir Emprestimo");
            Console.WriteLine();
            bool mensagemVoltarMenuInicial = false;
            bool temEmprestimo = VisualizarEmprestimo(mensagemVoltarMenuInicial);
            if (temEmprestimo == false)
            {
                Console.WriteLine("Lista esta vazia");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();
            int idSelecionado = EncontrarId();
            _repositorioEmprestimo.Excluir(idSelecionado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Emprestimo excluido com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        internal void EditarEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            Console.Clear();
            Console.WriteLine("Editar Emprestimo");
            Console.WriteLine();
            bool mensagemVoltarMenuInicial = false;
            bool temRevista = VisualizarEmprestimo(mensagemVoltarMenuInicial);
            if (temRevista == false)
            {
                Console.WriteLine("Lista esta vazia");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();
            int idEncontrado = EncontrarId();
            Emprestimo emprestimoAtualizado = ObterEmprestimo(repositorioAmigo, repositorioRevista);
            _repositorioEmprestimo.Editar(idEncontrado, emprestimoAtualizado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Emprestimo editado com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        internal int EncontrarId()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.Write("Digite o Id do emprestimo: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = _repositorioEmprestimo.SelecionarPorId(idSelecionado) == null;
                if (idInvalido)
                {
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);
            return idSelecionado;
        }
        internal void InserirNovoEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            Console.Clear();
            Console.WriteLine("Inserir Emprestimo");
            Console.WriteLine();
            Emprestimo novoEmprestimo = ObterEmprestimo(repositorioAmigo, repositorioRevista);
            _repositorioEmprestimo.Inserir(novoEmprestimo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Emprestimo inserida com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        internal Emprestimo ObterEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            _repositorioAmigo = repositorioAmigo;
            _repositorioRevista = repositorioRevista;
            Console.WriteLine("Digite o id da amigo");
            int amigoId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o id da revista");
            string revistaTituloOuId = Console.ReadLine();
            Console.WriteLine("Digite a data que ira iniciar o emprestimo");
            string dataInicioEmprestimo = Console.ReadLine();
            Console.WriteLine("Digite a data que ira devolver a revista");
            string dataDevolucaoEmprestimo = Console.ReadLine();
            Amigo amigoEmprestimo = _repositorioAmigo.SelecionarPorId(amigoId);
            int revistaId = Convert.ToInt32(revistaTituloOuId);
            Revista revistaEmprestimo = _repositorioRevista.SelecionarPorId(revistaId);
            Emprestimo emprestimo = new Emprestimo(amigoEmprestimo, revistaEmprestimo, dataInicioEmprestimo, dataDevolucaoEmprestimo);
            return emprestimo;
        }
    }
}
