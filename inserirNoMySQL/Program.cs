using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inserirNoMySQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variavél de conexão com o banco de dados
            string conexao = "Server=Localhost;" +
                "DataBase=cadastro;" +
                "Uid=root;"
                +"Pwd=root";
            //Query para ser executada dentro do banco de dados
            string query = "INSERT INTO usuarios(nome,email,celular,senha) VALUES ('Mauricio'," +
                "'mauricio@gmail.com'," +
                "'499999999'," +
                "'123')";

            //Cria o obj conn com os dados da variavél conexao e
            //using garante que o obj mysqlCommand seja descartado assim que for usado

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    //tenta abrir o banco de dados 
                    conn.Open();

                    //MySqlCommand é uma classe utilizada para executar comandos SQL
                    //Usa dois parâmetros (A Query a ser rodada no banco,
                    //A conexão com o próprio banco)

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //ExecuteNonQuery é um comando usado para executar comandos SQL que não retornam resultados 
                        
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if(linhasAfetadas > 0)
                        {
                            Console.WriteLine($"{linhasAfetadas} linhas foram afetadas!");
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma Linha foi afetada!");
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error {ex}");
                }
            }
        }                       
    }
}