using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloRevista;

namespace ClubeLeitura.ConsoleApp
{
    internal class ClubeLeitura
    {
        static void Main(string[] args)
        {
            RepositorioCaixa _repositorioCaixa = new RepositorioCaixa();
            RepositorioRevista _repositorioRevista = new RepositorioRevista();
            RepositorioAmigo _repositorioAmigo = new RepositorioAmigo();
            RepositorioEmprestimo _repositorioEmprestimo = new RepositorioEmprestimo();
            
            TelaAmigo _telaAmigo = new TelaAmigo();
            TelaRevista _telaRevista = new TelaRevista();
            TelaEmprestimo _telaEmprestimo = new TelaEmprestimo();
            TelaCaixa _telaCaixa = new TelaCaixa();
            
            
            _repositorioCaixa.PopularListaCaixa();
            _repositorioRevista.PopularListaRevistas(_repositorioCaixa);
            _repositorioAmigo.PopularListaAmigos();
            _repositorioEmprestimo.PopularListaEmprestimo(_repositorioAmigo, _repositorioRevista);

            _telaAmigo.repositorioAmigo = _repositorioAmigo;
            _telaRevista.repositorioRevista = _repositorioRevista;
            _telaEmprestimo._repositorioEmprestimo = _repositorioEmprestimo;
            _telaCaixa.repositorioCaixa = _repositorioCaixa;
            #region MenuInicial

            int InteragirMenuInicial()
            {
                Console.Clear();
                Console.WriteLine("Clube da Leitura");
                Console.WriteLine();
                Console.WriteLine("Selecione a opcao desejada");
                Console.WriteLine();
                Console.WriteLine("[1] Menu Amigos");
                Console.WriteLine("[2] Menu Revistas");
                Console.WriteLine("[3] Menu Emprestimos");
                Console.WriteLine(); 
                int opcaoMenuInicial = Convert.ToInt32(Console.ReadLine());
                return opcaoMenuInicial;
            }
            #endregion

            while (true) 
            {
                int opcaoMenuInicial = InteragirMenuInicial();
                switch (opcaoMenuInicial)
                {
                    case 1:
                        IniciarMenuAmigo(_telaAmigo);
                        break;
                    case 2:
                        IniciarMenuRevista(_telaRevista);
                        break;
                    case 3:
                        InicialMenuEmprestimo(_telaEmprestimo);
                        break;
                    default:
                        break;
                }
            }

            void InicialMenuEmprestimo(TelaEmprestimo _telaEmprestimo)
            {
                int opcaoMenuEmprestimo = _telaEmprestimo.InteragirMenuEmprestimos();
                switch (opcaoMenuEmprestimo)
                {
                    case 1:
                        _telaEmprestimo.InserirNovoEmprestimo(_repositorioAmigo, _repositorioRevista);
                        break;
                    case 2:
                        bool mensagemVoltarMenuInicial = true;
                        _telaEmprestimo.VisualizarEmprestimo(mensagemVoltarMenuInicial);
                        break;
                    case 3:
                        _telaEmprestimo.EditarEmprestimo(_repositorioAmigo, _repositorioRevista);
                        break;
                    case 4:
                        _telaEmprestimo.ExcluirEmprestimo();
                        break;
                    case 5:
                        InteragirMenuInicial();
                        break;
                }
            }

            void IniciarMenuRevista(TelaRevista _telaRevista)
            {
                int opcaoMenuCadastroRevista = _telaRevista.InteragirMenuCadastroRevista();
                switch (opcaoMenuCadastroRevista)
                {
                    case 1:
                        _telaRevista.InserirNovaRevista(_repositorioRevista);
                        break;
                    case 2:
                        bool mensagemVoltarMenuInicial = true;
                        _telaRevista.VisualizarRevistas(mensagemVoltarMenuInicial);
                        break;
                    case 3:
                        _telaRevista.EditarRevista(_repositorioRevista);
                        break;
                    case 4:
                        _telaRevista.ExcluirRevista();
                        break;
                    case 5:
                        InteragirMenuInicial();
                        break;
                }
            }

            void IniciarMenuAmigo(TelaAmigo _telaAmigo)
            {
                int opcaoMenuCadastroAmigo = _telaAmigo.InteragirMenuCadastroAmigo();
                switch (opcaoMenuCadastroAmigo)
                {
                    case 1:
                        _telaAmigo.InserirNovoAmigo(_repositorioAmigo);
                        break;
                    case 2:
                        bool mensagemVoltarMenuInicial = true;
                        _telaAmigo.VisualizarAmigos(mensagemVoltarMenuInicial);
                        break;
                    case 3:
                        _telaAmigo.EditarAmigo(_repositorioAmigo);
                        break;
                    case 4:
                        _telaAmigo.ExcluirAmigo();
                        break;
                    case 5:
                        InteragirMenuInicial();
                        break;
                }
            }
        }
        internal void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        public void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();
            Console.WriteLine(subtitulo);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}