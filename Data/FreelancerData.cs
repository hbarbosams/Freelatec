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
    public class FreelancerData : Data
    {
        public void Create(Freelancer freelancer)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"exec AddFreela @nome, @login, @senha, @email, @telefone, @qtdProjetos,
                                               @mediaNota, @status, @cpf, @ra, @experiencia";

            cmd.Parameters.AddWithValue("@nome", freelancer.Nome);
            cmd.Parameters.AddWithValue("@login", freelancer.Login);
            cmd.Parameters.AddWithValue("@senha", freelancer.Senha);
            cmd.Parameters.AddWithValue("@status", freelancer.Status);
            cmd.Parameters.AddWithValue("@telefone", freelancer.Telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", freelancer.QtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", freelancer.MediaNota);
            cmd.Parameters.AddWithValue("@email", freelancer.Email);

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@cpf", freelancer.Cpf);
            cmd.Parameters.AddWithValue("@ra", freelancer.Ra);
            cmd.Parameters.AddWithValue("@experiencia", freelancer.Experiencia);

            // Execução da string qld no banco
            cmd.ExecuteNonQuery();

            
        }
 
        public Freelancer Read(string login)
        {
            Freelancer freelancer = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            cmd.CommandText = @"SELECT * FROM  Pessoa, Freelancer WHERE Login = @login AND pessoa.id = Freelancer.freelancer_id";

            cmd.Parameters.AddWithValue("@login", login);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                freelancer = new Freelancer
                {
                    // Criando objeto pessoa que existe no banco
                    Id = (int)reader["Id"],
                    Nome = (string)reader["Nome"],
                    Cpf = (string)reader["Cpf"],
                    Login = (string)reader["Login"],
                    Senha = (string)reader["Senha"],
                    Status = (int)reader["Status"],
                    Telefone = (string)reader["Telefone"],
                    QtdProjetos = (int)reader["QtdProjetos"],
                    MediaNota = (decimal)reader["MediaNota"],
                    Email = (string)reader["Email"],
                    Ra = (string)reader["Ra"],
                    Experiencia = (string)reader["Experiencia"]
                };
            }
            return freelancer;
        }

        public Freelancer Read(int id)
        {
            Freelancer freelancer = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            cmd.CommandText = @"SELECT * FROM Pessoa, freelancer WHERE Id = @id AND Pessoa.id = freelancer.freelancer_id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            // verifica se apos a consulta retornou um registro
            if (reader.Read())
            {
                // Instancia o objeto cliente outra forma de ler
                freelancer = new Freelancer
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["Nome"],
                    Cpf = (string)reader["Cpf"],
                    Login = (string)reader["Login"],
                    Senha = (string)reader["Senha"],
                    Status = (int)reader["Status"],
                    Telefone = (string)reader["Telefone"],
                    QtdProjetos = (int)reader["QtdProjetos"],
                    MediaNota = (decimal)reader["MediaNota"],
                    Email = (string)reader["Email"],
                    Ra = (string)reader["Ra"],
                    Experiencia = (string)reader["Experiencia"]
                };
            }
            return freelancer;
        }

        public void Update(Freelancer freelancer)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"exec UpdateFreela @id, @nome, @login, @senha, @email, @telefone, 
                                                  @qtdProjetos, @mediaNota, @status, @ra, @experiencia";

            cmd.Parameters.AddWithValue("@id", freelancer.Id);
            cmd.Parameters.AddWithValue("@nome", freelancer.Nome);
            cmd.Parameters.AddWithValue("@login", freelancer.Login);
            cmd.Parameters.AddWithValue("@senha", freelancer.Senha);
            cmd.Parameters.AddWithValue("@status", freelancer.Status);
            cmd.Parameters.AddWithValue("@telefone", freelancer.Telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", freelancer.QtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", freelancer.MediaNota);
            cmd.Parameters.AddWithValue("@email", freelancer.Email);

            cmd.Parameters.AddWithValue("@ra", freelancer.Ra);
            cmd.Parameters.AddWithValue("@experiencia", freelancer.Experiencia);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM Freelancer WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
