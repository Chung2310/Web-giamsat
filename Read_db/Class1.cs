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
            catch //(Exception ex)
            {
                json = "{\"ok\";0,\"msg\":\"Lỗi rồi\"}";
            }
                return json;
            
        }
    }
}
