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
    public class CategoriaData : Data
    {

        public void Create(Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;

            // Comando que sera escrito no banco de dados
            cmd.CommandText = @"INSERT INTO Categoria VALUES (@descricao)";

            // Colocando os dados recebidos pelo objeto cliente na string sql
            cmd.Parameters.AddWithValue("@descricao", categoria.descricao);

            // Execução da string qld no banco
            cmd.ExecuteNonQuery();

            
        }

        public List<Categoria> Read()
        {
            List<Categoria> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;

                // Se fosse usar procedures precisa preparar o codigo com a seguinte linha
                // cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandText = "SELECT * FROM Categoria";

                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Categoria>();
                while (reader.Read())
                {
                    // Criando objeto pessoa que existe no banco
                    Categoria categoria = new Categoria();

                    categoria.codigo = (int)reader["codigo"];
                    categoria.descricao = (string)reader["descricao"];

                    lista.Add(categoria);
                }
            }
            catch (SqlException sqlerror)
            {
                //return sqlerror;
            }
            return lista;
        }

        public void Update(Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"UPDATE Categoria
                                    SET Codigo = @codigo, Descricao = @descricao
                                    WHERE Id = @id";

            cmd.Parameters.AddWithValue("@codigo", categoria.codigo);
            cmd.Parameters.AddWithValue("@descricao", categoria.descricao);

            //Codigo = 0;
            //Descricao = null;

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connectionDB;

            cmd.CommandText = @"DELETE FROM Categoria WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
