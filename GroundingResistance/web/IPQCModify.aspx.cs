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
    public partial class IPQCModify : System.Web.UI.Page
    {
        protected System.Text.StringBuilder sbform = new System.Text.StringBuilder(200);
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要修改的人员ID
            int id;
            //修改成功后需要返回的人员页面
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
                string strusername = Request.Form["username"];
                string strpassword = Request.Form["password"];
                string strnickname = Request.Form["nickname"];
                string strTel = Request.Form["telephone"];
                string strInfo = Request.Form["information"];
                string strSql = "update user set username=@username,password=@password,nickname=@nickname,telephone=@telephone,information=@information where id=@id";
                MySqlParameter[] paras =
                    {
                new MySqlParameter ("@username",MySqlDbType.VarChar),
                new MySqlParameter("@password",MySqlDbType.VarChar),
                new MySqlParameter("@nickname",MySqlDbType.VarChar),
                new MySqlParameter("@telephone",MySqlDbType.VarChar),
                new MySqlParameter("@information",MySqlDbType.Text),
                new MySqlParameter("@id",SqlDbType.Int)
                };
                paras[0].Value = strusername;
                paras[1].Value = strpassword;
                paras[2].Value = strnickname;
                paras[3].Value = strTel;
                paras[4].Value = strInfo;
                paras[5].Value = id;

                DbHelperSQL.ExcuteNonQuery(strSql, paras);
                //重新返回之前的的页面
                Response.Redirect("administrator.aspx?PageIndex=" + pageindex.ToString());
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
                    DataTable dt = DbHelperSQL.GetDataTable("select * from user where id=@id", par);
                    foreach (DataRow dr in dt.Rows)
                    {
                        sbform.Append("<form id=\"formsub\" action=\"IPQCModify.aspx?id=" + id.ToString() + "&pageindex=" + pageindex.ToString() + "\" method=\"post\">");
                        sbform.Append(" <ul class=\"forminfo\">");
                        sbform.Append("<li><label > 用户名 </label ><input name = \"username\" type = \"text\" class=\"dfinput\" value=\"" + dr["username"].ToString() + "\" /><i></i></li>");
                        sbform.Append("<li><label > 密码 </label ><input name = \"password\" type = \"text\" class=\"dfinput\" value=\"" + dr["password"].ToString() + "\" /><i></i></li>");
                        sbform.Append("<li><label > 昵称 </label ><input name = \"nickname\" type = \"text\" class=\"dfinput\" value=\"" + dr["nickname"].ToString() + "\" /><i></i></li>");
                        sbform.Append("<li><label > 电话 </label ><input name = \"telephone\" type = \"text\" class=\"dfinput\" value=\"" + dr["telephone"].ToString() + "\" /><i></i></li>");
                        sbform.Append("<li><label > 信息 </label ><input name = \"information\" type = \"text\" class=\"dfinput\" value=\"" + dr["information"].ToString() + "\" /><i></i></li>");
                        sbform.Append("<li><label > &nbsp;</label ><input name = \"\" type = \"button\" class=\"btn\" value=\"修改\" /></li></ul></form>");
                    }
                }
            }
        }
    }
}