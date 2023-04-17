using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
    {
        public RepositorioRevista repositorioRevista = null;
        public RepositorioCaixa repositorioCaixa = null;

        internal void InserirNovaRevista(RepositorioRevista _repositorioRevista, RepositorioCaixa _repositorioCaixa, TelaCaixa _telaCaixa)
        {
            repositorioRevista = _repositorioRevista;
            Console.Clear();
            Console.WriteLine("Inserir Revista");
            Console.WriteLine();
            Revista novoRevista = ObterRevista(_repositorioCaixa, _telaCaixa);
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
        internal bool VisualizarRevistas(bool mensagemVoltarMenuInicial, RepositorioRevista _repositorioRevista)
        {
            repositorioRevista = _repositorioRevista;
            List<Revista> listaRevistas = repositorioRevista.ListarTodos();
            if (listaRevistas.Count == 0)
            {
                Console.WriteLine("Lista esta vazia");
                return false; 
            }
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
        internal void VisualizarRevistas()
        {
            List<Revista> listaRevistas = repositorioRevista.ListarTodos();
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
        }
        internal void EditarRevista(RepositorioRevista _repositorioRevista)
        {
            repositorioRevista = _repositorioRevista;
            Console.Clear();
            Console.WriteLine("Editar Revista");
            Console.WriteLine();
            VisualizarRevistas();
            Console.WriteLine();
            int idEncontrado = EncontrarIdRevista(_repositorioRevista);
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
        internal void ExcluirRevista(RepositorioRevista _repositorioRevista)
        {
            repositorioRevista = _repositorioRevista;
            Console.Clear();
            Console.WriteLine("Excluir Revista");
            Console.WriteLine();
            VisualizarRevistas();
            Console.WriteLine();
            int idSelecionado = EncontrarIdRevista(_repositorioRevista);
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
        
        internal Revista ObterRevista(RepositorioCaixa _repositorioCaixa, TelaCaixa _telaCaixa)
        {
            repositorioCaixa = _repositorioCaixa;
            Revista revista;
            Console.WriteLine("Digite o titulo");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o numero edicao");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o data de lancamento da revista");
            string anoRevista = Console.ReadLine();
            bool mensagemVoltarMenuInicial = false;
            _telaCaixa.VisualizarCaixas(mensagemVoltarMenuInicial);
            Console.WriteLine("Digite o id da caixa");
            int id = int.Parse(Console.ReadLine());
            Caixa caixa = repositorioCaixa.BuscarPorId(id);
            revista = new Revista(titulo, numeroEdicao, anoRevista, caixa);
            return revista;
        }
        internal Revista ObterRevista()
        {
            Revista revista;
            Console.WriteLine("Digite o titulo");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o numero edicao");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o data de lancamento da revista");
            string anoRevista = Console.ReadLine();
            revista = new Revista(titulo, numeroEdicao, anoRevista);
            return revista;
        }
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
        internal int EncontrarIdRevista(RepositorioRevista _repositorioRevista)
        {
            repositorioRevista = _repositorioRevista;
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
    }
}
