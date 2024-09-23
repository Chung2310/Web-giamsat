using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_giamsat
{
    public partial class asp : System.Web.UI.Page
    {
        class PhanHoi
        {
            public bool ok;
            public string msg;
            public List<int> sv;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            get_status();
            
        }

        [WebMethod]
        public static string get_history(string id)
        {
            PhanHoi phanHoi = new PhanHoi();
            try
            {
                Read_db.Read_sql db = new Read_db.Read_sql();
                db.str_sql = "Data Source=DESKTOP-KDA72GQ\\MSSQLCHUNG;Initial Catalog=Webgiamsat;Integrated Security=True;Connect Timeout=30;Encrypt=False";
                string json = db.get_Lichsu(id);
                return json;  // Trả về JSON cho AJAX
            }
            catch (Exception ex)
            {
                phanHoi.ok = false;
                phanHoi.msg = "Lỗi rồi!" + ex.Message;
                return JsonConvert.SerializeObject(phanHoi);  // Trả về lỗi dưới dạng JSON
            }
        }

        [WebMethod]
        public void get_status()
        {
            PhanHoi phanHoi = new PhanHoi();
            try
            {

                Read_db.Read_sql db = new Read_db.Read_sql();
                db.str_sql = "Data Source=DESKTOP-KDA72GQ\\MSSQLCHUNG;Initial Catalog=Webgiamsat;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                string json = db.get_status();
                this.Response.Write(json);



            }
            catch (Exception ex)
            {
                phanHoi.ok = false;
                phanHoi.msg = "lỗi rồi!" + ex.Message;
            }
        }
        
    }
}