using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class RepositorioRevista : RepositorioBase
    {
        internal List<Revista> ListarTodos()
        {
            List<object> listaGenerica = _listaRegistro;
            List <Revista> listaTipada = listaGenerica.Cast<Revista>().ToList();
            return listaTipada;
        }
        internal void Inserir(Revista revista)
        {
            revista.Id = Id;
            _listaRegistro.Add(revista);
            IncrementarId();
        }
        internal Revista BuscarPorId(int id)
        {
            Revista revista = null;
            foreach (Revista _revista in _listaRegistro)
            {
                if (_revista.Id == id)
                {
                    revista = _revista;
                    break;
                }
            }
            return revista;
        }
        internal void PopularListaRevistas()
        {
            Revista revistaComCaixaUm = new Revista(1, "Acelerando", 777, "01/02/2020", new Caixa(1, "SuperMercado", "Verde", 33));
            Revista revistaComCaixaDois = new Revista(2, "Recreio", 4312, "11/07/2023", new Caixa(2, "Caixa Plastico", "Transparente", 0));
            Revista revistaComCaixaTres = new Revista(3, "Surf", 2018, "23/12/2021", new Caixa(3, "Gaveta da Cama", "Medeira", 0));
            _listaRegistro.Add(revistaComCaixaUm);
            _listaRegistro.Add(revistaComCaixaDois);
            _listaRegistro.Add(revistaComCaixaTres);
        }

        internal Revista SelecionarPorId(int idSelecionado)
        {
            Revista revista = null;
            foreach (Revista _revista in _listaRegistro)
            {
                if (_revista.Id == idSelecionado)
                {
                    revista = _revista;
                    break;
                }
            }
            return revista;
        }
        internal void Editar(int id, Revista revistaAtualizada)
        {
            Revista revista = SelecionarPorId(id);
            revista.Titulo = revistaAtualizada.Titulo;
            revista.NumeroEdicao = revistaAtualizada.NumeroEdicao;
            revista.AnoRevista = revistaAtualizada.AnoRevista;
            revista.Caixa.Etiqueta = revistaAtualizada.Caixa.Etiqueta;
            revista.Caixa.Numero = revistaAtualizada.Caixa.Numero;
        }
        internal void Excluir(int idSelecionado)
        {
            Revista revista = SelecionarPorId(idSelecionado);
            _listaRegistro.Remove(revista);
        }
    }
}
