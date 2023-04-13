using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloRevista;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class EmprestimoServico
    {
        List<Emprestimo> emprestimos = new List<Emprestimo>();
        static int idEmprestimo = 3;
        Revista revistaEmprestimo;
        Amigo amigoEmprestimo;
        internal void PopularListaEmprestimo()
        {
            Emprestimo empresticoComAmigoRevistaUm = new Emprestimo(1, new Amigo(1, "Davi", "Davi Borges", "4732413078", "Rua Programador, CodeVille, Sao Test, Brazil"), new Revista(1, "Acelerando", 777, "01/02/2020", new Caixa(1, "SuperMercado", "Verde", 33)), "01/01/2021", "14/07/2023");
            Emprestimo empresticoComAmigoRevistaDois = new Emprestimo(2, new Amigo(2, "Caio", "Caio Valle", "4932413123", "Rua Desenvolvedor, Costa Code, Test Grande do Sul, Brazil"), new Revista(2, "Recreio", 4312, "11/07/2021", new Caixa(2, "Caixa Plastico", "Transparente", 0)), "01/03/2021", "13/02/2023");
            emprestimos.Add(empresticoComAmigoRevistaUm);
            emprestimos.Add(empresticoComAmigoRevistaDois);
        }
        public void CadastrarEmprestimo(AmigoServico amigoServico, RevistaServico revistaServico)
        {
            Console.WriteLine("Digite o id ou nome da amigo");
            string amigoNomeOuId = Console.ReadLine();
            Console.WriteLine("Digite o id ou titulo da revista emprestada");
            string revistaTituloOuId = Console.ReadLine();
            string dataInicioEmprestimo = DateTime.Now.ToString();
            Console.WriteLine("Digite a data que ira devolver a revista");
            string dataDevolucaoEmprestimo = Console.ReadLine();
            int amigoId = Convert.ToInt32(amigoNomeOuId);
            amigoEmprestimo = new Amigo(amigoServico.VizualizarAmigosPorId(amigoId));
            int revistaId = Convert.ToInt32(revistaTituloOuId);
            revistaEmprestimo = new Revista(revistaServico.VizualizarRevistaPorId(revistaId));
            Emprestimo emprestimo = new Emprestimo(idEmprestimo, amigoEmprestimo, revistaEmprestimo, dataInicioEmprestimo, dataDevolucaoEmprestimo);
            emprestimos.Add(emprestimo);
            idEmprestimo++;
            //cadastrar o emprestimo na lista de emprestimo
        }
        public void FinalizarEmprestimo()
        {
            //solicitar o id do emprestimo
            //excluir o emprestimo da lista
        }
        public void EditarEmprestimo()
        {
            //mostrar todos os eemprestimo
            //solicitar o id do emprestimo
            //editar o emprestimo
        }
        public void VizualizarEmprestimo()
        {
            Console.Clear();
            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine($"Amigo nome: {emprestimo.Amigo.Nome}");
                Console.WriteLine($"Revista: {emprestimo.Revista.Titulo}");
                Console.WriteLine($"DataInicio: {emprestimo.DataInicio}");
                Console.WriteLine($"DataDevolucao: {emprestimo.DataDevolucao}");
                Console.WriteLine("----------------------------------------------");
            }
            Console.WriteLine("Digite enter para voltar ao menu emprestimo");
            Console.ReadLine();
        }
        public void VizualizarEmprestimoPorId()
        {
            //solicitar o id do emprestimo desejado
            //listar todos os emprestimo da lista
        }
    }
}
