using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloRevista;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class Emprestimo
    {
        public int Id { get; set; }
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public string DataInicio { get; set; }
        public string DataDevolucao { get; set; }

        public Emprestimo(int id, Amigo amigo, Revista revista, string dataInicio, string dataDevolucao)
        {
            Id = id;
            Amigo = amigo;
            Revista = revista;
            DataInicio = dataInicio;
            DataDevolucao = dataDevolucao;

        }
        public Emprestimo( Amigo amigo, Revista revista, string dataInicio, string dataDevolucao)
        {
            Amigo = amigo;
            Revista = revista;
            DataInicio = dataInicio;
            DataDevolucao = dataDevolucao;

        }
        public Emprestimo(Emprestimo emprestimo)
        {
            Id = emprestimo.Id;
            Amigo = emprestimo.Amigo;
            Revista = emprestimo.Revista;
            DataInicio = emprestimo.DataInicio;
            DataDevolucao = emprestimo.DataDevolucao;
        }
    }
}
