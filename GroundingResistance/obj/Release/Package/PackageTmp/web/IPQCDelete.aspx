<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPQCDelete.aspx.cs" Inherits="GroundingResistance.web.IPQCDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".tip").fadeIn(200);

            $(".tiptop a").click(function () {
                $(".tip").fadeOut(200);
                var pageindex="<%=JqueryString%>";
                location.href = "administrator.aspx?PageIndex="+pageindex;
            });

            $(".sure").click(function () {
                $(".tip").fadeOut(100);
            });

            $(".cancel").click(function () {
                $(".tip").fadeOut(100);
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <div class="tip">
        <div class="tiptop"><span>提示信息</span><a></a></div>

        <div class="tipinfo">
            <span>
                <img src="images/ticon.png" /></span>
            <div class="tipright">
                <p>删除成功</p>
                <cite>杆塔已经被成功移除，该杆塔历史记录也已一同清空</cite>
            </div>
        </div>

        <div class="tipbtndelete">
          <%--  <%=MessageString.ToString()%>--%>
        </div>

    </div>
</body>
</html>
