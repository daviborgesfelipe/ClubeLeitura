namespace ClubeLeitura.ConsoleApp.Entidades
{
    internal class Revista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int NumeroEdicao { get; set; }
        public DateTime AnoRevista { get; set; }
        public Caixa LocalArmazenamento { get; set; }
        public Revista(int id, string titulo, int numeroEdicao, DateTime anoRevista, Caixa localArmazenamento)
        {
            Id = id;
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            AnoRevista = anoRevista;
            LocalArmazenamento = localArmazenamento;
        }
    }
}
