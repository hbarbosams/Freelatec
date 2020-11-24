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
    public class ServicoData : Data
    {
        public void Create(Servico servico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"INSERT INTO Servico (descricao, valor) VALUES (@descricao , @valor)";

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@descricao", servico.Descricao);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);

            // Execução da string qld no banco
            cmd.ExecuteNonQuery();

        }

        public List<Servico> Read()
        {
            List<Servico> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM Servico";

                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Servico>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Servico servico = new Servico();

                    servico.Valor = (double)reader["Valor"];
                    

                    lista.Add(servico);
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }

        public void Update(Servico servico)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"UPDATE servico
                                    SET Valor = @valor
                                    WHERE Id = @id";

            cmd.Parameters.AddWithValue("@codigo", servico.Valor);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM servico WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
