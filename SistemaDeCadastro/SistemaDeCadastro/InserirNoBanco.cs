using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaDeCadastro
{
    class InserirNoBanco
    {
        private string Nome;

        private string Celular;

        private string Email;

        private int Id;
        public void SetNomeDB(string nome)
        {
            this.Nome = nome;
        }
        public void SetCelularDB(string celular)
        {
            this.Celular = celular;
        }
        public void SetEmailDB(string email)
        {
            this.Email = email;
        }
        public void SetIdDb(int id)
        {
            this.Id = id;
        }
        private string Conexao = "Server=Localhost;" +
                "DataBase=cadastro;" +
                "Uid=root;"
                + "Pwd=root;";

        public void InserirRegistro()
        {
            string query = "INSERT INTO usuarios (nome, email, celular) VALUES (@valor1, @valor2, @valor3)";

            //Abre uma conexão com Bd usando os parâmentros da variavél Conexao e armazena no obj conn
            using (MySqlConnection conn = new MySqlConnection(Conexao))
            {
                try
                {
                    //Tenta abrir a conexão com o banco
                    conn.Open();

                    //MySqlCommand armazena o obj conn e a query no novo obj cmd 
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //Atribui os valores corretos para a Query evitando o SQL injetion 
                        cmd.Parameters.AddWithValue("@valor1", this.Nome);
                        cmd.Parameters.AddWithValue("@valor2", this.Celular);
                        cmd.Parameters.AddWithValue("@valor3", this.Email);

                        //Atribui o resultado para a variavel linhasAfetadas
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Cadastro concluído com Sucesso");
                            
                            Console.WriteLine("Pressione ENTER para continuar ...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Nenhum dado foi inserido");
                            
                            ENTER();
                        }
                    }
                }
                //MySqlException retorna um erro de dentro do MySQL
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erro de MySQL: {ex.Number} - {ex.Message}");
                }
            }
        }
        public void Listar()
        {
            string query = "SELECT * FROM usuarios;";
            using (MySqlConnection conn = new MySqlConnection(Conexao))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader verificar = cmd.ExecuteReader())

                            //Verifica se possui colunas na tabela 
                            if (verificar.HasRows)   
                            {
                            Console.WriteLine("Listagem de usuários:\n");
                            //Enquanto o tiver linhas de registro 
                            while (verificar.Read())
                            {
                                //Armazena os dados de cada tabela em sua respectiva variável
                                int id = Convert.ToInt32(verificar["id"]);
                                string nome = verificar["nome"].ToString();
                                string email = verificar["email"].ToString();
                                string celular= verificar["celular"].ToString();

                                Console.WriteLine($"ID: {id}, Nome: {nome}, Celular: {email}, E-Mail: {celular}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum usuário encontrado.");

                            ENTER();
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex}");
                }
            }
        }
        public void DeletarUsuarios()
        {
            string query = "DELETE FROM usuarios WHERE id = @value";
            using (MySqlConnection conn = new MySqlConnection(Conexao))
            {
                try
                { 
                   conn.Open();
                   using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@value", this.Id);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if(linhasAfetadas > 0)
                        {
                            Console.WriteLine("Usuário deletado com Sucesso!");

                            ENTER();
                        }
                        else
                        {
                            Console.WriteLine("Nenhum usuário deletado!");
                        }

                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erro: {ex}");

                    ENTER();
                }
            }
        }
        public void ENTER()
        {
            Console.WriteLine("Aperte ENTER para continuar");
            Console.ReadLine();
            Console.Clear();
        }
    }
}