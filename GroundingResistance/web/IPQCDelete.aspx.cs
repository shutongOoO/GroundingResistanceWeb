using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroundingResistance.web
{
    public partial class IPQCDelete : System.Web.UI.Page
    {
        public string JqueryString = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            int PageIndex;
            if (!int.TryParse(Request.QueryString["id"], out id))
            {
                Response.Redirect("error.html");
                //MessageString = "参数错误";
            }
            else
            {
                //删除杆塔信息
                string sql = "delete from user where id=@id";
                MySqlParameter pars = new MySqlParameter("@id", SqlDbType.Int);
                pars.Value = id;
                try
                {
                    DbHelperSQL.ExcuteNonQuery(sql, pars);
                    sql = "delete from record where poleid=@id";
                    DbHelperSQL.ExcuteNonQuery(sql, pars);
                }
                catch
                {

                }
                if (!int.TryParse(Request.QueryString["PageIndex"], out PageIndex))
                {
                    PageIndex = 1;
                    JqueryString = PageIndex.ToString();
                }
                else
                {
                    //MessageString = "<input name='' type='button' class='sure' onclick="+"\"location.href ="+"'right.aspx?PageIndex="+PageIndex.ToString()+"';\" "+" value='确定' />";
                    JqueryString = PageIndex.ToString();
                }

            }
        }
    }
}