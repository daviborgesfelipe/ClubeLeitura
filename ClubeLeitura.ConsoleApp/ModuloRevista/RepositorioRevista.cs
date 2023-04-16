using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class RepositorioRevista : RepositorioBase
    {
        public RepositorioCaixa repositorioCaixa { get; set; }
        internal void PopularListaRevistas(RepositorioCaixa _repositorioCaixa)
        {
            Revista revistaComCaixaUm = new Revista(1, "Acelerando", 777, "01/02/2020", _repositorioCaixa.SelecionarPorId(1));
            Revista revistaComCaixaDois = new Revista(2, "Recreio", 4312, "11/07/2023", _repositorioCaixa.SelecionarPorId(2));
            Revista revistaComCaixaTres = new Revista(3, "Surf", 2018, "23/12/2021", _repositorioCaixa.SelecionarPorId(3));
            _listaRegistro.Add(revistaComCaixaUm);
            _listaRegistro.Add(revistaComCaixaDois);
            _listaRegistro.Add(revistaComCaixaTres);
        }
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
        }
        internal void Excluir(int idSelecionado)
        {
            Revista revista = SelecionarPorId(idSelecionado);
            _listaRegistro.Remove(revista);
        }
    }
}
