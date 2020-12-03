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

            cmd.Parameters.AddWithValue("@nome", contratante.nome);
            cmd.Parameters.AddWithValue("@login", contratante.login);
            cmd.Parameters.AddWithValue("@senha", contratante.senha);
            cmd.Parameters.AddWithValue("@status", contratante.status);
            cmd.Parameters.AddWithValue("@telefone", contratante.telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", contratante.qtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", contratante.mediaNota);
            cmd.Parameters.AddWithValue("@email", contratante.email);
            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@cnpj", contratante.cnpj);
            cmd.Parameters.AddWithValue("@areaatuacao", contratante.areaAtuacao);
            cmd.Parameters.AddWithValue("@descrcontratante", contratante.descrContratante);

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
                    id = (int)reader["Id"],
                    nome = (string)reader["Nome"],
                    cnpj = (string)reader["Cnpj"],
                    login = (string)reader["Login"],
                    senha = (string)reader["Senha"],
                    status = (int)reader["Status"],
                    telefone = (string)reader["Telefone"],
                    qtdProjetos = (int)reader["QtdProjetos"],
                    mediaNota = (decimal)reader["MediaNota"],
                    email = (string)reader["Email"],
                    areaAtuacao = (string)reader["areaAtuacao"],
                    descrContratante = (string)reader["descrContratante"]
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
                  id = (int)reader["Id"],
                    nome = (string)reader["Nome"],
                    cnpj = (string)reader["Cnpj"],
                    login = (string)reader["Login"],
                    senha = (string)reader["Senha"],
                    status = (int)reader["Status"],
                    telefone = (string)reader["Telefone"],
                    qtdProjetos = (int)reader["QtdProjetos"],
                    mediaNota = (decimal)reader["MediaNota"],
                    email = (string)reader["Email"],
                    areaAtuacao = (string)reader["areaAtuacao"],
                    descrContratante = (string)reader["descrContratante"]
                };
            }
            return contratante;
        }

         public Contratante Cnpj(string cnpj){
            Contratante contratante = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"Select cnpj From contratante WHERE contratante.cnpj = @Cnpj";
            cmd.Parameters.AddWithValue("@Cnpj", cnpj);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            contratante = new Contratante
                {
                    cnpj = (string)reader["cnpj"], 
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

            cmd.Parameters.AddWithValue("@id", contratante.id);
            cmd.Parameters.AddWithValue("@nome", contratante.nome);
            cmd.Parameters.AddWithValue("@login", contratante.login);
            cmd.Parameters.AddWithValue("@senha", contratante.senha);
            cmd.Parameters.AddWithValue("@status", contratante.status);
            cmd.Parameters.AddWithValue("@telefone", contratante.telefone);
            cmd.Parameters.AddWithValue("@qtdprojetos", contratante.qtdProjetos);
            cmd.Parameters.AddWithValue("@medianota", contratante.mediaNota);
            cmd.Parameters.AddWithValue("@email", contratante.email);

            cmd.Parameters.AddWithValue("@areaatuacao", contratante.areaAtuacao);
            cmd.Parameters.AddWithValue("@descrcontratante", contratante.descrContratante);

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
