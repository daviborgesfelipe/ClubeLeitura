using ClubeLeitura.ConsoleApp.Servicos;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RevistaServico revistaServico = new RevistaServico();
            AmigoServico amigoServico = new AmigoServico();
            EmprestimoServico emprestimoServico = new EmprestimoServico();
            revistaServico.PopularListaRevista();
            amigoServico.PopularListaAmigos();
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Clube da Leitura");
                Console.WriteLine();
                Console.WriteLine("Selecione a opcao desejada");
                Console.WriteLine();
                Console.WriteLine("[1] Menu amigos");
                Console.WriteLine("[2] Menu revistas");
                Console.WriteLine("[3] Menu emprestimos");
                Console.WriteLine();
                int opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        //chama menu amigo
                        Console.Clear();
                        Console.WriteLine("Menu amigo");
                        Console.WriteLine();
                        Console.WriteLine("Selecione a opcao desejada");
                        Console.WriteLine();
                        Console.WriteLine("[1] Cadastrar um amigo");
                        Console.WriteLine("[2] Vizualizar todos os amigos");
                        Console.WriteLine("[3] Vizualizar amigo por id");
                        Console.WriteLine("[4] Editar um amigo");
                        Console.WriteLine("[5] Excluir um amigo");
                        Console.WriteLine();
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
                        //chama menu revistas
                        Console.Clear();
                        Console.WriteLine("Menu revistas");
                        Console.WriteLine();
                        Console.WriteLine("Selecione a opcao desejada");
                        Console.WriteLine();
                        Console.WriteLine("[1] Cadastrar uma revista");
                        Console.WriteLine("[2] Vizualizar todas as revistas");
                        Console.WriteLine("[3] Vizualizar revistas por id");
                        Console.WriteLine("[4] Editar uma revista");
                        Console.WriteLine("[5] Excluir uma revista");
                        Console.WriteLine();
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