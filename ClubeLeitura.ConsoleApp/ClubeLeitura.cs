using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using ClubeLeitura.ConsoleApp.Servicos;

namespace ClubeLeitura.ConsoleApp
{
    internal class ClubeLeitura
    {
        static void Main(string[] args)
        {
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            repositorioRevista.PopularListaRevistas();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.PopularListaAmigos();

            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.repositorioAmigo = repositorioAmigo;
            TelaRevista telaRevista = new TelaRevista();
            telaRevista.repositorioRevista = repositorioRevista;

            MenuServico menuServico = new MenuServico();
            while (true) 
            {
                int opcaoMenuInicial = ApresentarMenuInicial();
                switch (opcaoMenuInicial)
                {
                    case 1:
                        //MenuAmigo();
                        int opcaoMenuCadastroAmigo = telaAmigo.ApresentarMenuCadastroAmigo();
                        switch (opcaoMenuCadastroAmigo)
                        {
                            case 1:
                                telaAmigo.InserirNovoAmigo();
                                break;
                            case 2:
                                telaAmigo.VisualizarAmigos();
                                break;
                            case 3:
                                telaAmigo.EditarAmigo();
                                break;
                            case 4:
                                telaAmigo.ExcluirAmigo();
                                break;
                            case 5:
                                ApresentarMenuInicial();
                                break;
                        }
                        break; 
                    case 2:
                        int opcaoMenuCadastroRevista = telaRevista.ApresentarMenuCadastroRevista();
                        switch (opcaoMenuCadastroRevista)
                        {
                            case 1:
                                telaRevista.InserirNovaRevista();
                                break;
                            case 2:
                                telaRevista.VisualizarRevista();
                                break;
                            case 3:
                                telaRevista.EditarRevista();
                                break;
                            case 4:
                                telaRevista.ExcluirRevista();
                                break;
                            case 5:
                                ApresentarMenuInicial();
                                break;
                        }
                        break; 
                    case 3:
                        MenuEmprestimo();
                        break;
                    default:
                        break;
                }
            }

            #region MenuInicial
            static int ApresentarMenuInicial()
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
                int opcaoMenuInicial = Convert.ToInt32(Console.ReadLine());
                return opcaoMenuInicial;
            }
            #endregion
            void MenuEmprestimo()
            {
                menuServico.ImprimeMenuEmprestimos();
                int opcaoMenuEmprestimo = Convert.ToInt32(Console.ReadLine());
                switch (opcaoMenuEmprestimo)
                {
                    case 1:
                        //CadastrarEmprestimo
                        break;
                    case 2:
                        //VizualizarEmprestimo();
                        break;
                    case 3:
                        //VizualizarEmprestimoPorId();
                        break;
                    case 4:
                        //EditarEmprestimo();
                        break;
                    case 5:
                        //FinalizarEmprestimo();
                        break;
                    case 6:
                        menuServico.ImprimeMenuInicial();
                        break;
                }
            }
        }
        internal static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();
            Console.WriteLine(subtitulo);
            Console.WriteLine();
            Console.WriteLine();
        }
        private static int ApresertarMenuAmigo()
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
            Console.WriteLine("[6] Voltar menu");
            Console.WriteLine();
            int opcaoMenuAmigos = Convert.ToInt32(Console.ReadLine());
            return opcaoMenuAmigos;
        }
    }
}