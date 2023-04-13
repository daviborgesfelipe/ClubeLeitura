namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa
    {
        public int Id { get; set; }
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public double Numero { get; set; }

        public Caixa(int id, string etiqueta, string cor, double numero)
        {
            Id = id;
            Etiqueta = etiqueta;
            Cor = cor;
            Numero = numero;
        }
        public Caixa(string etiqueta, string cor, double numero)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            Numero = numero;
        }
    }
}
