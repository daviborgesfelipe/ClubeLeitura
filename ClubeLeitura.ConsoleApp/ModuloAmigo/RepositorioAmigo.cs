using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloRevista;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    internal class RepositorioAmigo : RepositorioBase
    {
        public List<Amigo> ListarTodos() 
        {
            List<object> listaGenerica = _listaRegistro;
            List<Amigo> listaTipada = listaGenerica.Cast<Amigo>().ToList();
            return listaTipada;
        }
        public void Criar(Amigo amigo)
        {
            amigo.Id = Id;
            _listaRegistro.Add(amigo);
            IncrementarId();
        }
        public Amigo BuscarPorId(int id)
        {
            Amigo amigo = null;
            foreach (Amigo _amigo in _listaRegistro)
            {
                if (_amigo.Id == id)
                {
                    amigo = _amigo;
                    break;
                }
            }
            return amigo;
        }
        public void PopularListaAmigos()
        {
            Amigo amigoUm = new Amigo(1, "Davi", "Davi Borges", "4732413078", "CodeVille, Santa Compiladora, Brazil");
            Amigo amigoDois = new Amigo(2, "Caio", "Caio Valle", "4932413123", "Costa Code, Test Grande do Sul, Brazil");
            Amigo amigoTres = new Amigo(3, "Fabian", "Fabian", "5293245523", "Sao Compilador, Soft Ware do Norte, Brazil");
            _listaRegistro.Add(amigoUm);
            _listaRegistro.Add(amigoDois);
            _listaRegistro.Add(amigoTres);
        }
        internal Amigo SelecionarPorId(int idSelecionado)
        {
            Amigo amigo = null;
            foreach (Amigo _amigo in _listaRegistro)
            {
                if (_amigo.Id == idSelecionado)
                {
                    amigo = _amigo;
                    return _amigo;
                }
            }
            return amigo;
        }
        internal void Editar(int id, Amigo amigoAtualizado)
        {
            Amigo amigo = SelecionarPorId(id);

            amigo.Nome = amigoAtualizado.Nome;
            amigo.NomeResponsavel = amigoAtualizado.NomeResponsavel;
            amigo.Telefone = amigoAtualizado.Telefone;
            amigo.Endereco = amigoAtualizado.Endereco;
        }
        public void Excluir(int idSelecionado)
        {
            Amigo amigo = SelecionarPorId(idSelecionado);
            _listaRegistro.Remove(amigo);
        }
    }
}
