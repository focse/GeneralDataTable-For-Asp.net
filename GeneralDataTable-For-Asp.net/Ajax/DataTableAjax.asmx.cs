using DataTableSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GeneralDataTable_For_Asp.net.Ajax
{
    /// <summary>
    /// Summary description for DataTableAjax
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DataTableAjax : System.Web.Services.WebService
    {
        /// <summary>
        /// get datatable lists, You can also carry a variety of conditions
        /// this is a demo
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        [WebMethod]
        public void GetList(string pageIndex, string Name)
        {
            int PageSize = 20; //每页显示的最大记录数
            string strHtml = "";
            string strWhere = "";
            if (Name != "")
            {
                strWhere += " and Name='" + Name + "' ";
            }

            //获取数据源
            DataSet ds = OtherHelper.AjaxForPage(int.Parse(pageIndex), PageSize, strWhere, "EnterpriseMembership", "Id");
            DataTable Record = ds.Tables[0];
            DataTable Page = ds.Tables[1];
            int rcount = int.Parse(Page.Rows[0]["rcount"].ToString());//数据源记录数
            int pcount = int.Parse(Page.Rows[0]["pcount"].ToString());//页数
            Table _tb = new Table();
            string[] ArrTitle = { "字段中文列名1", "字段中文列名2", "字段中文列名3", "字段中文列名4", "字段中文列名5", "特殊字段" };
            string[] ArrValue = { "列名1", "列名2", "列名3", "列名4", "列名5", "SetInfo" }; //特殊字段 自定义名称，一般用在数据表格的最后一列，存放修改按钮，删除按钮 等
            string[] ArrWidth = { "10%", "10%", "7%", "10%", "7%", "7%" };
            _tb.ArrTitle = ArrTitle;
            _tb.ArrValue = ArrValue;
            _tb.ArrWidth = ArrWidth;
            _tb.checkbox = false;
            _tb.data = Record;
            _tb.ID = "ID";
            _tb.pageindex = int.Parse(pageIndex);
            _tb.pageSize = PageSize;
            _tb.pcount = pcount;
            strHtml = _tb.tables();
            HttpContext.Current.Response.Write(strHtml);
        }
    }
}
