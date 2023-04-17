using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloRevista;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        public RepositorioEmprestimo repositorioEmprestimo = null;
        public RepositorioRevista repositorioRevista = null;
        public RepositorioAmigo repositorioAmigo = null;
        public ClubeLeitura clubeLeitura = null;

        internal void InserirNovoEmprestimo(
            RepositorioAmigo repositorioAmigo,
            RepositorioRevista repositorioRevista,
            RepositorioEmprestimo repositorioEmprestimo
            )
        {
            Console.Clear();
            Console.WriteLine("Inserir Emprestimo");
            Console.WriteLine();
            Emprestimo novoEmprestimo = ObterEmprestimo(
                repositorioAmigo, 
                repositorioRevista, 
                repositorioEmprestimo
                );
            repositorioEmprestimo.Inserir(novoEmprestimo);
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
        internal bool VisualizarEmprestimo(bool mensagemVoltarMenuInicial)
        {
            List<Emprestimo> listaEmprestimo = repositorioEmprestimo.ListarTodos();
            if(listaEmprestimo.Count == 0) { return false; }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-10} | {4} ",
                    "Id", "Amigo", "Revista", "Inicio", "Devolucao");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            foreach (Emprestimo emprestimo in listaEmprestimo)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-10} | {4} ",
                    emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Revista.Titulo, emprestimo.DataInicio, emprestimo.DataDevolucao);
            }
            if (mensagemVoltarMenuInicial)
            {
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
                Console.ResetColor();
                Console.ReadKey();
            }
            return true;
        }
        internal void VisualizarEmprestimo()
        {
            List<Emprestimo> listaEmprestimo = repositorioEmprestimo.ListarTodos();
            if (listaEmprestimo.Count == 0) 
            {
                Console.WriteLine("Lista vazia");
                return; 
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-10} | {4} ",
                    "Id", "Amigo", "Revista", "Inicio", "Devolucao");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            foreach (Emprestimo emprestimo in listaEmprestimo)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-10} | {4} ",
                    emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Revista.Titulo, emprestimo.DataInicio, emprestimo.DataDevolucao);
            }
        }
        internal void EditarEmprestimo(
            RepositorioAmigo repositorioAmigo, 
            RepositorioRevista repositorioRevista
            )
        {
            Console.Clear();
            Console.WriteLine("Editar Emprestimo");
            Console.WriteLine();
            VisualizarEmprestimo();
            Console.WriteLine();
            int idEncontrado = EncontrarId();
            Emprestimo emprestimoAtualizado = ObterEmprestimo(repositorioAmigo, repositorioRevista);
            repositorioEmprestimo.Editar(idEncontrado, emprestimoAtualizado);
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
        internal void ExcluirEmprestimo(RepositorioEmprestimo _repositorioEmprestimo)
        {
            repositorioEmprestimo = _repositorioEmprestimo;
            Console.Clear();
            Console.WriteLine("Excluir Emprestimo");
            Console.WriteLine();
            VisualizarEmprestimo();
            Console.WriteLine();
            int idSelecionado = EncontrarId();
            repositorioEmprestimo.Excluir(idSelecionado);
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
        

        internal Emprestimo ObterEmprestimo(
            RepositorioAmigo repositorioAmigo, 
            RepositorioRevista repositorioRevista
            )
        {
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
            Console.WriteLine("Digite o id da amigo");
            int amigoId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o id da revista");
            string revistaTituloOuId = Console.ReadLine();
            Console.WriteLine("Digite a data que ira iniciar o emprestimo");
            string dataInicioEmprestimo = Console.ReadLine();
            Console.WriteLine("Digite a data que ira devolver a revista");
            string dataDevolucaoEmprestimo = Console.ReadLine();
            Amigo amigoEmprestimo = this.repositorioAmigo.SelecionarPorId(amigoId);
            int revistaId = Convert.ToInt32(revistaTituloOuId);
            Revista revistaEmprestimo = this.repositorioRevista.SelecionarPorId(revistaId);
            Emprestimo emprestimo = new Emprestimo(
                amigoEmprestimo, 
                revistaEmprestimo, 
                dataInicioEmprestimo, 
                dataDevolucaoEmprestimo);
            return emprestimo;
        }
        internal Emprestimo ObterEmprestimo(
            RepositorioAmigo _repositorioAmigo, 
            RepositorioRevista _repositorioRevista,
            RepositorioEmprestimo _repositorioEmprestimo
            )
        {
            repositorioAmigo = _repositorioAmigo;
            repositorioRevista = _repositorioRevista;
            repositorioEmprestimo = _repositorioEmprestimo;
            List<Emprestimo> _listaEmprestimos = repositorioEmprestimo.ListarTodos();
            Console.WriteLine("Digite o id da amigo");
            int amigoId = Convert.ToInt32(Console.ReadLine());
            Amigo amigoEmprestimo = repositorioAmigo.SelecionarPorId(amigoId);
            foreach (var _amigoFor in _listaEmprestimos)
            {
                if(_amigoFor.Amigo.Id == amigoEmprestimo.Id)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Amigo ja possui um emprestimo");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
                    Console.ResetColor();
                    Console.ReadKey();
                    //VOLTAR MEU PRINCIAPAL
                    break;
                }
            }
            Console.WriteLine("Digite o id da revista");
            string revistaTituloOuId = Console.ReadLine();
            int revistaId = Convert.ToInt32(revistaTituloOuId);
            Revista revistaEmprestimo = repositorioRevista.SelecionarPorId(revistaId);
            foreach (var _revistaFor in _listaEmprestimos)
            {
                if (_revistaFor.Revista.Id == revistaEmprestimo.Id)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Revista ja emprestada");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
                    Console.ResetColor();
                    Console.ReadKey();
                    //VOLTAR MEU PRINCIAPAL
                    break;
                }
            }

            Console.WriteLine("Digite a data que ira iniciar o emprestimo");
            string dataInicioEmprestimo = Console.ReadLine();
            Console.WriteLine("Digite a data que ira devolver a revista");
            string dataDevolucaoEmprestimo = Console.ReadLine();
            Emprestimo emprestimo = new Emprestimo(
                amigoEmprestimo, 
                revistaEmprestimo,
                dataInicioEmprestimo,
                dataDevolucaoEmprestimo
                );
            return emprestimo;
        }

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
        internal int EncontrarId()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.Write("Digite o Id do emprestimo: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioEmprestimo.SelecionarPorId(idSelecionado) == null;
                if (idInvalido)
                {
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);
            return idSelecionado;
        }
    }
}
