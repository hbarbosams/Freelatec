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
        public Contrato Create(Contrato contrato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"exec AddContrato @descricao, @status, @notaContratante, @notaFreelancer, @id, @prazo, @total";

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@descricao", contrato.descricao);
            cmd.Parameters.AddWithValue("@notacontratante", contrato.notaContratante);
            cmd.Parameters.AddWithValue("@notafreelancer", contrato.notaFreelancer);
            cmd.Parameters.AddWithValue("@status", contrato.status);
            cmd.Parameters.AddWithValue("@id", contrato.contratanteid);
            cmd.Parameters.AddWithValue("@prazo", contrato.prazo);
            cmd.Parameters.AddWithValue("@total", contrato.total);
            // Execução da string qld no banco
           SqlDataReader reader =  cmd.ExecuteReader();
           Contrato novoContrato = new Contrato();
            if (reader.Read())
            {
                    novoContrato.nrContrato = (int)reader["nrContrato"];
            }

            return novoContrato;                     
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
                cmd.CommandText = "SELECT * FROM contrato";
                SqlDataReader reader = cmd.ExecuteReader();
                lista = new List<Contrato>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Contrato contrato = new Contrato();
                    contrato.nrContrato = (int)reader["NrContrato"];
                    contrato.dataContrato = (DateTime)reader["DataContrato"];
                    contrato.total = (decimal)reader["Total"];
                    contrato.descricao = (string)reader["descricaoContrato"];
                    contrato.notaContratante = (int)reader["NotaContratante"];
                    contrato.notaFreelancer = (int)reader["NotaFreelancer"];
                    contrato.contratanteid = (int)reader["idContratante"];
                    if (reader["idFreelancer"] != DBNull.Value){
                         contrato.freelancerid = (int)reader["idFreelancer"];
                    }
                    contrato.prazo = (DateTime)reader["Prazo"];
                    contrato.status = (int)reader["Status"];
                    lista.Add(contrato);
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }


           public List<Contrato> ReadFreelancer(int id)
        {
            List<Contrato> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM contrato where idFreelancer = @id ";
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                lista = new List<Contrato>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Contrato contrato = new Contrato();
                    contrato.nrContrato = (int)reader["NrContrato"];
                    contrato.dataContrato = (DateTime)reader["DataContrato"];
                    contrato.total = (decimal)reader["Total"];
                    contrato.descricao = (string)reader["descricaoContrato"];
                    contrato.notaContratante = (int)reader["NotaContratante"];
                    contrato.notaFreelancer = (int)reader["NotaFreelancer"];
                    contrato.contratanteid = (int)reader["idContratante"];
                    contrato.freelancerid = (int)reader["idFreelancer"];
                    contrato.prazo = (DateTime)reader["Prazo"];
                    contrato.status = (int)reader["Status"];
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

            cmd.CommandText = @"exec UpdateContrato @datainicial, @status, @freelancer, @nrcontrato";

            cmd.Parameters.AddWithValue("@nrcontrato", contrato.nrContrato);
            cmd.Parameters.AddWithValue("@datainicial", contrato.dataInicial);
            cmd.Parameters.AddWithValue("@status", contrato.status);
            cmd.Parameters.AddWithValue("@freelancer", contrato.freelancerid);
            cmd.ExecuteNonQuery();
        }

        public void Delete(Contrato contrato)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"exec DeleteContrato @nrContrato, @contratante";

            cmd.Parameters.AddWithValue("@nrContrato", contrato.nrContrato);
            cmd.Parameters.AddWithValue("@contratante", contrato.contratanteid);

            cmd.ExecuteNonQuery();
        }
    }
}
