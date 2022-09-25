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
                //ConsultarTodosClientesAtivos();
                case 6:
                //InformarRendaMedia();
                case 7:
                    InformarAniversarios();
                    break;
                case 8:
                //ConsultarClienteCodigo()
                case 9:
                    //ConsultarClienteNome()
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
            //TODO: Ugo vai fazer essa função

        }

        static void ExcluirCliente()
        {


        }

        static void ConsultarTodosClientes()
        {
            Cabecalho("Consultar todos os clientes");
            Console.WriteLine("Codigo\t\tNome");
            Console.WriteLine("================================");
            foreach (KeyValuePair<int, string> linha in _cadastro)
            {
                string[] vetor = linha.Value.Split(';');
                Console.WriteLine("{0}\t\t{1}", linha.Key, vetor[1]);
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
}
}