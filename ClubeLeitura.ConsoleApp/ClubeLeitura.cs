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
            RepositorioRevista.PopularListaRevistas();
            RepositorioAmigo.PopularListaAmigos();

            MenuServico menuServico = new MenuServico();
            while (true) 
            {
                int opcaoMenuInicial = ApresentarMenuInicial();
                switch (opcaoMenuInicial)
                {
                    case 1:
                        //MenuAmigo();
                        int opcaoMenuCadastroAmigo = TelaAmigo.ApresentarMenuCadastroAmigo();
                        switch (opcaoMenuCadastroAmigo)
                        {
                            case 1:
                                TelaAmigo.InserirNovoAmigo();
                                break;
                            case 2:
                                TelaAmigo.VisualizarAmigos();
                                break;
                            case 3:
                                TelaAmigo.EditarAmigo();
                                break;
                            case 4:
                                TelaAmigo.ExcluirAmigo();
                                break;
                            case 5:
                                ApresentarMenuInicial();
                                break;
                        }
                        break; 
                    case 2:
                        int opcaoMenuCadastroRevista = TelaRevista.ApresentarMenuCadastroRevista();
                        switch (opcaoMenuCadastroRevista)
                        {
                            case 1:
                                TelaRevista.InserirNovaRevista();
                                break;
                            case 2:
                                TelaRevista.VisualizarRevista();
                                break;
                            case 3:
                                TelaRevista.EditarRevista();
                                break;
                            case 4:
                                TelaRevista.ExcluirRevista();
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