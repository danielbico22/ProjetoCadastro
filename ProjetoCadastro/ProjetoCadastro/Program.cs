using System;

namespace ProjetoCadastro
{  
    class Program
    {
        
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = MenuOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                
                    case "2":
                        InserirNovaSerie();
                        break;
                
                    case "3":
                        AtualizarConteudo();
                        break;
               
                    case "4":
                        ExcluirConteudo();
                        break;
                
                    case "5":
                        VisualizarSerie();
                        break;
                
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = MenuOpcaoUsuario();
            }

            Console.WriteLine("Agradecemos a preferência e volte sempre!");
            Console.ReadLine();
        }

        
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries:");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "**Excluído**" : ""));
            }
        }

        private static string MenuOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Projeto cadastro operando!");
            Console.WriteLine("Insira uma opçao do menu:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar conteúdo");
            Console.WriteLine("4 - Excluir conteúdo");
            Console.WriteLine("5 - Visualizar conteúdo");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair do menu");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }

        private static void InserirNovaSerie()
        {
            Console.WriteLine("Inserir nova série:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = (Console.ReadLine());

            Console.Write("Digite o ano de estreia: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite palavras-chave da sinopse: ");
            string entradaSinopse = (Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        sinopse: entradaSinopse);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarConteudo()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = (Console.ReadLine());

            Console.Write("Digite o ano de estreia: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite palavras-chave da sinopse: ");
            string entradaSinopse = (Console.ReadLine());

            Serie atualizaConteudo = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        sinopse: entradaSinopse);

            repositorio.Atualiza(indiceSerie, atualizaConteudo);
        }

        private static void ExcluirConteudo()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }
    }

 

}
