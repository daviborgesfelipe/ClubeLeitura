namespace ClubeLeitura.ConsoleApp.Entidades
{
    internal class Emprestimo
    {
        public int Id { get; set; }
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo(int id, Amigo amigo, Revista revista, DateTime dataInicio, DateTime dataDevolucao)
        {
            Id = id;
            Amigo = amigo;
            Revista = revista;
            DataInicio = dataInicio;
            DataDevolucao = dataDevolucao;
        }
    }
}
