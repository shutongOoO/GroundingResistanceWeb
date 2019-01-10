using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.SessionState;

namespace GroundingResistance.web
{
    public partial class administrator : System.Web.UI.Page,IRequiresSessionState
    {
        protected System.Text.StringBuilder sbTrs = new System.Text.StringBuilder(200);
        protected System.Text.StringBuilder pageInfo = new System.Text.StringBuilder(200);
        protected void Page_Load(object sender, EventArgs e)
        {
            bool IsLogin = Pagination.loginCheck(Session["username"].ToString());
            if (IsLogin)
            {
                int PageSize = 10;
                int Pageindex;
                int RecordCount = Pagination.DataNum("select * from user");
                int pageCount = Convert.ToInt32(Math.Ceiling((double)RecordCount / PageSize));
                //防止查询的数据数量为零时，没有第几页的信息以及点击前一页后一页时会出现访问数据库参数异常。
                if (pageCount == 0)
                {
                    pageCount = 1;
                }
                if (!int.TryParse(Request.QueryString["PageIndex"], out Pageindex))
                {
                    Pageindex = 1;
                }
                else
                {
                    //进行页码范围判断
                    Pageindex = Pageindex < 1 ? 1 : Pageindex;
                    Pageindex = Pageindex > pageCount ? pageCount : Pageindex;
                }
                //根据查询的页码在数据库中查询数据
                DataTable dt = DbHelperSQL.GetPagedListForObjectDataSource("select * from user order by id asc  limit @startRowIndex,@endRowIndex", PageSize * (Pageindex - 1), PageSize);
                //遍历出数据库数据
                foreach (DataRow dr in dt.Rows)
                {
                    sbTrs.Append("<tbody>");
                    sbTrs.Append("<tr>");
                    //sbTrs.Append("<td> <input name='' type='checkbox' value='' /> </td>");
                    sbTrs.Append("<td>" + dr["id"] + "</td>");
                    sbTrs.Append("<td>" + dr["nickname"] + "</td>");
                    sbTrs.Append("<td>" + dr["telephone"] + "</td>");
                    sbTrs.Append("<td>" + dr["information"] + "</td>");
                    sbTrs.Append("<td><a href='IPQCDelete.aspx?id=" + dr["id"].ToString() + "&PageIndex=" + Pageindex.ToString() + "' class=\"tablelink\">删除</a> <a href=\"IPQCModify.aspx?id=" + dr["id"].ToString() + "&PageIndex=" + Pageindex.ToString() + "\" class='tablelink'>修改</a></td>");
                    sbTrs.AppendLine("</tr>");
                    sbTrs.Append("</tbody>");
                }
                //设置页面跳转
                pageInfo.Append("<div class='message'>共<i class='blue'>" + RecordCount.ToString() + "</i>条记录，当前显示第&nbsp;<i class='blue'>" + Pageindex.ToString() + "&nbsp;</i>页</div>");
                pageInfo.Append("<ul class='paginList'>");
                pageInfo.Append("<li class='paginItem'><a href = 'administrator.aspx?PageIndex=" + (Pageindex - 1) + "'><span class='pagepre'></span></a></li>");
                for (int i = 1; i <= pageCount; i++)
                {
                    pageInfo.Append("<li class='paginItem'><a href='administrator.aspx?PageIndex=" + i + "'>" + i.ToString() + "</a></li>");
                }
                pageInfo.Append("<li class='paginItem'><a href = 'administrator.aspx?PageIndex=" + (Pageindex + 1) + "'><span class='pagenxt'></span></a></li>");
                pageInfo.Append("</ul>");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}