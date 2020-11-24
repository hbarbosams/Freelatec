using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Data : IDisposable
    {
        //Atributos: vai nos permitir conectar com o BD
        protected SqlConnection connectionDB;

        public Data()
        {
            try
            {
                //String de conexão com o BD
                string strConexao = @"Data Source=NOTE-TULIO;
                                      Initial Catalog=FreelaTec_bd; 
                                      Integrated Security=True";//Autenticação Windows
                                                                //User ID=sa; Password=101257240696Tb@; //Autenticação SQL Server

                connectionDB = new SqlConnection(strConexao);

                connectionDB.Open();
            }
            catch (SqlException er)
            {
                Console.WriteLine("Erro do Banco: " + er);
            }
        }
        public void Dispose()
        {
            connectionDB.Close();
        }
    }
}