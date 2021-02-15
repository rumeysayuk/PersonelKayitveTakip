using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKayit
{
    class DBConnection
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J7TKCO6\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        private SqlDataAdapter myAdapter = new SqlDataAdapter();


        private SqlConnection openConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
            }
            catch (Exception)
            {
                //hata
            }
            return conn;
        }
        private void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        //public Int32 executeFrmIstatistik(string query,SqlParameter[] sqlParameters)
        //{
        //    SqlCommand sqlCommand = new SqlCommand();
        //    try
        //    {
        //        sqlCommand.Connection = openConnection();
        //        sqlCommand.CommandText = query + " ; SELECT Cast(SCOPE_IDENTITY() AS int)";
        //        sqlCommand.Parameters.AddRange(sqlParameters);
        //        myAdapter.SelectCommand = sqlCommand;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return 0;

        //}
        public Int32 executeInsert(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = query + " ; SELECT Cast(SCOPE_IDENTITY() AS int)";
                sqlCommand.Parameters.AddRange(sqlParameters);
                myAdapter.InsertCommand = sqlCommand;


                Int32 idsi = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return idsi;
            }
            catch (Exception)
            {
                //db ye ekleme hatası
            }
            finally
            {
                closeConnection();
            }
            return 0;
        }
        public bool executeDelete(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand();
            bool durum = true;
            try
            {

                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.AddRange(sqlParameters);
                myAdapter.DeleteCommand = sqlCommand;
                sqlCommand.ExecuteNonQuery();
                durum = true;
            }
            catch (Exception)
            {
                durum = false;
                //db ye ekleme hatası
            }
            finally
            {
                closeConnection();
            }
            return durum;
        }
        public Int32 executeUpdate(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand();
  
            try
            {
                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.AddRange(sqlParameters);
                myAdapter.UpdateCommand = sqlCommand;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                closeConnection();
            }
            return 1;
        }
        public DataTable executeSelect(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                
                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.AddRange(sqlParameters);
                sqlCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = sqlCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];

            }
            catch (Exception)
            {
                //db ye ekleme hatası
            }
            finally
            {
                closeConnection();
            }
            return dataTable;
        }
        
        public bool executeTekrar(string query,SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand();
            bool durum = true;
            try
            {

                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.AddRange(sqlParameters);
                sqlCommand.ExecuteNonQuery();
                durum = true;
            }
            catch (Exception)
            {
                durum = false;
                //db ye ekleme hatası
            }
            finally
            {
                closeConnection();
            }
            return durum;

        }
    }
}
