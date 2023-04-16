using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : RepositorioBase
    {
        internal void PopularListaEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            Emprestimo empresticoComAmigoRevistaUm = new Emprestimo(
                1,repositorioAmigo.SelecionarPorId(1), repositorioRevista.SelecionarPorId(1), "01/01/2021", "14/07/2023");
            Emprestimo empresticoComAmigoRevistaDois = new Emprestimo(
                2,repositorioAmigo.SelecionarPorId(2), repositorioRevista.SelecionarPorId(2), "01/03/2021", "13/02/2023");

            _listaRegistro.Add(empresticoComAmigoRevistaUm);
            _listaRegistro.Add(empresticoComAmigoRevistaDois);
        }
        internal List<Emprestimo> ListarTodos()
        {
            List<object> listaGenerica = _listaRegistro;
            List<Emprestimo> listaTipada = listaGenerica.Cast<Emprestimo>().ToList();
            return listaTipada;
        }
        internal void Inserir(Emprestimo emprestimo)
        {
            emprestimo.Id = Id;
            _listaRegistro.Add(emprestimo);
            IncrementarId();
        }
        internal Emprestimo SelecionarPorId(int idSelecionado)
        {
            Emprestimo emprestimo = null;
            foreach (Emprestimo _emprestimo in _listaRegistro)
            {
                if (_emprestimo.Id == idSelecionado)
                {
                    emprestimo = _emprestimo;
                    break;
                }
            }
            return emprestimo;
        }
        internal void Editar(int id, Emprestimo emprestimoAtualizado)
        {
            Emprestimo emprestimo = SelecionarPorId(id);
            emprestimo.Amigo = emprestimoAtualizado.Amigo;
            emprestimo.Revista = emprestimoAtualizado.Revista;
            emprestimo.DataInicio = emprestimoAtualizado.DataInicio;
            emprestimo.DataDevolucao = emprestimoAtualizado.DataDevolucao;
        }
        internal void Excluir(int idSelecionado)
        {
            Emprestimo emprestimo = SelecionarPorId(idSelecionado);
            _listaRegistro.Remove(emprestimo);
        }
    }
}
