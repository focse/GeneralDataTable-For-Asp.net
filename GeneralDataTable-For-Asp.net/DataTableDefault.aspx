<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataTableDefault.aspx.cs" Inherits="GeneralDataTable_For_Asp.net.DataTableDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据表格 - Default</title>
    <link href="Css/layer.css" rel="stylesheet" />
    <link href="Css/table.css" rel="stylesheet" />
</head>
<body>
    <div>
        <div>请输入用户名称：<input type="text" id="t_name" /></div>
        <div id="div_table_content">数据表格填充位置</div>
    </div>
    <script src="JavaScript/jquery-1.8.2.min.js"></script>
    <script src="JavaScript/table.js"></script>
    <script type="text/javascript">
        $(function () { query('1') })

        //此方法反复调用，下一页触发方法为 query('页码'),触发此方法后按页面刷新数据表格
        function query(pageindex) {
            var dataInfo = "pageIndex=" + pageindex + "&Name=" + $("#t_name").val();
            $.ajax({
                type: "post",
                url: "Ajax/DataTableAjax.asmx/GetList",
                data: dataInfo,
                dataType: "html",
                beforeSend: function (XMLHttpRequest) {
                },
                success: function (msg) {
                    $("#divcontent").html(msg);
                    layer.msg('列表读取成功', 2);
                },
                error: function (e, x) {
                    layer.msg('发生错误:' + e.toString(), 1);
                }
            });
        }
    </script>
</body>
</html>
