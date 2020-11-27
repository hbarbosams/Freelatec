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

        public Freelancer CPF(string cpf){
            Freelancer freelancer = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"Select cpf From freelancer WHERE freelancer.cpf = @Cpf";
            cmd.Parameters.AddWithValue("@Cpf", cpf);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            freelancer = new Freelancer
                {
                    Cpf = (string)reader["Cpf"], 
                };
            }
            return freelancer;
        }

   public Freelancer Login(string Login){
            Freelancer freelancer = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"Select login From pessoa WHERE pessoa.login = @Login";
            cmd.Parameters.AddWithValue("@Login", Login);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            freelancer = new Freelancer
                {
                    Login = (string)reader["Login"], 
                };
            }
            return freelancer;
        }

   public Freelancer Email(string Email){
            Freelancer freelancer = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"Select email From pessoa WHERE pessoa.email = @Email";
            cmd.Parameters.AddWithValue("@Email", Email);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            freelancer = new Freelancer
                {
                    Email = (string)reader["Email"], 
                };
            }
            return freelancer;
        }


           public Freelancer Ra(string Ra){
            Freelancer freelancer = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"Select ra From freelancer WHERE freelancer.ra = @Ra";
            cmd.Parameters.AddWithValue("@Ra", Ra);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            freelancer = new Freelancer
                {
                    Ra = (string)reader["ra"], 
                };
            }
            return freelancer;
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
