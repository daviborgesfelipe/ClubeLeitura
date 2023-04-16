namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa
    {
        public int Id { get; set; }
        public string Etiqueta { get; set; }
        public string Cor { get; set; }

        public Caixa(int id, string etiqueta, string cor)
        {
            Id = id;
            Etiqueta = etiqueta;
            Cor = cor;
        }
        public Caixa(string etiqueta, string cor)
        {
            Etiqueta = etiqueta;
            Cor = cor;
        }
    }
}
