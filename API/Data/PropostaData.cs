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
    public class PropostaData : Data
    {
        public void Create(Proposta proposta)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"INSERT INTO Proposta VALUES (@totalproposto, @descricao, @prazo)";

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@totalproposto", proposta.totalProposto);
            cmd.Parameters.AddWithValue("@descricao", proposta.descricao);
            cmd.Parameters.AddWithValue("@prazo", proposta.prazo);

            // Execução da string qld no banco
            cmd.ExecuteNonQuery();
        }

        public List<Proposta> Read()
        {
            List<Proposta> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM Proposta";

                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Proposta>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Proposta proposta = new Proposta();

                    proposta.totalProposto = (double)reader["TotalProposto"];
                    proposta.descricao = (string)reader["Descricao"];
                    proposta.prazo = (DateTime)reader["Prazo"];

                    lista.Add(proposta);

                    
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }

        public void Update(Proposta proposta)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"UPDATE Proposta
                                    SET TotalProposto = @totalproposto, Descricao = @descricao, Prazo = @prazo
                                    WHERE Id = @id";

            cmd.Parameters.AddWithValue("@totalproposto", proposta.totalProposto);
            cmd.Parameters.AddWithValue("@descricao", proposta.descricao);
            cmd.Parameters.AddWithValue("@prazo", proposta.prazo);

            //TotalProposto = 0;
            //Descricao = null;
            //Prazo = DateTime.Today;

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM Proposta WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
