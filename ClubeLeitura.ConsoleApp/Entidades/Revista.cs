namespace ClubeLeitura.ConsoleApp.Entidades
{
    internal class Revista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int NumeroEdicao { get; set; }
        public DateTime AnoRevista { get; set; }
        public Caixa Caixa { get; set; }
        public Revista(int id, string titulo, int numeroEdicao, DateTime anoRevista, Caixa caixa)
        {
            Id = id;
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            AnoRevista = anoRevista;
            Caixa = caixa;
        }
    }
}
