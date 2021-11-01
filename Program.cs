using Dio.Entretenimento.Classes;
using Dio.Entretenimento.Enums;
using System;
using System.Collections.Generic;
namespace Dio.Entretenimento
{
		
    class Program
    {
        
		static SerieRepositorio serieRepositorio = new SerieRepositorio();
		static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
		
		static void Main(string[] args)
        {
   			
			Console.WriteLine("DIO Entretenimento a seu dispor!!!"+ Environment.NewLine);
			Console.WriteLine("Informe F para filmes, S para séries ou X para sair." + Environment.NewLine);   
			string opcaoUsuario = Console.ReadLine();
			opcaoUsuario = opcaoUsuario.ToUpper();
			while (opcaoUsuario!= "X")
			{
				if (opcaoUsuario=="S")
				{
					opcaoUsuario = ObterOpcaoSerie();
					switch (opcaoUsuario)
					{
						case "1":
							ListarSeries();
							break;
						case "2":
							InserirSerie();
						break;
						case "3":
							AtualizarSerie();
							break;
						case "4":
							ExcluirSerie();
							break;
						case "5":
							VisualizarSerie();
							break;
						case "C":
							Console.Clear();
							break;

						case "X":
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				if (opcaoUsuario=="F")
				{
					opcaoUsuario = ObterOpcaoFilme();
					switch (opcaoUsuario)
					{
						case "1":
							ListarFilme();
							break;
						case "2":
							InserirFilme();
						break;
						case "3":
							AtualizarFilme();
							break;
						case "4":
							ExcluirFilme();
							break;
						case "5":
							VisualizarFilme();
							break;
						case "C":
							Console.Clear();
							break;
						case "X":
							break;

						default:
							Console.WriteLine("Opção inválida");
							break;
					}
				}

				Console.WriteLine(Environment.NewLine+"Informe F para filmes, S para séries ou X para sair.\n");   
				opcaoUsuario = Console.ReadLine().ToUpper();

			}

			Console.WriteLine(Environment.NewLine+"Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			int a = 1;
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			a = Confirma("Exclusao");
			if (a == 1) { serieRepositorio.Exclui(indiceSerie); }

		}
		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			int a = Confirma("Exclusao");
			if (a == 1) { filmeRepositorio.Exclui(indiceFilme); }
			
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = serieRepositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = filmeRepositorio.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
			int a = Confirma("Aleterações");
			if (a == 1)
			{
				Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										excluido: false);

				serieRepositorio.Atualiza(indiceSerie, atualizaSerie);
			}
		}

		private static void AtualizarFilme()
		{
			Console.Write("Digite o id da série: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Estréia do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();
			int a = Confirma("Aleterações");
			if (a == 1)
			{
				Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										excluido: false);


				filmeRepositorio.Atualiza(indiceFilme, atualizaFilme);
			}
		}
		
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = serieRepositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void ListarFilme()
		{
			Console.WriteLine("Listar filmes");

			var lista = filmeRepositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.RetornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.RetornaId(), filme.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

private static void InserirSerie()
		{
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Estréia: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da série: ");
			string entradaDescricao = Console.ReadLine();
			int a = Confirma("Inclusão");
			if (a==1)
            {
				Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										excluido: false);

				serieRepositorio.Insere(novaSerie);
            }
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Estréia: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();
			int a = Confirma("Inclusão");
			if (a == 1)
			{
				Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										excluido: false);

				filmeRepositorio.Insere(novoFilme);
			}
		}

        private static string ObterOpcaoSerie()
		{
		 
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
			var opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
			
			
		}
		private static string ObterOpcaoFilme()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar filmes");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Atualizar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
			var opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;			
		}
		public static int Confirma(string entrada)
		{
			int a = 1;
			Console.WriteLine($"Confirme" + entrada + " 1- Sim 0 - não");
            a = Convert.ToInt32(Console.ReadLine());
			return a;

		}
	}
}
