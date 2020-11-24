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
    public class ContratoData : Data
    {
        public void Create(Contrato contrato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"exec AddContrato @descricao, @status, @notaContratante, @notaFreelancer, @id";

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@descricao", contrato.Descricao);
            cmd.Parameters.AddWithValue("@notacontratante", contrato.NotaContratante);
            cmd.Parameters.AddWithValue("@notafreelancer", contrato.NotaFreelancer);
            cmd.Parameters.AddWithValue("@status", contrato.Status);
            cmd.Parameters.AddWithValue("@id", contrato.Id);
            // Execução da string qld no banco
            cmd.ExecuteNonQuery();

            
        }

        public List<Contrato> Read()
        {
            List<Contrato> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM Contrato";

                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Contrato>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Contrato contrato = new Contrato();
                    contrato.NrContrato = (int)reader["NrContrato"];
                    contrato.DataContrato = (DateTime)reader["DataContrato"];
                    contrato.Total = (double)reader["Total"];
                    contrato.Descricao = (string)reader["Descricao"];
                    contrato.DataInicial = (DateTime)reader["DataInicial"];
                    contrato.NotaContratante = (int)reader["NotaContratante"];
                    contrato.NotaFreelancer = (int)reader["NotaFreelancer"];
                    contrato.Prazo = (DateTime)reader["Prazo"];
                    contrato.Status = (int)reader["Status"];
                    contrato.Taxa = (double)reader["Taxa"];

                    lista.Add(contrato);
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }

        public void Update(Contrato contrato)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"UPDATE Contrato
                                    SET NrContrato = @nrcontrato, DataContrato = @datacontrato, Total = @total, Descricao = @descricao,
                                    DataInicial = @datainicial, NotaContratante = @notacontratante, NotaFreelancer = @notafreelancer
                                    Prazo = @prazo, Status = @status, Taxa = @taxa
                                    WHERE Id = @id";

            cmd.Parameters.AddWithValue("@nrcontrato", contrato.NrContrato);
            cmd.Parameters.AddWithValue("@datacontrato", contrato.DataContrato);
            cmd.Parameters.AddWithValue("@total", contrato.Total);
            cmd.Parameters.AddWithValue("@descricao", contrato.Descricao);
            cmd.Parameters.AddWithValue("@datainicial", contrato.DataInicial);
            cmd.Parameters.AddWithValue("@notacontratante", contrato.NotaContratante);
            cmd.Parameters.AddWithValue("@notafreelancer", contrato.NotaFreelancer);
            cmd.Parameters.AddWithValue("@prazo", contrato.Prazo);
            cmd.Parameters.AddWithValue("@status", contrato.Status);
            cmd.Parameters.AddWithValue("@taxa", contrato.Taxa);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM Contrato WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
