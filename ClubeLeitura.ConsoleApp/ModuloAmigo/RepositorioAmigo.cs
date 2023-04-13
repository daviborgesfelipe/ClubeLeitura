using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    internal class RepositorioAmigo
    {
        private static int IdAmigo = 3;
        private static List<Amigo> _listaAmigos = new List<Amigo>();
        public static List<Amigo> ListarTodos() 
        {
            return _listaAmigos;
        }
        public static void Inserir(Amigo amigo)
        {
            amigo.Id = IdAmigo;
            _listaAmigos.Add(amigo);
            IncrementaIdAmigo();
        }
        public static Amigo BuscarPorId(int id)
        {
            Amigo amigo = null;
            foreach (Amigo _amigo in _listaAmigos)
            {
                if (_amigo.Id == id)
                {
                    amigo = _amigo;
                    break;
                }
            }
            return amigo;
        }
        public static void PopularListaAmigos()
        {
            Amigo amigoUm = new Amigo(1, "Davi", "Davi Borges", "4732413078", "Rua Programador, CodeVille, Sao Test, Brazil");
            Amigo amigoDois = new Amigo(2, "Caio", "Caio Valle", "4932413123", "Rua Desenvolvedor, Costa Code, Test Grande do Sul, Brazil");
            _listaAmigos.Add(amigoUm);
            _listaAmigos.Add(amigoDois);
        }
        private static void IncrementaIdAmigo()
        {
            IdAmigo++;
        }
        internal static Amigo SelecionarPorId(int idSelecionado)
        {
            Amigo amigo = null;
            foreach (Amigo _amigo in _listaAmigos)
            {
                if (_amigo.Id == idSelecionado)
                {
                    amigo = _amigo;
                    break;
                }
            }
            return amigo;
        }
        internal static void Editar(int id, Amigo amigoAtualizado)
        {
            Amigo amigo = SelecionarPorId(id);

            amigo.Nome = amigoAtualizado.Nome;
            amigo.NomeResponsavel = amigoAtualizado.NomeResponsavel;
            amigo.Telefone = amigoAtualizado.Telefone;
            amigo.Endereco = amigoAtualizado.Endereco;
        }
        public static void Excluir(int idSelecionado)
        {
            Amigo amigo = SelecionarPorId(idSelecionado);
            _listaAmigos.Remove(amigo);
        }
    }
}
