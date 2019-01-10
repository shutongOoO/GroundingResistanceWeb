<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addpole.aspx.cs" Inherits="GroundingResistance.web.addpole" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js"></script>

    <script type="text/javascript">
        function formsubmit()
        { document.getElementById("formsub").submit(); }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".btn").click(function () {
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
            <li><a href="#">首页</a></li>
            <li><a href="#">添加</a></li>
        </ul>
    </div>

    <div class="formbody">

        <div class="formtitle"><span>基本信息</span></div>

        <form id="formsub" action="addpole.aspx" method="post">
            <ul class="forminfo">
                <li>
                    <label>线路名</label><input name="linename" type="text" class="dfinput" /><i></i></li>
                <li>
                    <label>杆塔编号</label><input name="poleid" type="text" class="dfinput" /><i></i></li>
                <li>
                    <label>经度</label><input name="longitude" type="text" class="dfinput" /><i>不用加单位</i></li>
                <li>
                    <label>纬度</label><input name="latitude" type="text" class="dfinput" /><i>不用加单位</i></li>
                <!--<li><label>文章内容</label><textarea name="" cols="" rows="" class="textinput"></textarea></li>-->
                <li>
                    <label>&nbsp;</label><input name="" type="button" class="btn" value="提交" /></li>
            </ul>
        </form>
    </div>

    <div class="tip">
        <div class="tiptop"><span>提示信息</span><a></a></div>

        <div class="tipinfo">
            <span>
                <img src="images/ticon.png" /></span>
            <div class="tipright">
                <p>是否确认提交信息 ？</p>
                <cite>如果是请点击确定按钮 ，否则请点取消。</cite>
            </div>
        </div>

        <div class="tipbtn">
            <input name="" type="button" class="sure" onclick="formsubmit();" value="确定" />&nbsp;
        <input name="" type="button" class="cancel" value="取消" />
        </div>
    </div>
</body>

</html>
