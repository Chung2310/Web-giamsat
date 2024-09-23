using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Read_db
{
    public class Read_sql
    {
        public string str_sql;
        public string get_status()
        {
            string json = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(str_sql))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_API";
                        cmd.Parameters.Add("@action", SqlDbType.VarChar, 50).Value = "get_status";
                        object result = cmd.ExecuteScalar();
                        json = (string)result;
                    }
                }
            }
            catch (Exception ex)
            {
                json = "{\"ok\";0,\"msg\":\"Lỗi rồi\"}" + ex.Message;
            }
                return json;
            
        }
        public string control(int idSV, int status)
        {
            string json = "";

            try
            {

                using (SqlConnection conn = new SqlConnection(str_sql))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_API";
                        cmd.Parameters.Add("@action", SqlDbType.VarChar, 50).Value = "control";
                        cmd.Parameters.Add("@idSv", SqlDbType.Int).Value =idSV;
                        cmd.Parameters.Add("@control_status", SqlDbType.Int).Value = status;
                        object result = cmd.ExecuteScalar();
                        json = (string)result;
                    }
                }
            }
            catch //(Exception ex)
            {
                json = "{\"ok\":0,\"msg\":\"Lỗi rồi\"}";
            }

            return json;
        }
        public string get_Lichsu(int idSV)
        {
            string json = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(str_sql))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_API";
                        cmd.Parameters.Add("@action", SqlDbType.VarChar, 50).Value = "get_lichsu";
                    
                        cmd.Parameters.Add("@idSv", SqlDbType.Int).Value =idSV ;
                        object result = cmd.ExecuteScalar();
                        json = (string)result;
                    }
                }
            }
            catch (Exception ex)
            {
                json = "{\"ok\";0,\"msg\":\"Lỗi rồi\"}" + ex.Message;
            }
            return json;
        }
    }
}
