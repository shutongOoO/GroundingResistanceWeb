<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historiedData.aspx.cs" Inherits="GroundingResistance.web.historiedData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".click").click(function () {
                $(".tip").fadeIn(200);
            });

            $(".tiptop a").click(function () {
                $(".tip").fadeOut(200);
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

    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
           <%-- <li><a href="historiedData.aspx?cid=1">首页</a></li>--%>
            <li><a href="#">首页</a></li>
            <li><a href="#">历史数据</a></li>
        </ul>
    </div>

    <div class="rightinfo">

<%--        <div class="tools">

            <ul class="toolbar">
                <!--<li><span><img src="images/t04.png" /></span>统计</li>-->
            </ul>


            <ul class="toolbar1">
               <li><span>
                    <img src="images/t05.png" /></span>设置</li>
            </ul>

        </div>--%>

        <!--显示杆塔信息-->
        <table class="tablelist">
            <thead>
                <tr>
                    <th>线路<i class="sort"><img src="images/px.gif" /></i></th>
                    <th>杆塔</th>
                    <th>经度</th>
                    <th>纬度</th>
                    <th>时间</th>
                    <th>检察员</th>
                    <th>设备</th>
                    <th>数据</th>
                </tr>
            </thead>
           <%=HisData.ToString()%>
        </table>


        <div class="pagin">
           <%=pageInfo.ToString() %>
        </div>


        <div class="tip">
            <div class="tiptop"><span>提示信息</span><a></a></div>

            <div class="tipinfo">
                <span>
                    <img src="images/ticon.png" /></span>
                <div class="tipright">
                    <p>是否确认对信息的修改 ？</p>
                    <cite>如果是请点击确定按钮 ，否则请点取消。</cite>
                </div>
            </div>

            <div class="tipbtn">
                <input name="" type="button" class="sure" value="确定" />&nbsp;
        <input name="" type="button" class="cancel" value="取消" />
            </div>

        </div>




    </div>

    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
    </script>

</body>

</html>
