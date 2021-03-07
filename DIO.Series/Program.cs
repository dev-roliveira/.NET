using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    
                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSeries();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSeries();
                        break;
                    
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o ID da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série");
             int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja Realmente excluir a Série?");
            Console.WriteLine("Y / N");
            string selecao = Console.ReadLine().ToUpper(); 
            if (selecao == "Y"){
                repositorio.Excluir(indiceSerie);
                Console.WriteLine("Serie Excluída!");
            }
            else{
                Console.WriteLine("Exclusão cancelada.");
            }
        }

        private static void AtualizarSeries()
        {
             Console.WriteLine("Digite o ID da Série");
             int indiceSerie = int.Parse(Console.ReadLine());
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));                
            }
            
            Console.WriteLine("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Serie");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie (id: indiceSerie,
                                             genero: (Genero)entradaGenero,
                                             titulo: entradaTitulo,
                                             ano: entradaAno,
                                             descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie,atualizaSerie);
           
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Serie");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));                
            }
            
            Console.WriteLine("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                             genero: (Genero)entradaGenero,
                                             titulo: entradaTitulo,
                                             ano: entradaAno,
                                             descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
                                
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();

            if (lista.Count ==0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID{0}: - {1}", serie.retornaId(), serie.retornaTitulo(), (excluido ? " # Excluido # " : ""  ));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Série");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
