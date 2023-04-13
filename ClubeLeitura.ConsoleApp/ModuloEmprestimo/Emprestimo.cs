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
    }
}
