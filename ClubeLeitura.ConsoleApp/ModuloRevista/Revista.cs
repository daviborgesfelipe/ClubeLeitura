using ClubeLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int NumeroEdicao { get; set; }
        public string AnoRevista { get; set; }
        public Caixa Caixa { get; set; }
        public Revista(int id, string titulo, int numeroEdicao, string anoRevista, Caixa caixa)
        {
            Id = id;
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            AnoRevista = anoRevista;
            Caixa = caixa;
        }
        public Revista(string titulo, int numeroEdicao, string anoRevista, Caixa caixa)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            AnoRevista = anoRevista;
            Caixa = caixa;
        }
        public Revista(string titulo, int numeroEdicao, string anoRevista)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            AnoRevista = anoRevista;
        }
        public Revista(Revista revista)
        {
            Titulo = revista.Titulo;
            NumeroEdicao = revista.NumeroEdicao;
            AnoRevista = revista.AnoRevista;
            Caixa = revista.Caixa;
        }
    }
}
