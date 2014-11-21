using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataTableSource
{
    public class OtherHelper
    {
        /// <summary>
        /// Ajax调用的分页存储过程
        /// <param name="pageindex">页码</param>
        /// <param name="PageSize">总页数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="TableName">查询表名</param>
        /// <param name="RowName">排序列名</param>
        /// <param name="ProName">执行存储过程名</param>
        /// <returns></returns>
        public static DataSet AjaxForPage(int pageindex, int PageSize, string strWhere, string TableName, string RowName, string ProName = "pro_GeneralPaged")
        {
            SqlParameter[] sqlparameter = { 
                                      new SqlParameter("@PageIndex",SqlDbType.Int),
                                      new SqlParameter("@PageSize",SqlDbType.Int),
                                      new SqlParameter("@StrWhere",SqlDbType.VarChar),
                                      new SqlParameter("@TableName",SqlDbType.VarChar),
                                      new SqlParameter("@RowName",SqlDbType.VarChar),
                                      new SqlParameter("@RecordCount", SqlDbType.Int),
                                      new SqlParameter("@PageCount", SqlDbType.Int)};
            sqlparameter[0].Value = pageindex;
            sqlparameter[1].Value = PageSize;
            sqlparameter[2].Value = strWhere;
            sqlparameter[3].Value = TableName;
            sqlparameter[4].Value = RowName;
            sqlparameter[5].Value = null;
            sqlparameter[6].Value = null;

            //此处执行存储过程，并返回DataSet
            //return RunProcedure(ProName, sqlparameter, "ds");
            return null;
        }

        /// -- 愤怒的Trycatch  全局通用存储过程
        /// -- 调用方法 DataSet ds = pro.ByPro(PageSize, PageIndex, “查询条件”, ”需要分页的表名”, ”需要分页排序的列名”);
        /// -- 存储过程方法名固定
        ///
        /// create procedure [dbo].[pro_GeneralPaged]
        ///   @PageIndex Int,--页码
        ///   @PageSize Int,--每页显示记录
        ///   @StrWhere nvarchar(1000),--Where条件
        ///   @TableName nvarchar(1000), --进行分页的表
        ///   @RowName nvarchar(1000),   --进行分页排序的字段
        ///   @RecordCount Int out,--总记录数
        ///   @PageCount Int out --总页数
        ///   as
        ///
        ///   declare @SQLSTR nvarchar(4000) --查询语句
        ///
        ///   IF @RecordCount is null
	    ///    BEGIN
		///        DECLARE @sql nvarchar(4000)
		///        SET @sql=N'select @RecordCount=count(*)'
		///	        +N' from '+ @TableName +' where 1=1 '
		///	        +N' '+@StrWhere
		///        EXEC sp_executesql @sql,N'@RecordCount int OUTPUT',@RecordCount output
	    ///    END
	    ///    set @PageCount =ceiling(@RecordCount*1.0/@PageSize)
	    ///    if @PageIndex>@PageCount
	    ///    begin
		///        set @PageIndex=@PageCount
	    ///    end
        ///   if @PageIndex<1
	    ///    begin
		///        set @PageIndex=1
	    ///    end
	    ///
        ///   if @PageIndex=1 or @PageCount<=1
	    ///    begin
		///        set @SQLSTR='select top '+str(@PageSize)+' * from '+ @TableName +' where 1=1 '+ @StrWhere +' order by '+@RowName+' desc'
	    ///    end 
	    ///    else if @PageIndex=@PageCount
	    ///    begin
		///        set @SQLSTR='select * from (select top '+ str(@RecordCount-@PageSize*(@PageIndex-1))+' * from '+ @TableName +' where 1=1 '+ @StrWhere + ' order by '+@RowName+' asc)  TempTable order by '+@RowName+' desc'
	    ///    end
	    ///    else 
	    ///    begin
		///        set @SQLSTR='select top '+str(@PageSize)+' * from (select top '+str(@RecordCount-@PageSize*(@PageIndex-1))+' * from '+ @TableName +' where 1=1 '+@StrWhere+'order by '+@RowName+' asc) TempTable order by '+@RowName+' desc'
	    ///    end
	    ///    set @SQLSTR=@SQLSTR +' select rcount = '+str (@RecordCount)+',pcount='+ str(@PageCount)
	    ///    exec (@SQLSTR)

    }
}
