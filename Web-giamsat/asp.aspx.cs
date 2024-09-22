using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            PhanHoi phanHoi = new PhanHoi();
            try
            {
                
                string db_path = Server.MapPath("mydb.txt");
                string noidung = System.IO.File.ReadAllText(db_path);

                string[] lines = noidung.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string vitrisv = lines[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1];
                phanHoi.sv = doc_mang(vitrisv);
                phanHoi.ok = true;
                phanHoi.msg = "được rồi!";
            }
            catch (Exception ex) {
                phanHoi.ok = false;
                phanHoi.msg = "lỗi rồi!" + ex.Message;
            }
            string json = JsonConvert.SerializeObject(phanHoi);
            this.Response.Write(json);
        }
        List<int> doc_mang(string s)
        {
            List<int> L = new List<int>();
            string[] items = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                int i = int.Parse(item);
                L.Add(i);
            }
            return L;
        }
    }
}