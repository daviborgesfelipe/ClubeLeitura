using ClubeLeitura.ConsoleApp.Entidades;
namespace ClubeLeitura.ConsoleApp.Servicos
{
    internal class RevistaServico
    {
        List<Revista> revistas = new List<Revista>();
        internal void PopularListaRevistaComCaixa()
        {
            Revista revistaComCaixaUm = new Revista(1, "test1", 1234, new DateTime(11/11/11), new Caixa(1, "SuperMercado", "Verde", 33));
            Revista revistaComCaixaDois = new Revista(2, "test2", 4312, new DateTime(21/11/12), new Caixa(2, "Caixa Plastico", "Transparente", 0));
            revistas.Add(revistaComCaixaUm);
            revistas.Add(revistaComCaixaDois);
        }
        #region CadastrarRevista
        static int idRevista = 3;
        static int idCaixa = 3;
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
            Console.WriteLine("Digite onde a cor da caixa onde a revista sera guardadas");
            string corDaCaixa = Console.ReadLine();
            Console.WriteLine("Digite o nome da etiqueta da caixa");
            string nomeEtiqueta = Console.ReadLine();
            Console.WriteLine("Digite o numero da caixa");
            double numeroCaixa = Convert.ToDouble(Console.ReadLine());
            Caixa caixa = new Caixa(idCaixa, corDaCaixa,nomeEtiqueta, numeroCaixa);
            Revista revista = new Revista(idRevista, titulo, numeroEdicao, anoRevistaConvertido, caixa);
            revistas.Add(revista);
            idRevista++;
            idCaixa++;
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
                    Console.WriteLine("Deseja alterar a caixa?");
                    Console.WriteLine();
                    Console.WriteLine("[1] Sim");
                    Console.WriteLine("[2] Nao");
                    int opcaoMenuEditarRevista = Convert.ToInt32(Console.ReadLine());
                    switch (opcaoMenuEditarRevista)
                    {
                        case 1:
                            Console.WriteLine("Digite onde a nova cor da caixa onde a revista sera guardadas");
                            string novaCorDaCaixa = Console.ReadLine();
                            Console.WriteLine("Digite o novo nome da etiqueta da caixa");
                            string novoNomeEtiqueta = Console.ReadLine();
                            Console.WriteLine("Digite o novo numero da caixa");
                            double novoNumeroCaixa = Convert.ToDouble(Console.ReadLine());
                            Caixa caixa = new Caixa(novaCorDaCaixa, novoNomeEtiqueta, novoNumeroCaixa);
                            
                            revista.Titulo = novoTitulo;
                            revista.NumeroEdicao = novoNumeroEdicao;
                            revista.AnoRevista = novoAnoRevistaConvertido;
                            revista.LocalArmazenamento = caixa;
                            break;
                        case 2:
                            revista.Titulo = novoTitulo;
                            revista.NumeroEdicao = novoNumeroEdicao;
                            revista.AnoRevista = novoAnoRevistaConvertido;
                            break;
                    }
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
