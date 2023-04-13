using ClubeLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class RepositorioRevista
    {
        private static int IdRevista = 3;
        private static List<Revista> _listaRevistas = new List<Revista>();
        public static List<Revista> ListarTodos()
        {
            return _listaRevistas;
        }
        public static void Inserir(Revista revista)
        {
            revista.Id = IdRevista;
            _listaRevistas.Add(revista);
            IncrementaIdRevista();
        }
        public static Revista BuscarPorId(int id)
        {
            Revista revista = null;
            foreach (Revista _revista in _listaRevistas)
            {
                if (_revista.Id == id)
                {
                    revista = _revista;
                    break;
                }
            }
            return revista;
        }
        public static void PopularListaRevistas()
        {
            Revista revistaComCaixaUm = new Revista(1, "Acelerando", 777, "01/02/2020", new Caixa(1, "SuperMercado", "Verde", 33));
            Revista revistaComCaixaDois = new Revista(2, "Recreio", 4312, "11/07/2023", new Caixa(2, "Caixa Plastico", "Transparente", 0));
            _listaRevistas.Add(revistaComCaixaUm);
            _listaRevistas.Add(revistaComCaixaDois);
        }
        private static void IncrementaIdRevista()
        {
            IdRevista++;
        }

        internal static Revista SelecionarPorId(int idSelecionado)
        {
            Revista revista = null;
            foreach (Revista _revista in _listaRevistas)
            {
                if (_revista.Id == idSelecionado)
                {
                    revista = _revista;
                    break;
                }
            }
            return revista;
        }
        internal static void Editar(int id, Revista revistaAtualizada)
        {
            Revista revista = SelecionarPorId(id);
            revista.Titulo = revistaAtualizada.Titulo;
            revista.NumeroEdicao = revistaAtualizada.NumeroEdicao;
            revista.AnoRevista = revistaAtualizada.AnoRevista;
            revista.Caixa.Etiqueta = revistaAtualizada.Caixa.Etiqueta;
            revista.Caixa.Numero = revistaAtualizada.Caixa.Numero;
        }
        public static void Excluir(int idSelecionado)
        {
            Revista revista = SelecionarPorId(idSelecionado);
            _listaRevistas.Remove(revista);
        }
    }
}
