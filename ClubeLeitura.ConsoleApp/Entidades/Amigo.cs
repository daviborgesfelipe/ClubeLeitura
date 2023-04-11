namespace ClubeLeitura.ConsoleApp.Entidades
{
    internal class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Amigo(int id, string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.Id = id;
            this.Nome = nome;
            this.NomeResponsavel = nomeResponsavel;
            this.Telefone = telefone;
            this.Endereco = endereco;
        }
    }
}
