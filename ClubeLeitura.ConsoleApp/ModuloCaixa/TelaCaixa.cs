using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : TelaBase
    {
        public RepositorioCaixa repositorioCaixa = null;

        internal void InserirNovoCaixa(RepositorioCaixa _repositorioCaixa)
        {
            repositorioCaixa = _repositorioCaixa;
            Console.Clear();
            Console.WriteLine("Inserir Caixa");
            Console.WriteLine();
            Caixa novaCaixa = ObterCaixa();
            repositorioCaixa.Inserir(novaCaixa);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Caixa inserida com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
        }
        public bool VisualizarCaixas(bool mensagemVoltarMenuInicial)
        {
            List<Caixa> listaCaixas = repositorioCaixa.ListarTodos();
            if (listaCaixas.Count == 0) { return false; }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-5} | {1,-15} | {2} ",
                "Id", "Etiqueta", "Cor");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            foreach (Caixa caixa in listaCaixas)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2} ",
                    caixa.Id, caixa.Etiqueta, caixa.Cor);

            }
            if (mensagemVoltarMenuInicial)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
                Console.ResetColor();
                Console.ReadKey();
            }
            return true;
        }
        public void VisualizarCaixas()
        {
            List<Caixa> listaCaixas = repositorioCaixa.ListarTodos();
            if (listaCaixas.Count == 0) 
            {
                Console.WriteLine("Lista vazia");
                return; 
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-5} | {1,-15} | {2} ",
                "Id", "Etiqueta", "Cor");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            foreach (Caixa caixa in listaCaixas)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2} ",
                    caixa.Id, caixa.Etiqueta, caixa.Cor);

            }
        }
        internal void EditarCaixa(RepositorioCaixa _repositorioCaixa)
        {
            repositorioCaixa = _repositorioCaixa;
            Console.Clear();
            Console.WriteLine("Editar Caixa");
            Console.WriteLine();
            VisualizarCaixas();
            Console.WriteLine();
            int idEncontrado = EncontrarIdCaixa(_repositorioCaixa);
            Caixa caixaAtualizado = ObterCaixa();
            repositorioCaixa.Editar(idEncontrado, caixaAtualizado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Caixa editada com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        internal void ExcluirCaixa(RepositorioCaixa _repositorioCaixa)
        {
            repositorioCaixa = _repositorioCaixa;
            Console.Clear();
            Console.WriteLine("Excluir Revista");
            Console.WriteLine();
            VisualizarCaixas();
            Console.WriteLine();
            int idSelecionado = EncontrarIdCaixa(_repositorioCaixa);
            repositorioCaixa.Excluir(idSelecionado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Caixa excluida com sucesso");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de inicial.");
            Console.ResetColor();
            Console.ReadKey();
        }
        

        internal Caixa ObterCaixa()
        {
            Caixa caixa;
            Console.WriteLine("Digite o Etiqueta");
            string etiqueta = Console.ReadLine();
            Console.WriteLine("Digite a Cor");
            string cor = Console.ReadLine();
            caixa = new Caixa(etiqueta, cor);
            return caixa;
        }
        internal int InteragirMenuCadastroCaixa()
        {
            Console.Clear();
            Console.WriteLine("Menu caixa");
            Console.WriteLine();
            Console.WriteLine("Selecione a opcao desejada");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar uma caixa");
            Console.WriteLine("[2] Vizualizar todas as caixas");
            Console.WriteLine("[3] Editar uma caixa");
            Console.WriteLine("[4] Excluir uma caixa");
            Console.WriteLine("[5] Menu inicial");
            Console.WriteLine();
            int opcaoMenuCaixa = Convert.ToInt32(Console.ReadLine());
            return opcaoMenuCaixa;
        }
        internal int EncontrarIdCaixa(RepositorioCaixa _repositorioCaixa)
        {
            repositorioCaixa = _repositorioCaixa;
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.Write("Digite o Id da caixa: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioCaixa.SelecionarPorId(idSelecionado) == null;
                if (idInvalido)
                {
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);
            return idSelecionado;
        }
    }
}
