using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
namespace SistemaDeCadastro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            InserirNoBanco i = new InserirNoBanco();
            while(opcao != 4) 
            {
            Console.WriteLine("\n-|Bem-vindo ao Sistema de Cadastro de Usuários|-\n");

            Console.WriteLine("1- Para cadastrar um Usuário");
            Console.WriteLine("2- Para listar todos os Usuários");
            Console.WriteLine("3- Para deletar um Usuário");
            Console.WriteLine("4- Para sair do Programa");

            Console.Write("\nDigite a sua opção: ");
            opcao = int.Parse(Console.ReadLine());
            Console.Clear();

                switch (opcao)
                {
                    case 1:
                        //Comando para inserir no banco!

                        Console.Write("Digite o nome do Usuário a ser Cadastrado: ");
                        string nome = Console.ReadLine();
                        i.SetNomeDB(nome);

                        Console.Write("Digite o telefone do Usuário a ser Cadastrado: ");
                        string celular = Console.ReadLine();
                        i.SetCelularDB(celular);

                        Console.Write("Digite o email do Usuário a ser Cadastrado: ");
                        string email = Console.ReadLine();
                        i.SetEmailDB(email);

                        i.InserirRegistro();

                        break;
                    case 2:
                        //Para listar todos os Usuários 
                        i.Listar();

                        i.ENTER();

                        break;


                    case 3:
                        //Para deletar um usuário
                        i.Listar();
                        Console.Write("Digite o ID do usuário a ser deletado: ");
                        int id = int.Parse(Console.ReadLine());
                        
                        i.SetIdDb(id);

                        i.DeletarUsuarios();

                        i.ENTER();

                        break;                                     
                }
                if(opcao == 4)
                {
                    Console.WriteLine("Obrigado por Usar o Sistema de Cadastro!");
                    break;
                }
            }
        }
    }
}
