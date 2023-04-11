using ClubeLeitura.ConsoleApp.Entidades;
namespace ClubeLeitura.ConsoleApp.Servicos
{
    internal class AmigoServico
    {
        List<Amigo> amigos = new List<Amigo>();
        internal void PopularListaAmigos()
        {
            Amigo test01 = new Amigo(1, "test1", "testResp", "4732413078", "Rua test, TestVille, Sao Test, Testzil");
            Amigo test02 = new Amigo(2, "test2", "testResp", "4732413123", "Rua test, TestVille, Sao Test, Testzil");
            amigos.Add(test01);
            amigos.Add(test02);
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
