using API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace API.Data
{
    public class PessoaData : Data
    {
        //Create

        public void Create(Pessoa pessoa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"INSERT INTO Pessoa (nome, login, senha, status, telefone, qtdprojetos, medianota, email)
                                VALUES (@nome, @login, @senha, @status, @telefone, @qtdprojetos, @medianota, @email)";
            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@nome", pessoa.nome);
            cmd.Parameters.AddWithValue("@login", pessoa.login);
            cmd.Parameters.AddWithValue("@senha", pessoa.senha);
            cmd.Parameters.AddWithValue("@status", pessoa.status);
            cmd.Parameters.AddWithValue("@telefone", pessoa.telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", pessoa.qtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", pessoa.mediaNota);
            cmd.Parameters.AddWithValue("@email", pessoa.email) ;

            // Execução da string qld no banco
            cmd.ExecuteNonQuery();
        }

        // Para conseguir utilizar o read
        public List<Pessoa> Read()
        {
            List<Pessoa> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM Pessoa";

                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Pessoa>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Pessoa pessoa = new Pessoa();
                    pessoa.id = (int)reader["IdCliente"];
                    pessoa.nome = (string)reader["Nome"];
                    pessoa.login = (string)reader["Login"];
                    pessoa.senha = (string)reader["Senha"];
                    pessoa.status = (int)reader["Status"];
                    pessoa.telefone = (string)reader["Telefone"];
                    pessoa.qtdProjetos = (int)reader["QtdProjetos"];
                    pessoa.mediaNota = (decimal)reader["MediaNota"];
                    pessoa.email = (string)reader["Email"];

                    lista.Add(pessoa);
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }

        public Pessoa Read(int id)
        {
            Pessoa pessoa = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            cmd.CommandText = @"SELECT * FROM Pessoa WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            // verifica se apos a consulta retornou um registro
            if (reader.Read())
            {
                // Instancia o objeto cliente outra forma de ler
                pessoa = new Pessoa
                {
                    id = (int)reader["Id"],
                    nome = (string)reader["Nome"],
                    login = (string)reader["Login"],
                    senha = (string)reader["Senha"],
                    status = (int)reader["Status"],
                    telefone = (string)reader["Telefone"],
                    qtdProjetos = (int)reader["QtdProjetos"],
                    mediaNota = (decimal)reader["MediaNota"],
                    email = (string)reader["Email"]
                };
            }
            return pessoa;
        }

        public Pessoa Read(string login)
        {
            Pessoa pessoa = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            cmd.CommandText = @"SELECT * FROM Pessoa WHERE Login = @login";

            cmd.Parameters.AddWithValue("@login", login);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                pessoa = new Pessoa
                {
                    // Criando objeto pessoa que existe no banco
                    id = (int)reader["Id"],
                    nome = (string)reader["Nome"],
                    login = (string)reader["Login"],
                    senha = (string)reader["Senha"],
                    status = (int)reader["Status"],
                    telefone = (string)reader["Telefone"],
                    qtdProjetos = (int)reader["QtdProjetos"],
                    mediaNota = (decimal)reader["MediaNota"],
                    email = (string)reader["Email"],
                };
            }
            return pessoa;
        }

        public void Update(Pessoa pessoa)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"UPDATE Pessoa
                                    SET  Nome = @nome, Login = @login, Senha = @senha,
                                    Status = @status, Telefone = @telefone,
                                    QtdProjetos = @qtdprojetos, MediaNota = @medianota, Email = @email
                                    WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", pessoa.id);
            cmd.Parameters.AddWithValue("@nome", pessoa.nome);
            cmd.Parameters.AddWithValue("@login", pessoa.login);
            cmd.Parameters.AddWithValue("@senha", pessoa.senha);
            cmd.Parameters.AddWithValue("@status", pessoa.status);
            cmd.Parameters.AddWithValue("@telefone", pessoa.telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", pessoa.qtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", pessoa.mediaNota);
            cmd.Parameters.AddWithValue("@email", pessoa.email);
            

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM Pessoa WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
