using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataTableSource
{
    /// <summary>
    /// 愤怒的TryCatch 2014年11月21日15:52:33
    /// 标准输出Table模型
    /// 原始的基本模型，在此基础上可以继承后override方法，可扩展各种表现形式
    /// </summary>
    public class Table : ITable
    {
        public string[] ArrTitle;   //表格列名
        public string[] ArrWidth;   //表格列所占表格宽度
        public string[] ArrValue;   //没列所对应的value 
        public string[] ArrUrl;     //url
        public bool checkbox;       //是否加入复选框
        public DataTable data;      //数据源
        public int pageindex;       //页码 
        public int pcount;          //分页模块数据总页数
        public string ID;           //主键
        public int rcount;          //总行数
        public string titile;
        public int pageSize = 10;

        public Table()
        {
        }

        /// <summary>
        /// 设置表格上面的操作按钮，添加修改删除
        /// 通过js响应事件，修改事件，选择最靠前的一条记录
        /// 通过获取选择的
        /// </summary>
        /// <returns></returns>
        public virtual string operate()
        {
            StringBuilder ResultHtml = new StringBuilder();
            ResultHtml.Append("<table class=\"sub_table1\">");
            ResultHtml.Append("<thead><tr><td colspan=\"8\">" + titile + "</td></tr></thead>");
            ResultHtml.Append("<tr><td align=\"left\" class=\"list_tr_three\">");
            return ResultHtml.ToString();
        }
        /// <summary>
        /// 设置表头
        /// </summary>
        /// <returns></returns>
        public virtual string title()
        {
            StringBuilder ResultHtml = new StringBuilder();
            ResultHtml.Append("<table  width=\"100%\" align=\"center\" cellspacing=\"0\" class=\"bg_list\">");
            ResultHtml.Append("<tr style=\"font-size:14pt;height:25px;\">");
            //判断表格是否带有checkbox
            if (checkbox)
            {
                ResultHtml.Append(" <td width=\"3%\" align=\"center\" class=\"list_top\" ><input type=\"checkbox\" name=\"checkall\" id=\"checkall\" onclick=\"checkcall()\" /></td>");
            }
            ResultHtml.Append("<td style='background-color: #c0c0c0; color:Black;;' width=\"3%\" align=\"center\" class=\"list_top\"><b>序号</b></td>");
            int i = 0;
            foreach (string title in ArrTitle)
            {
                ResultHtml.Append("<td style='background-color: #c0c0c0; color:Black;' width=" + ArrWidth[i++] + " align=\"center\" class=\"list_top\" ><b>");
                ResultHtml.Append(title);
                ResultHtml.Append("</td></td>");
            }
            ResultHtml.Append("</tr>");
            return ResultHtml.ToString();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <returns></returns>
        public virtual string databond()
        {
            StringBuilder ResultHtml = new StringBuilder();

            for (int j = 0; j < data.Rows.Count; j++)
            {
                string datastyle = "";
                if (Convert.ToBoolean(j % 2))
                {
                    datastyle = "tdcolor";
                }
                else
                {
                    datastyle = "tdwhite";
                }
                ResultHtml.Append("<tr class=\"" + datastyle + "\" onmouseout=\"this.style.backgroundColor=''\" onmouseover=\"this.style.backgroundColor='#fbffe4'\" >");
                ///如果表格带有checkbox，则添加
                if (checkbox)
                {   //这里默认checbox的value为Id，如有需要在另行做设置
                    ResultHtml.Append("<td  align=\"center\" >");
                    ResultHtml.Append("<input type=\"checkbox\" name=\"checkbox\" id='checkbox" + data.Rows[j][ID] + "' value='" + data.Rows[j][ID] + "' />");
                    ResultHtml.Append("</td>");
                }
                ResultHtml.Append("<td align=\"center\"   >" + (pageSize * pageindex - pageSize + j + 1).ToString() + "</td>");
                for (int i = 0; i < ArrValue.Length; i++)
                {
                    //分别绑定每格的内容 =》依据数据字段
                    switch (ArrValue[i])
                    {
                        default:
                            ResultHtml.Append("<td align=\"center\"   >" + data.Rows[j][ArrValue[i]] + "</td>");
                            break;
                    }

                }
                ResultHtml.Append("</tr>");
            }

            return ResultHtml.ToString();
        }

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <returns></returns>
        public virtual string page()
        {
            StringBuilder ResultHtml = new StringBuilder();
            int colspan;//合并单元格
            if (checkbox)
            {
                colspan = ArrTitle.Length + 2;
            }
            else
            {
                colspan = ArrTitle.Length + 1;
            }
            ResultHtml.Append("<tr>");

            ResultHtml.Append("<td colspan=\"" + colspan + "\" align=\"center\" class=\"list_bottom\">");

            ///当访问第一页时，首页按钮置灰
            if (pageindex == 1 || pageindex == 0)
            {

                ResultHtml.Append("<a href=\"#\" disabled = \"true\">首页</a>&nbsp;&nbsp;");

                ResultHtml.Append("<a href=\"#\" disabled = \"true\">上一页</a>&nbsp;&nbsp;");
            }
            else
            {
                ResultHtml.Append("<a href=\"javascript:query('1');\" >首页</a>&nbsp;&nbsp;");

                ResultHtml.Append("<a href=\"javascript:query('" + (pageindex - 1).ToString() + "');\" >上一页</a>&nbsp;&nbsp;");
            }

            if (pageindex == pcount || pcount == 0)
            {
                ResultHtml.Append("<span><a href=\"#\" disabled = \"true\">下一页</a>&nbsp;&nbsp;");
                ResultHtml.Append("<span><a href=\"#\" disabled = \"true\">尾页</a>&nbsp;&nbsp;");
            }
            else
            {
                ResultHtml.Append("<a href=\"javascript:query('" + (pageindex + 1).ToString() + "');\">下一页</a>&nbsp;&nbsp;</span>");
                ResultHtml.Append("<a href=\"javascript:query('" + pcount.ToString() + "');\">尾页</a>&nbsp;&nbsp;</span>");
            }

            ResultHtml.Append("<span>" + pageindex + "/" + (pcount == 0 ? 1 : pcount) + "页&nbsp;&nbsp;");
            ResultHtml.Append("</span></td> ");
            //ResultHtml.Append("<span><a style=\"color:Black;\">跳转到</a></span><input type=\"text\" name=\"txPageIndex\"id=\"txPageIndex\" class=\"input_tiaozhuan\" /> <span class=\"span_img_go\" onclick=\"getPageSize()\"><span>");
            ResultHtml.Append("</tr>");
            ResultHtml.Append(" </table>");//数据表格结束标签，包括分页模块

            ResultHtml.Append(" </td></tr></table>");



            return ResultHtml.ToString();
        }

        public virtual string tables()
        {
            StringBuilder ResultHtml = new StringBuilder();
            //添加表格表头
            ResultHtml.Append(operate());
            //标题
            ResultHtml.Append(title());
            //数据绑定
            ResultHtml.Append(databond());
            //分页设置
            ResultHtml.Append(page());
            return ResultHtml.ToString();
        }
    }
}
