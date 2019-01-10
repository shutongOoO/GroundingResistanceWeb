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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower() == "post")
            {
                string strName = Request.Form["username"];
                string strPassword = Request.Form["password"];
                DataTable dt = DbHelperSQL.GetDataTable("select * from admin");
                Session["username"]=strName;
                foreach (DataRow dr in dt.Rows)
                {
                    if (strName == dr["username"].ToString())
                    {
                        if (strPassword == dr["password"].ToString())
                        {
                            Response.Redirect("main.html");
                        }
                        else
                        {
                            Response.Write("<script>alert('密码错误！'); </script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名错误！');</script>");
                    }
                }
            }
        }
        //return 23;
    }
}