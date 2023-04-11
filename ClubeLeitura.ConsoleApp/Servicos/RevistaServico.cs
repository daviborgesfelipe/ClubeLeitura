using ClubeLeitura.ConsoleApp.Entidades;
namespace ClubeLeitura.ConsoleApp.Servicos
{
    internal class RevistaServico
    {
        List<Revista> revistas = new List<Revista>();
        internal void PopularListaRevista()
        {
            Revista test01 = new Revista(1, "test1", 1234, new DateTime(11/11/11), new Caixa("test1"));
            Revista test02 = new Revista(2, "test2", 4312, new DateTime(21/11/12), new Caixa("test2"));
            revistas.Add(test01);
            revistas.Add(test02);
        }
        #region CadastrarRevista
        static int id = 3;
        internal void CadastrarRevista()
        {
            Console.Clear();
            Console.WriteLine("Digite o titulo da revista");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o numero da edicao da revista");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a data de lancamento da revista");
            DateTime anoRevista = Convert.ToDateTime(Console.ReadLine());
            DateTime anoRevistaConvertido = anoRevista.Date;
            Console.WriteLine("Digite onde a revista sera armazenada");
            string localArmazenamento = Console.ReadLine();
            Caixa caixa = new Caixa(localArmazenamento);
            Revista revista = new Revista(id, titulo, numeroEdicao, anoRevistaConvertido, caixa);
            revistas.Add(revista);
            id++;
        }
        #endregion

        #region VizualizarTodasRevistas
        internal void VizualizarRevistas()
        {
            Console.Clear();
            foreach (Revista resvista in revistas)
            {
                Console.WriteLine($"resvista: {resvista.Titulo}");
            }
            Console.ReadLine();
        }
        #endregion

        #region VizualizarUmaRevista
        internal void VizualizarRevistaPorId()
        {
            Console.Clear();
            Console.WriteLine("Digite o id da revista que deseja vizualizar");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Revista resvista in revistas)
            {
                if (resvista.Id == id)
                {
                    Console.WriteLine($"resvista: {resvista.Titulo}");
                }
            }
            Console.ReadLine();
        }
        #endregion

        #region EditarRevista
        public void EditaRevista()
        {
            Console.Clear();
            Console.WriteLine("Digite o id da revista que deseja editar");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Revista revista in revistas)
            {
                if (revista.Id == id)
                {
                    Console.WriteLine("Digite o titulo da revista");
                    string novoTitulo = Console.ReadLine();
                    Console.WriteLine("Digite o numero da edicao da revista");
                    int novoNumeroEdicao = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite a data de lancamento da revista");
                    DateTime novoAnoRevista = Convert.ToDateTime(Console.ReadLine());
                    DateTime novoAnoRevistaConvertido = novoAnoRevista.Date;
                    Console.WriteLine("Digite onde a revista sera armazenada");
                    string novoLocalArmazenamento = Console.ReadLine();
                    Caixa caixa = new Caixa(novoLocalArmazenamento);

                    revista.Titulo = novoTitulo;
                    revista.NumeroEdicao = novoNumeroEdicao;
                    revista.AnoRevista = novoAnoRevistaConvertido;
                    revista.LocalArmazenamento = caixa;
                }
            }
        }
        #endregion

        #region RemoveRevista
        public void RemoveRevista()
        {
            Console.Clear();
            Console.WriteLine("Digite o id da revista que deseja excluir");
            int id = Convert.ToInt32(Console.ReadLine());
            List<Revista> revistasExclusao = revistas.ToList();

            foreach (Revista revista in revistasExclusao)
            {
                if(revista.Id == id)
                {
                    revistas.Remove(revista);
                }
            }
        }
        #endregion
    }
}
