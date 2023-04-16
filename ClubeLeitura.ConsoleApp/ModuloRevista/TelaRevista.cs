using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using System.Runtime.ConstrainedExecution;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
    {
        public RepositorioRevista repositorioRevista = null;
        internal int InteragirMenuCadastroRevista()
        {
            Console.Clear();
            Console.WriteLine("Menu revista");
            Console.WriteLine();
            Console.WriteLine("Selecione a opcao desejada");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar um revista");
            Console.WriteLine("[2] Vizualizar todos as revistas");
            Console.WriteLine("[3] Editar uma revista");
            Console.WriteLine("[4] Excluir uma revista");
            Console.WriteLine("[5] Menu inicial");
            Console.WriteLine();
            int opcaoMenuRevista = Convert.ToInt32(Console.ReadLine());
            return opcaoMenuRevista;
        }
        internal void InserirNovaRevista(RepositorioRevista _repositorioRevista)
        {
            repositorioRevista = _repositorioRevista;
            Console.Clear();
            Console.WriteLine("Inserir Revista");
            Console.WriteLine();
            Revista novoRevista = ObterRevista();
            repositorioRevista.Inserir(novoRevista);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Revista inserida com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
        }
        internal void EditarRevista(RepositorioRevista _repositorioRevista)
        {
            repositorioRevista = _repositorioRevista;
            Console.Clear();
            Console.WriteLine("Editar Revista");
            Console.WriteLine();
            bool mensagemVoltarMenuInicial = false;
            bool temRevista = VisualizarRevistas(mensagemVoltarMenuInicial);
            if (temRevista == false)
            {
                Console.WriteLine("Lista esta vazia");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();
            int idEncontrado = EncontrarIdRevista();
            Revista revistaAtualizado = ObterRevista();
            repositorioRevista.Editar(idEncontrado, revistaAtualizado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Revista editada com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        internal int EncontrarIdRevista()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.Write("Digite o Id do revista: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioRevista.SelecionarPorId(idSelecionado) == null;
                if (idInvalido)
                {
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);
            return idSelecionado;
        }
        internal bool VisualizarRevistas(bool mensagemVoltarMenuInicial)
        {
            List<Revista> listaRevistas = repositorioRevista.ListarTodos();
            if (listaRevistas.Count == 0) { return false; }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-10} | {4,-20} | {5}",
                    "Id", "Titulo", "NumeroEdicao", "AnoRevista", "Etiqueta", "Cor");
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (Revista revista in listaRevistas)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-10} | {4,-20} | {5}",
                    revista.Id, revista.Titulo, revista.NumeroEdicao, revista.AnoRevista, revista.Caixa.Etiqueta, revista.Caixa.Cor);
            }
            if (mensagemVoltarMenuInicial)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
                Console.ResetColor();
                Console.ReadKey();
            }
            return true;
        }
        internal Revista ObterRevista()
        {
            Console.WriteLine("Digite o titulo");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o numero edicao");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o data de lancamento da revista");
            string anoRevista = Console.ReadLine();
            Console.WriteLine("Digite o nome da etiqueta na caixa");
            string etiquetaCaixa = Console.ReadLine();
            Console.WriteLine("Digite a cor da caixa");
            string corCaixa = Console.ReadLine();
            Caixa caixa = new Caixa(etiquetaCaixa, corCaixa);
            Revista revista = new Revista(titulo, numeroEdicao, anoRevista, caixa);
            return revista;
        }
        internal void ExcluirRevista()
        {
            Console.Clear();
            Console.WriteLine("Excluir Revista");
            Console.WriteLine();
            bool mensagemVoltarMenuInicial = false;
            bool temRevista = VisualizarRevistas(mensagemVoltarMenuInicial);
            if (temRevista == false)
            {
                Console.WriteLine("Lista esta vazia");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();
            int idSelecionado = EncontrarIdRevista();
            repositorioRevista.Excluir(idSelecionado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Revista excluida com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
