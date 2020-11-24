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
    public class ProjetoData : Data
    {
        public void Create(Projeto projeto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"INSERT INTO Projeto VALUES (@areaatuacao, @descrcontratante)";

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@idprojeto", projeto.IdProjeto);
            cmd.Parameters.AddWithValue("@descricao", projeto.Descricao);

            // Execução da string qld no banco
            cmd.ExecuteNonQuery();
        }

        public List<Projeto> Read()
        {
            List<Projeto> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM Projeto";

                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Projeto>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Projeto projeto= new Projeto();

                    projeto.IdProjeto = (int)reader["IdProjeto"];
                    projeto.Descricao= (string)reader["Descricao"];

                    lista.Add(projeto);
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }

        public void Update(Projeto projeto)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"UPDATE Projeto
                                    SET IdProjeto = @idprojeto, Descricao = @descricao
                                    WHERE Id = @id";

            cmd.Parameters.AddWithValue("@idprojeto", projeto.IdProjeto);
            cmd.Parameters.AddWithValue("@descricao", projeto.Descricao);

            //IdProjeto = 0;
            //Descricao = null;

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM Projeto WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
