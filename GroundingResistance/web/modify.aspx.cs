using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace GroundingResistance.web
{
    public partial class modify : System.Web.UI.Page
    {
        protected System.Text.StringBuilder sbform = new System.Text.StringBuilder(200);
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要修改的杆塔ID
            int id;
            //修改成功后需要返回的杆塔页面
            int pageindex;
            //表单提交的信息写入数据库
            if (Request.HttpMethod.ToLower() == "post")
            {
                if (!int.TryParse(Request.QueryString["id"], out id))
                {
                    Response.Redirect("error.html");
                }
                if (!int.TryParse(Request.QueryString["pageindex"], out pageindex))
                {
                    Response.Redirect("error.html");
                }
                string strlinename = Request.Form["linename"];
                string strpoleid = Request.Form["poleid"];
                string strlongitude = Request.Form["longitude"];
                string strlatitude = Request.Form["latitude"];
                string strSql = "update pole set linename=@linename,poleid=@poleid,longitude=@longitude,latitude=@latitude where id=@id";
                MySqlParameter[] paras =
                    {
                new MySqlParameter ("@linename",MySqlDbType.VarChar),
                new MySqlParameter("@poleid",MySqlDbType.VarChar),
                new MySqlParameter("@longitude",MySqlDbType.Double),
                new MySqlParameter("@latitude",MySqlDbType.Double),
                new MySqlParameter("@id",SqlDbType.Int)
                };
                paras[0].Value = strlinename;
                paras[1].Value = strpoleid;
                paras[2].Value = strlongitude;
                paras[3].Value = strlatitude;
                paras[4].Value = id;
                try
                {
                    DbHelperSQL.ExcuteNonQuery(strSql, paras);
                }
                catch
                {

                }
                //重新返回之前的的页面
                Response.Redirect("right.aspx?PageIndex="+pageindex.ToString());
            }
            //接收URL传来的页面以及ID信息并生成需要修改的杆塔信息表单
            else
            {
                if (!int.TryParse(Request.QueryString["PageIndex"], out pageindex))
                {
                    Response.Redirect("error.html");
                }
                if (!int.TryParse(Request.QueryString["id"], out id))
                {
                    Response.Redirect("error.html");
                }
                else
                {
                    MySqlParameter par = new MySqlParameter("@id", SqlDbType.Int);
                    par.Value = id;
                    DataTable dt = DbHelperSQL.GetDataTable("select * from pole where id=@id", par);
                    foreach (DataRow dr in dt.Rows)
                    {
                        sbform.Append("<form id=\"formsub\" action=\"modify.aspx?id="+id.ToString()+"&pageindex="+pageindex.ToString()+"\" method=\"post\">");
                        sbform.Append(" <ul class=\"forminfo\">");
                        sbform.Append("<li><label > 线路名 </label ><input name = \"linename\" type = \"text\" class=\"dfinput\" value=\""+dr["linename"].ToString()+"\" /><i></i></li>");
                        sbform.Append("<li><label > 杆塔编号 </label ><input name = \"poleid\" type = \"text\" class=\"dfinput\" value=\""+dr["poleid"].ToString()+"\" /><i></i></li>");
                        sbform.Append("<li><label > 经度 </label ><input name = \"longitude\" type = \"text\" class=\"dfinput\" value=\""+dr["longitude"].ToString()+"\" /><i>不用加单位</i></li>");
                        sbform.Append("<li><label > 纬度 </label ><input name = \"latitude\" type = \"text\" class=\"dfinput\" value=\""+dr["latitude"].ToString()+"\" /><i>不用加单位</i></li>");
                        sbform.Append("<li><label > &nbsp;</label ><input name = \"\" type = \"button\" class=\"btn\" value=\"修改\" /></li></ul></form>");
                    }
                }
            }
        }
    }
}