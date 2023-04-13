namespace ClubeLeitura.ConsoleApp.ModuloAmigo;
internal class Amigo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeResponsavel { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public Amigo(int id, string nome, string nomeResponsavel, string telefone, string endereco)
    {
        Id = id;
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
        Endereco = endereco;
    }
    public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
        Endereco = endereco;
    }
    public Amigo(Amigo amigo)
    {
        Nome = amigo.Nome;
        NomeResponsavel = amigo.NomeResponsavel;
        Telefone = amigo.Telefone;
        Endereco = amigo.Endereco;
    }
}
