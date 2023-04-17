using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    internal class RepositorioCaixa : RepositorioBase
    {
        internal void PopularListaCaixa()
        {
            Caixa caixaUm = new Caixa(1, "SuperMercado", "Verde");
            Caixa caixaDois = new Caixa(2, "Caixa Plastico", "Transparente");
            Caixa caixaTres = new Caixa(3, "Gaveta da Cama", "Medeira");
            _listaRegistro.Add(caixaUm);
            _listaRegistro.Add(caixaDois);
            _listaRegistro.Add(caixaTres);
        }
        internal List<Caixa> ListarTodos()
        {
            List<object> listaGenerica = _listaRegistro;
            List<Caixa> listaTipada = listaGenerica.Cast<Caixa>().ToList();
            return listaTipada;
        }
        internal void Inserir(Caixa caixa)
        {
            caixa.Id = Id;
            _listaRegistro.Add(caixa);
            IncrementarId();
        }
        internal Caixa SelecionarPorId(int idSelecionado)
        {
            Caixa caixa = null;
            foreach (Caixa _caixa in _listaRegistro)
            {
                if (_caixa.Id == idSelecionado)
                {
                    caixa = _caixa;
                    break;
                }
            }
            return caixa;
        }
        internal void Editar(int id, Caixa caixaAtualizada)
        {
            Caixa caixa = SelecionarPorId(id);
            caixa.Etiqueta = caixaAtualizada.Etiqueta;
            caixa.Cor = caixaAtualizada.Cor;
        }
        internal void Excluir(int idSelecionado)
        {
            Caixa caixa = SelecionarPorId(idSelecionado);
            _listaRegistro.Remove(caixa);
        }
    }
}
