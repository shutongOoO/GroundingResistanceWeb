using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace GroundingResistance.web
{
    public partial class addpole : System.Web.UI.Page
    {
        protected int res = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower() == "post")
            {
                //接收到 浏览器 表单 提交过来的 用户写的杆塔信息
                string strlinename = Request.Form["linename"];
                string strpoleid = Request.Form["poleid"];
                string strlongitude = Request.Form["longitude"];
                string strlatitude = Request.Form["latitude"];
                //验证接收到的浏览器数据-待完成！ 

                //将数据更新到 数据库中
                string strSql = "insert into pole(linename,poleid,longitude,latitude) values(@linename,@poleid,@longitude,@latitude)";
                MySqlParameter[] paras =
                    {
                new MySqlParameter ("@linename",MySqlDbType.VarChar),
                new MySqlParameter("@poleid",MySqlDbType.VarChar),
                new MySqlParameter("@longitude",MySqlDbType.Double),
                new MySqlParameter("@latitude",MySqlDbType.Double)
                };
                paras[0].Value = strlinename;
                paras[1].Value = strpoleid;
                paras[2].Value = strlongitude;
                paras[3].Value = strlatitude;
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
                    Response.Redirect("sucess.html");
                }
                else
                {
                    Response.Redirect("fail.html");
                }
            }
        }
    }
}