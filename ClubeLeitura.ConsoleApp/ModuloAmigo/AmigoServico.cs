using ClubeLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    internal class AmigoServico
    {
        List<Amigo> amigos = new List<Amigo>();
        internal void PopularListaAmigos()
        {
            Amigo amigoUm = new Amigo(1, "Davi", "Davi Borges", "4732413078", "Rua Programador, CodeVille, Sao Test, Brazil");
            Amigo amigoDois = new Amigo(2, "Caio", "Caio Valle", "4932413123", "Rua Desenvolvedor, Costa Code, Test Grande do Sul, Brazil");
            amigos.Add(amigoUm);
            amigos.Add(amigoDois);
        }
        #region CadastrarAmigo
        static int id = 3;
        internal void CadastrarAmigo()
        {
            Console.WriteLine("Digite o nome do amigo");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o nome do responsavel");
            string nomeResponsavel = Console.ReadLine();
            Console.WriteLine("Digite o telefone do amigo");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereco do amigo");
            string endereco = Console.ReadLine();
            Amigo amigo = new Amigo(id, nome, nomeResponsavel, telefone, endereco);
            amigos.Add(amigo);
            id++;
        }
        #endregion

        #region VizualizarTodosAmigos
        internal void VizualizarAmigos()
        {
            Console.Clear();
            foreach (Amigo amigo in amigos)
            {
                Console.WriteLine($"resvista: {amigo.Nome}");
            }
            Console.ReadLine();
        }
        #endregion

        #region VizualizarUmAmigo
        internal void VizualizarAmigosPorId()
        {
            Console.Clear();
            Console.WriteLine("Digite o id do amigo que deseja vizualizar");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Amigo amigo in amigos)
            {
                if (amigo.Id == id)
                {
                    Console.WriteLine($"resvista: {amigo.Nome}");
                }
            }
            Console.ReadLine();
        }
        #endregion
        #region VizualizarUmAmigo
        internal Amigo VizualizarAmigosPorId(int id)
        {
            Console.Clear();
            foreach (Amigo amigo in amigos)
            {
                if (amigo.Id == id)
                {
                    Console.WriteLine($"amigo: {amigo.Nome}");
                    return amigo;
                }
            }
            Console.WriteLine($"Amigo com ID {id} não encontrado.");
            Console.ReadLine();
            return null;
        }
        #endregion

        #region VizualizarUmAmigo
        internal Amigo VizualizarAmigosPorNome(string nome)
        {
            Console.Clear();
            foreach (Amigo amigo in amigos)
            {
                if (amigo.Nome == nome)
                {
                    Console.WriteLine($"Amigo: {amigo.Nome}");
                    return amigo;
                }
            }
            Console.WriteLine($"Amigo com nome {nome} não encontrado.");
            Console.ReadLine();
            return null;
        }
        #endregion
        #region EditarAmigo
        public void EditaAmigo()
        {
            Console.Clear();
            Console.WriteLine("Digite o id do amigo que deseja editar");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Amigo amigo in amigos)
            {
                if (amigo.Id == id)
                {
                    Console.WriteLine("Digite o nome do amigo");
                    string novoNome = Console.ReadLine();
                    Console.WriteLine("Digite o nome do responsavel");
                    string novoNomeResponsavel = Console.ReadLine();
                    Console.WriteLine("Digite o telefone do amigo");
                    string novoTelefone = Console.ReadLine();
                    Console.WriteLine("Digite o endereco do amigo");
                    string novoEndereco = Console.ReadLine();

                    amigo.Nome = novoNome;
                    amigo.NomeResponsavel = novoNomeResponsavel;
                    amigo.Telefone = novoTelefone;
                    amigo.Endereco = novoEndereco;
                }
            }
        }
        #endregion

        #region RemoveAmigo
        public void RemoveAmigo()
        {
            Console.Clear();
            Console.WriteLine("Digite o id do amigo que deseja excluir");
            int id = Convert.ToInt32(Console.ReadLine());
            List<Amigo> amigosExclusao = amigos.ToList();

            foreach (Amigo amigo in amigosExclusao)
            {
                if (amigo.Id == id)
                {
                    amigos.Remove(amigo);
                }
            }
        }
        #endregion
    }
}
