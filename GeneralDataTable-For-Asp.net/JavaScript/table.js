var _layerSor；  //全局弹出层控制变量

//获取多个url参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
//获取页面checkbox 的name=checkbox的value
function checkvalue(tbtype) {
    var chk_value = "";
    $('input[name2="' + tbtype + '"]:checked').each(function () {
        chk_value = chk_value + "'" + $(this).val() + "',";
    });
    chk_value = chk_value.substr(0, chk_value.length - 1);
    return chk_value;
}

//定位及显示
function dingwei(elem, fullbg) {
    var clientH = document.documentElement.clientHeight;
    var h = null;
    if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        h = document.body;
    } else {
        h = document.documentElement;
    }
    var w = (document.documentElement.clientWidth / 2) - ($("#" + elem).width() / 2);
    $("#" + elem).css("top", (h.scrollTop + (clientH / 2) - ($("#" + elem).height() / 2)) + "px");
    $("#" + elem).css("left", w + "px");
    $("#" + fullbg).css("display", "block");
    $("#" + elem).css("display", "block");
}

//删除按钮事件
function bianji(elem, fullbg, id) {
    moedit(id);
    dingwei(elem, fullbg);
}

function TbDel(tbtype) {
    if (checkvalue(tbtype) == "") {
        showMsgbox("请选择至少一条数据！");
    } else {
        del("(" + checkvalue(tbtype) + ")");
    }
}

//编辑按钮事件
function TbEdit(value, tabType) {
    //编辑事件使用弹出层弹出编辑框，此处使用layer弹出层组件
    _layerSor = $.layer({
        type: 1,
        title: false,
        area: ['auto', 'auto'],
        border: [10, 0.3, '#000'],
        shade: [0.5, '#000'],
        closeBtn: [0, true],
        shift: 'top',
        page: {
            html: 'HTML代码'
        }
    });
}

//分页模块中的跳转
function query(pageindex) {
    listinfo(pageindex);
}
//全选/取消
function checkcall() {
    var checkboxs = document.getElementsByName("checkbox");
    for (var i = 0; i < checkboxs.length; i++) {
        var e = checkboxs[i]; e.checked = !e.checked;
    }
}

function checkcall(tbtype) {
    var checkboxs = $('input[name2="' + tbtype + '"]');
    for (var i = 0; i < checkboxs.length; i++) {
        var e = checkboxs[i]; e.checked = !e.checked;
    }
}

//页码跳转
function getPageSize() {
    reg = /^[0-9]{1,5}$/;
    var pageindex = document.getElementById("txPageIndex").value;
    if (pageindex == "") {
        showMsgbox("请输入您要跳转的页码");
        return;

    } else if (!reg.test(pageindex)) {
        showMsgbox("请输入正确的页码格式");
        return;
    }
    query(document.getElementById("txPageIndex").value);
}

function tan_xiang(ww) {
    var zi = document.getElementById(ww);
    var clientH = document.documentElement.clientHeight;
    var h = null;
    if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        h = document.body;
    } else {
        h = document.documentElement;
    }
    var w = (document.documentElement.clientWidth / 2) - ($("#" + ww).width() / 2);
    if (zi.style.display == "none") {
        $("#" + ww).css("top", (h.scrollTop + (clientH / 2) - ($("#" + ww).height() / 2)) + "px");
        $("#" + ww).css("left", w + "px");
        $("#" + ww).css("display", "block");
    }
    else {
        $("#" + ww).css("display", "none");
    }
}

function tan_xiangD(ww) {
    var zi = document.getElementById(ww);
    var clientH = document.documentElement.clientHeight;
    var h = null;
    if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        h = document.body;
    } else {
        h = document.documentElement;
    }
    var w = (document.documentElement.clientWidth / 2) - ($("#" + ww).width() / 2);
    if (zi.style.display == "none") {
        $("#" + ww).css("top", (h.scrollTop + (clientH / 2) - ($("#" + ww).height() / 2)) + "px");
        $("#" + ww).css("left", w + "px");
        $("#" + ww).css("display", "block");
    }
    else {
        $("#" + ww).css("display", "none");
    }
}

function tan_xiangC(ww) {
    var zi = document.getElementById(ww);
    var clientH = document.documentElement.clientHeight;
    var h = null;
    if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        h = document.body;
    } else {
        h = document.documentElement;
    }
    var w = (document.documentElement.clientWidth / 2) - ($("#" + ww).width() / 2);
    if (zi.style.display == "none") {
        $("#" + ww).css("top", (h.scrollTop + (clientH / 2) - ($("#" + ww).height() / 2)) + "px");
        $("#" + ww).css("left", w + "px");
        $("#" + ww).css("display", "block");
    }
    else {
        $("#" + ww).css("display", "none");
    }
}
