using ClubeLeitura.ConsoleApp;
using System.Collections;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo
    {
        public static int ApresentarMenuCadastroAmigo()
        {
            Console.Clear();
            Console.WriteLine("Menu amigo");
            Console.WriteLine();
            Console.WriteLine("Selecione a opcao desejada");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar um amigo");
            Console.WriteLine("[2] Vizualizar todos os amigos");
            Console.WriteLine("[3] Editar um amigo");
            Console.WriteLine("[4] Excluir um amigo");
            Console.WriteLine("[5] Voltar menu");
            Console.WriteLine();
            int opcaoMenuAmigo = Convert.ToInt32(Console.ReadLine());

            return opcaoMenuAmigo;
        }

        public static void InserirNovoAmigo()
        {
            Console.WriteLine("Inserir Amigo");
            Amigo novoAmigo = ObterAmigo();
            RepositorioAmigo.Inserir(novoAmigo);
            Console.WriteLine("Inserido com sucesso");
        }
        public static void EditarAmigo()
        {
            Console.WriteLine("Editar Amigo");
            bool temAmigos = VisualizarAmigos();
            if (temAmigos == false) 
            {
                return;
            }
            Console.WriteLine();
            int idEncontrado = EncontrarIdAmigo();
            Amigo amigoAtualizado = ObterAmigo();
            RepositorioAmigo.Editar(idEncontrado, amigoAtualizado);
            Console.WriteLine("Editado com sucesso");
        }


        //
        private static int EncontrarIdAmigo()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.Write("Digite o Id do amigo: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = RepositorioAmigo.SelecionarPorId(idSelecionado) == null;
                if (idInvalido) 
                {
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);                
                }
            } while (idInvalido);
            return idSelecionado;
        }
        public static bool VisualizarAmigos()
        {
            List<Amigo> listaChamados = RepositorioAmigo.ListarTodos();
            Console.WriteLine("{0,-10} | {1,-30} | {2,-30} | {3,-20} | {4,-60}", "Id", "Nome", "NomeResponsavel", "Telefone", "Endereco");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
            foreach (Amigo amigo in listaChamados)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-30} | {3,-20} | {4,-60}",
                    amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco);
            }

            Console.ResetColor();
            Console.ReadLine();
            return true;
        }
        public static Amigo ObterAmigo()
        {
            Console.WriteLine("Digite o nome do amigo");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o nome do responsavel");
            string nomeResponsavel = Console.ReadLine();
            Console.WriteLine("Digite o telefone do amigo");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereco do amigo");
            string endereco = Console.ReadLine();
            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco);
            return amigo;
        }
        public static void ExcluirAmigo()
        {
            Console.WriteLine("Excluir Amigo");
            bool temAmigos = VisualizarAmigos();
            if (temAmigos == false)
            {
                return;
            }
            Console.WriteLine();
            int idSelecionado = EncontrarIdAmigo();
            RepositorioAmigo.Excluir(idSelecionado);
            Console.WriteLine("Amigo excluído com sucesso!");
        }

    }
}
