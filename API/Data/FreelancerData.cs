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

            cmd.Parameters.AddWithValue("@nome", freelancer.nome);
            cmd.Parameters.AddWithValue("@login", freelancer.login);
            cmd.Parameters.AddWithValue("@senha", freelancer.senha);
            cmd.Parameters.AddWithValue("@status", freelancer.status);
            cmd.Parameters.AddWithValue("@telefone", freelancer.telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", freelancer.qtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", freelancer.mediaNota);
            cmd.Parameters.AddWithValue("@email", freelancer.email);

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@cpf", freelancer.cpf);
            cmd.Parameters.AddWithValue("@ra", freelancer.ra);
            cmd.Parameters.AddWithValue("@experiencia", freelancer.experiencia);

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
                    cpf = (string)reader["Cpf"], 
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
                    login = (string)reader["Login"], 
                };
            }
            return freelancer;
        }

   public Freelancer Email(string email){
            Freelancer freelancer = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"Select email From pessoa WHERE pessoa.email = @Email";
            cmd.Parameters.AddWithValue("@Email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            freelancer = new Freelancer
                {
                    email = (string)reader["email"], 
                };
            }
            return freelancer;
        }


           public Freelancer Ra(string ra){
            Freelancer freelancer = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"Select ra From freelancer WHERE freelancer.ra = @Ra";
            cmd.Parameters.AddWithValue("@Ra", ra);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            freelancer = new Freelancer
                {
                    ra = (string)reader["ra"], 
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
                    id = (int)reader["Id"],
                    nome = (string)reader["Nome"],
                    cpf = (string)reader["Cpf"],
                    login = (string)reader["Login"],
                    senha = (string)reader["Senha"],
                    status = (int)reader["Status"],
                    telefone = (string)reader["Telefone"],
                    qtdProjetos = (int)reader["QtdProjetos"],
                    mediaNota = (decimal)reader["MediaNota"],
                    email = (string)reader["Email"],
                    ra = (string)reader["Ra"],
                    experiencia = (string)reader["Experiencia"]
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

            cmd.Parameters.AddWithValue("@id", freelancer.id);
            cmd.Parameters.AddWithValue("@nome", freelancer.nome);
            cmd.Parameters.AddWithValue("@login", freelancer.login);
            cmd.Parameters.AddWithValue("@senha", freelancer.senha);
            cmd.Parameters.AddWithValue("@status", freelancer.status);
            cmd.Parameters.AddWithValue("@telefone", freelancer.telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", freelancer.qtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", freelancer.mediaNota);
            cmd.Parameters.AddWithValue("@email", freelancer.email);

            cmd.Parameters.AddWithValue("@ra", freelancer.ra);
            cmd.Parameters.AddWithValue("@experiencia", freelancer.experiencia);

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
