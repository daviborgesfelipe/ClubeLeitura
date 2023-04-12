using ClubeLeitura.ConsoleApp.Servicos;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuServico menuServico = new MenuServico();
            RevistaServico revistaServico = new RevistaServico();
            AmigoServico amigoServico = new AmigoServico();
            EmprestimoServico emprestimoServico = new EmprestimoServico();
            revistaServico.PopularListaRevistaComCaixa();
            amigoServico.PopularListaAmigos();
            while (true) 
            {
                menuServico.ImprimeMenuInicial();
                int opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        menuServico.ImprimeMenuAmigo();
                        int opcaoMenuAmigos = Convert.ToInt32(Console.ReadLine());
                        switch (opcaoMenuAmigos)
                        {
                            case 1:
                                amigoServico.CadastrarAmigo();
                                break;
                            case 2:
                                amigoServico.VizualizarAmigos();
                                break;
                            case 3:
                                amigoServico.VizualizarAmigosPorId();
                                break;
                            case 4:
                                amigoServico.EditaAmigo();
                                break;
                            case 5:
                                amigoServico.RemoveAmigo();
                                break;
                        }
                        break; 
                    case 2:
                        menuServico.ImprimeMenuRevistas();
                        int opcaoMenuRevistas = Convert.ToInt32(Console.ReadLine());
                        switch (opcaoMenuRevistas)
                        {
                            case 1:
                                revistaServico.CadastrarRevista();
                                break;
                            case 2:
                                revistaServico.VizualizarRevistas();
                                break;
                            case 3:
                                revistaServico.VizualizarRevistaPorId();
                                break;
                            case 4:
                                revistaServico.EditaRevista();
                                break;
                            case 5:
                                revistaServico.RemoveRevista();
                                break;
                        }
                        break; 
                    case 3:
                        //chama menu emprestimos
                        //TO-DO
                        break;
                    default:
                        break;
                }
            }
        }
    }
}