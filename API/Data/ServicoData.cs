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
        public void Create(Servico servicos)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
                        
            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"exec AddServico @valor, @descServico, @id_contrato, @id_projeto ";

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@descServico", servicos.descricaoServico);
            cmd.Parameters.AddWithValue("@valor", servicos.valor);
            cmd.Parameters.AddWithValue("@id_contrato", servicos.contratonr);
            cmd.Parameters.AddWithValue("@id_projeto", servicos.idProjeto);

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

                    servico.valor = (decimal)reader["Valor"];
                    

                    lista.Add(servico);
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }

   public List<Servico> LerContrato(int nrContrato)
        {
            List<Servico> lista = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM Servico where servico.contrato_nr = @nr";
                cmd.Parameters.AddWithValue("@nr", nrContrato);
                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Servico>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Servico servico = new Servico();
                    servico.contratonr = (int)reader["contrato_nr"];
                    servico.descricaoServico = (string)reader["descricaoServico"];
                    servico.idProjeto = (int)reader["projeto_id"];
                    servico.valor = (decimal)reader["valor"];
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

            cmd.Parameters.AddWithValue("@codigo", servico.valor);

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
