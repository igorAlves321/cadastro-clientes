using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.IO;

namespace Primeiro_Programa
{
    internal class Program
    {
        static Dictionary<int, string> _cadastro = new Dictionary<int, string>();
        static string _fileName = @"c:\temp\csharp\cadastro.txt";

        static void Main(string[] args)
        {
            int opcao = 0;
            LerArquivo();
            while (opcao != 10)
            {
                Cabecalho("Menu Principal");
                Menu();
                Console.Write("Digite um opção: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Opção Inválida, digite novamente!");
                    Console.ReadKey();
                }
                SelecionarOpcaoDoMenu(opcao);
            }
        }

        /// <summary>
        /// Mostrar o Cabelho do Menu principal ou da opção selecionada
        /// </summary>
        /// <param name="titulo">Titulo atual da ação</param>
        static void Cabecalho(string titulo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("==================================================");
            Console.WriteLine("= " + titulo);
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        static void Cabecalho1(string titulo1)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("==================================================");
            Console.WriteLine("= " + titulo1);
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
        }
        /// <summary>
        /// Mostra as opções do Menu
        /// </summary>
        static void Menu()
        {
            Console.WriteLine(" 1 - Cadastrar Cliente");
            Console.WriteLine(" 2 - Alterar dados de um cliente");
            Console.WriteLine(" 3 - Excluir dados de um cliente");
            Console.WriteLine(" 4 - Listar todos os clientes");
            Console.WriteLine(" 5 - Consultar todos os clientes ativos");
            Console.WriteLine(" 6 - Informar a média da renda anual dos clientes ativos");
            Console.WriteLine(" 7 - Informar os aniversariantes do dia");
            Console.WriteLine(" 8 - Pesquisar um cliente pelo código");
            Console.WriteLine(" 9 - Pesquisar um cliente pelo nome");
            Console.WriteLine(" 10 - Sair");
            Console.WriteLine();
        }
        /// <summary>
        /// Chama a função escolhida pelo usuário
        /// </summary>
        /// <param name="opcao">Opção digitada pelo usuário</param>
        static void SelecionarOpcaoDoMenu(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    CriarNovoCliente();
                    break;
                case 2:
                    AlterarCliente();
                    break;
                case 3:
                    ExcluirCliente();
                    break;
                case 4:
                    ConsultarTodosClientes();
                    break;
                case 5:
                    ConsultarTodosClientesAtivos();
                    break;
                case 6:
                    InformarRendaMedia();
                    break;
                case 7:
                    InformarAniversarios();
                    break;
                case 8:
                    ConsultarClienteCodigo();
                    break;
                case 9:
                    ConsultarClienteNome();
                    break;
                case 10:
                    break;
                default:
                    Console.WriteLine("Opção fora do intervalor de 1 até 10, por favor, digite novamente!!!");
                    Console.ReadKey();
                    break;
            }
        }

        static void CriarNovoCliente()
        {
            Cabecalho("Inserir um novo cliente");
            //Console.Write("Código........: ");
            //int codigo = int.Parse(Console.ReadLine());
            Console.Write("Nome..........: ");
            string nome = Console.ReadLine();
            Console.Write("Celular.......: ");
            string celular = Console.ReadLine();
            Console.Write("e-mail........: ");
            string email = Console.ReadLine();
            Console.Write("Dta Nascimento: ");
            string dtaNascimento = Console.ReadLine();
            Console.Write("Renda Anual...: ");
            float rendaAnual = float.Parse(Console.ReadLine());
            Console.Write("Ativo.........: ");
            int ativo = int.Parse(Console.ReadLine());
            //-----------------------------------------
            // Obter um codigo disponivel na lista
            //-----------------------------------------
            int codigo = ObterNovoCodigoCliente();
            //-----------------------------------------
            string linhaCadastro = $"{codigo};{nome};{celular};{email};{dtaNascimento};{rendaAnual};{ativo}";
            _cadastro.Add(codigo, linhaCadastro);
            GravarDadosArquivo(linhaCadastro);
        }

        static void AlterarCliente()
        {
            Cabecalho("Alterar cadastro de cliente");
            Console.Write("Insira o ID do cliente para alterar seus dados: ");
            int codigo = int.Parse(Console.ReadLine());
            bool alterou = false;

            foreach (KeyValuePair<int, string> linha in _cadastro)
            {
                if (linha.Key == codigo)

                {
                    Console.WriteLine("Por favor, insira os dados do cliente:");
                    _cadastro.Remove(codigo);
                    Console.Write("Nome..........: ");
                    string nome = Console.ReadLine();
                    Console.Write("Celular.......: ");
                    string celular = Console.ReadLine();
                    Console.Write("e-mail........: ");
                    string email = Console.ReadLine();
                    Console.Write("Dta Nascimento: ");
                    string dtaNascimento = Console.ReadLine();
                    Console.Write("Renda Anual...: ");
                    float rendaAnual = float.Parse(Console.ReadLine());
                    Console.Write("Ativo.........: ");
                    int ativo = int.Parse(Console.ReadLine());

                    string linhaCadastro = $"{codigo};{nome};{celular};{email};{dtaNascimento};{rendaAnual};{ativo}";
                    _cadastro.Add(codigo, linhaCadastro);

                    alterou = true;
                    break;
                }
            }

            if (alterou)
            {
                File.Delete(_fileName);
                RecarregarArquivo();
            }
            else
            {
                Console.WriteLine("Esse ID não está registrado...");
                Console.ReadKey();
            }
        }
        static void RecarregarArquivo()
        {
            using (StreamWriter outputFile = new StreamWriter(_fileName))
            {
                foreach (KeyValuePair<int, string> linha in _cadastro)
                {
                    string[] campos = linha.Value.Split(';');
                    string linhaCadastro = String.Join(";", campos);
                    outputFile.WriteLine(linhaCadastro);
                }
            }
        }

        static float InformarRendaMedia()
        {
            int rendaCount = 0;
            float rendaMedia = 0, somaRenda = 0;
            foreach (KeyValuePair<int, string> clientes in _cadastro)
            {
                string[] vetor = clientes.Value.Split(';');
                somaRenda += float.Parse(vetor[5]);
                rendaCount++;
            }
            rendaMedia = somaRenda / rendaCount;
            Cabecalho1("Media da Renda Anual dos Clientes");
            Console.WriteLine($"A media da renda atual com a soma de todos os clientes é: R${rendaMedia}");
            Console.ReadKey();
            return 0;
        }

        static void ExcluirCliente()
        {
            //by Sérgio Renato Steglich
            Cabecalho("Excluir o cliente");
            Console.Write("Codigo........: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.WriteLine("Confirma exlusão? S ou N");
            string confirma = Console.ReadLine();
            if (confirma == "S" || confirma == "s")
            {
                //foreach (KeyValuePair<int, string> linha in _cadastro) {             
                _cadastro.Remove(codigo);
                Console.WriteLine("\t\t Foi excluido, clique uma tecla... 4 ");
                Console.ReadKey();
                //}
            }
            else
            {
                Console.WriteLine("\t\t Não foi excluido, clique uma tecla... ");
                Console.ReadKey();
            }
        }

        static void ConsultarTodosClientes()
        {
            Cabecalho("Consultar todos os clientes");
            Console.WriteLine("ID\tNome\t\t\t\tContato\t\t\tAniversario\t\tRenda");
            Console.WriteLine("========================================================================" +
                "==============================");
            foreach (KeyValuePair<int, string> linha in _cadastro)
            {
                string[] vetor = linha.Value.Split(';');
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t\t{4}", linha.Key, vetor[1], vetor[2] +
                    "  " + vetor[3], vetor[4], "R$ " + vetor[5]);
            }
            Console.ReadKey();
        }

        static void ConsultarTodosClientesAtivos()
        {


            Cabecalho("Pesquisar cliente por ativo");
            Console.Write("Ativo........: ");
            string ativo = Console.ReadLine();
            Console.WriteLine("================================");

            foreach (KeyValuePair<int, string> linha in _cadastro)
            {

                string[] vetor = linha.Value.Split(';');
                if (1 == int.Parse(vetor[6]))
                {
                    Console.WriteLine("{0}\t\t{1}", linha.Key, vetor[6]);
                }

            }

            Console.ReadKey();
        }


        static void GravarDadosArquivo(string linhaCadastro)
        {
            using (StreamWriter outputFile = new StreamWriter(_fileName, true))
            {
                outputFile.WriteLine(linhaCadastro);
            }
        }


        static void ConsultarClienteNome()
        {
            Cabecalho("Pesquisar cliente por nome...");
            Console.Write("Nome........: ");
            string nome = Console.ReadLine();
            Cabecalho1("O resultado da pesquisa é:");
            Console.WriteLine("================================");
            Console.WriteLine("Codigo\t\tNome\t\t\tContato");

            foreach (KeyValuePair<int, string> linha in _cadastro)
            {
                if (linha.Value.Contains(nome))
                {
                    string[] vetor = linha.Value.Split(';');
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", linha.Key, vetor[1], vetor[2] + "  " + vetor[3]);
                }
            }

            int op = 1;
            while (op != 0)
            {
                Console.WriteLine("\n\nSelecione uma das opções:");
                Console.WriteLine("1 - Repetir");
                Console.WriteLine("Clique outra tecla para sair... 2");
                op = int.Parse(Console.ReadLine());
                if (op != 1)
                {
                    break;
                }

                else if (op == 1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    ConsultarClienteNome();
                    Console.ReadKey();
                }
                else if (op != 1)
                {
                    Console.WriteLine();
                    Console.Clear();
                    Console.ReadKey();

                }

            }

            Console.ReadKey();
        }

        static void LerArquivo()
        {
            foreach (string line in System.IO.File.ReadLines(_fileName))
            {
                string[] campos = line.Split(';');
                _cadastro.Add(int.Parse(campos[0]), line);
            }
        }



        static void InformarAniversarios()
        {

            string hoje = DateTime.Now.ToShortDateString();
            Cabecalho(" Aniversariantes do dia de hoje:" + hoje);

            Console.ReadKey();
        }

        static int ObterNovoCodigoCliente()
        {
            int codigo = 0;
            int codigoDB;
            foreach (KeyValuePair<int, string> linha in _cadastro)
            {
                codigoDB = linha.Key;
                if (codigoDB > codigo)
                    codigo = codigoDB;
            }
            return ++codigo;

            Console.ReadLine();
        }

        static void ConsultarClienteCodigo()
        {
            Cabecalho("Pesquisar cliente por codigo");
            Console.Write("Codigo........: ");
            string codigo = Console.ReadLine();
            Console.WriteLine("================================");

            foreach (KeyValuePair<int, string> linha in _cadastro)
            {
                if (linha.Value.Contains(codigo))
                {
                    string[] vetor = linha.Value.Split(';');
                    Console.WriteLine("{0}\t\t{1}", linha.Key, vetor[1]);
                }
            }
            Console.ReadKey();
        }
    }
}