using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace GroundingResistance.web
{
    public partial class historiedData : System.Web.UI.Page
    {
        protected System.Text.StringBuilder HisData = new System.Text.StringBuilder(200);
        protected System.Text.StringBuilder pageInfo = new System.Text.StringBuilder(200);
        /// <summary>
        /// 本程序注释可参考right.aspx.cs注释
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string strClassId = Request.QueryString["cid"];
            int Pageindex;
            int PageSize = 20;
            int intCid = 0;
            if (!int.TryParse(strClassId, out intCid))
            {
                Response.Redirect("error.html");
            }
            else
            {
                DataTable dT = DbHelperSQL.GetDataTable("select * from pole where id = @cid", new MySqlParameter("@cid", SqlDbType.SmallInt) { Value = intCid });
                //根据id 去数据库 查询 
                DataTable dt = DbHelperSQL.GetDataTable("select * from record where pole = @cid order by time desc", new MySqlParameter("@cid", SqlDbType.SmallInt) { Value = intCid });
                int RecordCount = dt.Rows.Count;
                int pageCount = Convert.ToInt32(Math.Ceiling((double)RecordCount / PageSize));
                //根据查询的页码在数据库中查询数据
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
                    Pageindex = Pageindex < 1 ? 1 : Pageindex;
                    Pageindex = Pageindex > pageCount ? pageCount : Pageindex;
                }
                DataTable PageDataTable= DbHelperSQL.GetPagedListForObjectDataSource(PageSize * (Pageindex - 1), PageSize,intCid);
                HisData.Append("<tbody>");
                foreach (DataRow dr in PageDataTable.Rows)
                {
                    foreach (DataRow dR in dT.Rows)
                    {
                        HisData.Append("<tr>");
                        HisData.Append("<td>" + dR["linename"] + "</td>");
                        HisData.Append("<td>" + dR["poleid"] + "</td>");
                    }
                    HisData.Append("<td>" + dr["longitude"] + "</td>");
                    HisData.Append("<td>" + dr["latitude"] + "</td>");
                    HisData.Append("<td>" + dr["time"] + "</td>");
                    HisData.Append("<td>" + dr["user"] + "</td>");
                    HisData.Append("<td>" + dr["device"] + "</td>");
                    HisData.Append("<td>" + dr["data"] + "</td>");
                    HisData.AppendLine("</tr>");
                }
                HisData.Append("</tbody>");
                pageInfo.Append("<div class='message'>共<i class='blue'>" + RecordCount.ToString() + "</i>条记录，当前显示第&nbsp;<i class='blue'>" + Pageindex.ToString() + "&nbsp;</i>页</div>");
                pageInfo.Append("<ul class='paginList'>");
                pageInfo.Append("<li class='paginItem'><a href = 'historiedData.aspx?PageIndex=" + (Pageindex - 1) + "&cid="+intCid.ToString()+"'><span class='pagepre'></span></a></li>");
                for (int i = 1; i <= pageCount; i++)
                {
                    pageInfo.Append("<li class='paginItem'><a href='historiedData.aspx?PageIndex=" + i + "&cid="+intCid.ToString()+"'>" + i.ToString() + "</a></li>");
                }
                pageInfo.Append("<li class='paginItem'><a href = 'historiedData.aspx?PageIndex=" + (Pageindex + 1) + "&cid="+intCid.ToString()+"'><span class='pagenxt'></span></a></li>");
                pageInfo.Append("</ul>");
            }

        }

    }
}