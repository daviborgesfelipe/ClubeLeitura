using ClubeLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista
    {
        static int idCaixa = 3;
        static int idRevista = 3;
        public static int ApresentarMenuCadastroRevista()
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
            Console.WriteLine("[5] Voltar menu");
            Console.WriteLine();
            int opcaoMenuRevista = Convert.ToInt32(Console.ReadLine());
            return opcaoMenuRevista;
        }

        public static void InserirNovaRevista()
        {
            Console.WriteLine("Inserir Revista");
            Revista novoRevista = ObterRevista();
            RepositorioRevista.Inserir(novoRevista);
            Console.WriteLine("Inserido com sucesso");
        }
        public static void EditarRevista()
        {
            Console.WriteLine("Editar Revista");
            bool temRevista = VisualizarRevista();
            if (temRevista == false)
            {
                return;
            }
            Console.WriteLine();
            int idEncontrado = EncontrarIdRevista();
            Revista revistaAtualizado = ObterRevista();
            RepositorioRevista.Editar(idEncontrado, revistaAtualizado);
            Console.WriteLine("Editado com sucesso");
        }
        private static int EncontrarIdRevista()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.Write("Digite o Id do revista: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = RepositorioRevista.SelecionarPorId(idSelecionado) == null;
                if (idInvalido)
                {
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);
            return idSelecionado;
        }
        public static bool VisualizarRevista()
        {
            List<Revista> listaRevistas = RepositorioRevista.ListarTodos();
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5, -20} | {6, -20}", "Id", "Titulo", "NumeroEdicao", "AnoRevista", "Etiqueta", "Cor", "Numero");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Revista revista in listaRevistas)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5, -20} | {6, -20}",
                    revista.Id, revista.Titulo, revista.NumeroEdicao, revista.AnoRevista, revista.Caixa.Etiqueta, revista.Caixa.Cor, revista.Caixa.Numero);
            }
            Console.ResetColor();
            Console.ReadLine();
            return true;
        }
        public static Revista ObterRevista()
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
            Console.WriteLine("Digite o numero da caixa");
            double numeroaCaixa = Convert.ToDouble(Console.ReadLine());
            Caixa caixa = new Caixa(etiquetaCaixa, corCaixa, numeroaCaixa);
            Revista revista = new Revista(titulo, numeroEdicao, anoRevista, caixa);
            return revista;
        }
        public static void ExcluirRevista()
        {
            Console.WriteLine("Excluir Revista");
            bool temRevista = VisualizarRevista();
            if (temRevista == false)
            {
                return;
            }
            Console.WriteLine();
            int idSelecionado = EncontrarIdRevista();
            RepositorioRevista.Excluir(idSelecionado);
            Console.WriteLine("Revista excluída com sucesso!");
        }
        private static void IncrementaIdCaixa()
        {
            idCaixa++;
        }
        private static void IncrementaIdRevista()
        {
            idCaixa++;
        }
    }
}
