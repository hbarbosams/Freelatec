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
    public class ContratanteData : Data
    {
        public void Create(Contratante contratante)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"exec AddContratante @nome, @login, @senha, @email, @telefone, @qtdProjetos,
                                                    @mediaNota, @status, @cnpj, @areaAtuacao, @descrContratante";

            cmd.Parameters.AddWithValue("@nome", contratante.Nome);
            cmd.Parameters.AddWithValue("@login", contratante.Login);
            cmd.Parameters.AddWithValue("@senha", contratante.Senha);
            cmd.Parameters.AddWithValue("@status", contratante.Status);
            cmd.Parameters.AddWithValue("@telefone", contratante.Telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", contratante.QtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", contratante.MediaNota);
            cmd.Parameters.AddWithValue("@email", contratante.Email);
            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@cnpj", contratante.Cnpj);
            cmd.Parameters.AddWithValue("@areaatuacao", contratante.AreaAtuacao);
            cmd.Parameters.AddWithValue("@descrcontratante", contratante.DescrContratante);

            // Execução da string qld no banco
            cmd.ExecuteNonQuery();

            
        }

        public Contratante Read(string login)
        {
            Contratante contratante = null;

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"select * from pessoa, contratante where login = @login and pessoa.id = contratante.contratante_id";

            cmd.Parameters.AddWithValue("@login", login);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                contratante = new Contratante
                {
                    // Criando objeto pessoa que existe no banco
                    Id = (int)reader["Id"],
                    Nome = (string)reader["Nome"],
                    Cnpj = (string)reader["Cnpj"],
                    Login = (string)reader["Login"],
                    Senha = (string)reader["Senha"],
                    Status = (int)reader["Status"],
                    Telefone = (string)reader["Telefone"],
                    QtdProjetos = (int)reader["QtdProjetos"],
                    MediaNota = (decimal)reader["MediaNota"],
                    Email = (string)reader["Email"],
                    AreaAtuacao = (string)reader["areaAtuacao"],
                    DescrContratante = (string)reader["descrContratante"]
                };
            }
            return contratante;
        }

        public Contratante Read(int id)
        {
            Contratante contratante = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            cmd.CommandText = @"SELECT * FROM Pessoa, contratante WHERE Id = @id AND Pessoa.id = contratante.contratante_id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            // verifica se apos a consulta retornou um registro
            if (reader.Read())
            {
                // Instancia o objeto cliente outra forma de ler
                contratante = new Contratante
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["Nome"],
                    Cnpj = (string)reader["Cnpj"],
                    Login = (string)reader["Login"],
                    Senha = (string)reader["Senha"],
                    Status = (int)reader["Status"],
                    Telefone = (string)reader["Telefone"],
                    QtdProjetos = (int)reader["QtdProjetos"],
                    MediaNota = (decimal)reader["MediaNota"],
                    Email = (string)reader["Email"],
                    AreaAtuacao = (string)reader["AreaAtuacao"],
                    DescrContratante = (string)reader["DescrContratante"]
                };
            }
            return contratante;
        }

        public void Update(Contratante contratante)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"exec UpdateContratante @id, @nome, @login, @senha, @email, @telefone, @qtdProjetos, 
                                                       @mediaNota, @status, @areaAtuacao, @descrContratante";

            cmd.Parameters.AddWithValue("@id", contratante.Id);
            cmd.Parameters.AddWithValue("@nome", contratante.Nome);
            cmd.Parameters.AddWithValue("@login", contratante.Login);
            cmd.Parameters.AddWithValue("@senha", contratante.Senha);
            cmd.Parameters.AddWithValue("@status", contratante.Status);
            cmd.Parameters.AddWithValue("@telefone", contratante.Telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", contratante.QtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", contratante.MediaNota);
            cmd.Parameters.AddWithValue("@email", contratante.Email);

            cmd.Parameters.AddWithValue("@areaatuacao", contratante.AreaAtuacao);
            cmd.Parameters.AddWithValue("@descrcontratante", contratante.DescrContratante);

            //AreaAtuacao = null;
            //DescrContratante = null;

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM Contratante WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

    }
}
