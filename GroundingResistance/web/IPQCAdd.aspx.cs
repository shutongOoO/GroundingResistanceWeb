using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GroundingResistance.web
{
    public partial class IPQCAdd : System.Web.UI.Page
    {
        protected int res = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.HttpMethod.ToLower() == "post")
            {
                //接收到 浏览器 表单 提交过来的 用户写的杆塔信息
                string strusername = Request.Form["username"];
                string strpassword = Request.Form["password"];
                string strnickname = Request.Form["nickname"];
                string strtel = Request.Form["telephone"];
                string strInfo = Request.Form["information"];
                //验证接收到的浏览器数据-待完成！ 

                //将数据更新到 数据库中
                string strSql = "insert into user(username,password,nickname,telephone,information) values(@username,@password,@nickname,@telephone,@information)";
                MySqlParameter[] paras =
                    {
                new MySqlParameter ("@username",MySqlDbType.VarChar),
                new MySqlParameter("@password",MySqlDbType.VarChar),
                new MySqlParameter("@nickname",MySqlDbType.VarChar),
                new MySqlParameter("@telephone",MySqlDbType.VarChar),
                new MySqlParameter("@information",MySqlDbType.Text)
                };
                paras[0].Value = strusername;
                paras[1].Value = strpassword;
                paras[2].Value = strnickname;
                paras[3].Value = strtel;
                paras[4].Value = strInfo;
                try
                {
                    res = DbHelperSQL.ExcuteNonQuery(strSql, paras);
                }
                catch
                {

                }
                //信息更新是否成功，提示信息！
                if (res == 1)
                {
                    Response.Redirect("administrator.aspx");
                }
                else
                {
                    Response.Redirect("fail.html");
                }
            }
        }
    }
}