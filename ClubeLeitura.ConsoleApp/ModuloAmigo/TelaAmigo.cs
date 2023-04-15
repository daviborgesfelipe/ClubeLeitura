using ClubeLeitura.ConsoleApp;
using ClubeLeitura.ConsoleApp.Compartilhado;
using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo : TelaBase
    {
        public RepositorioAmigo repositorioAmigo = null;
        public int ApresentarMenuCadastroAmigo()
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
        public void InserirNovoAmigo()
        {
            Console.Clear();
            Console.WriteLine("Inserir Amigo");
            Console.WriteLine();
            Amigo novoAmigo = ObterAmigo();
            repositorioAmigo.Criar(novoAmigo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Amigo inserido com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        public bool VisualizarAmigos()
        {
            List<Amigo> listaChamados = repositorioAmigo.ListarTodos();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-60}",
                "Id", "Nome", "NomeResponsavel", "Telefone", "Endereco");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            foreach (Amigo amigo in listaChamados)
            {
                Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-60}",
                    amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco);

            }

            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
            return true;
        }
        public void EditarAmigo()
        {
            Console.Clear();
            Console.WriteLine("Editar Amigo");
            Console.WriteLine();
            bool temAmigos = VisualizarAmigos();
            if (temAmigos == false) 
            {
                return;
            }
            Console.WriteLine();
            int idEncontrado = EncontrarIdAmigo();
            Amigo amigoAtualizado = ObterAmigo();
            repositorioAmigo.Editar(idEncontrado, amigoAtualizado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Amigo editado com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        public void ExcluirAmigo()
        {
            Console.Clear();
            Console.WriteLine("Excluir Amigo");
            Console.WriteLine();
            bool temAmigos = VisualizarAmigos();
            if (temAmigos == false)
            {
                return;
            }
            Console.WriteLine();
            int idSelecionado = EncontrarIdAmigo();
            repositorioAmigo.Excluir(idSelecionado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Amigo excluido com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        private int EncontrarIdAmigo()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.Write("Digite o Id do amigo: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioAmigo.SelecionarPorId(idSelecionado) == null;
                if (idInvalido) 
                {
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);                
                }
            } while (idInvalido);
            return idSelecionado;
        }
        public Amigo ObterAmigo()
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
    }
}
