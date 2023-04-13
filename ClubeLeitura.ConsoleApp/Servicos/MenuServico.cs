namespace ClubeLeitura.ConsoleApp.Servicos;
internal class MenuServico
{
    public void ImprimeMenuInicial()
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
    }
    public void ImprimeMenuAmigo() 
    {
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
        Console.WriteLine("[6] Voltar menu");
        Console.WriteLine();
    }
    public void ImprimeMenuRevistas() 
    {
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
        Console.WriteLine("[6] Voltar menu");
        Console.WriteLine();
    }
    public void ImprimeMenuEmprestimos()
    {
        Console.Clear();
        Console.WriteLine("Menu emprestimos");
        Console.WriteLine();
        Console.WriteLine("Selecione a opcao desejada");
        Console.WriteLine();
        Console.WriteLine("[1] Cadastrar uma emprestimo");
        Console.WriteLine("[2] Vizualizar todos os emprestimos");
        Console.WriteLine("[3] Vizualizar emprestimo por id");
        Console.WriteLine("[4] Editar um emprestimo");
        Console.WriteLine("[5] Finalizar um emprestimo");
        Console.WriteLine("[6] Voltar menu");
        Console.WriteLine();
    }
}
