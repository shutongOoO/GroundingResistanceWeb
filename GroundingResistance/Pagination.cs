using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;


namespace GroundingResistance.web
{
    public class Pagination
    {
        /// <summary>
        /// 计算数据共有多少条
        /// </summary>
        /// <returns></returns>
        public static int DataNum(string Strsql)
        {
            DataTable dt = DbHelperSQL.GetDataTable(Strsql);
            return dt.Rows.Count;
        }
        /// <summary>
        /// 判断用户是否已经登录
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool loginCheck(string uname)
        {
            DataTable dt = DbHelperSQL.GetDataTable("select * from admin");
            string strName;
            DataRow dr = dt.Rows[0];
            strName = dr["username"].ToString();
            if (strName == uname)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}