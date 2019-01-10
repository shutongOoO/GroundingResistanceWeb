<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GroundingResistance.web.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>欢迎登录后台管理系统</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script src="js/cloud.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            $(window).resize(function () {
                $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            })
        });
    </script>
    <!--<script type="text/javascript">
        $(document).ready(function ()
        {

        }
        )
    </script>-->

</head>

<body style="background-color:#1c77ac; background-image:url(images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">



    <div id="mainBody">
        <div id="cloud1" class="cloud"></div>
        <div id="cloud2" class="cloud"></div>
    </div>


    <div class="logintop">
        <span>欢迎登录后台管理界面平台</span>
        <ul>
            <li><a href="#">回首页</a></li>
            <li><a href="#">帮助</a></li>
            <li><a href="#">关于</a></li>
        </ul>
    </div>

    <div class="loginbody">

        <span class="systemlogo"></span>

        <div class="loginbox">
            <form action="login.aspx" method="post">
                <ul>
                    <li><input name="username" type="text" class="loginuser" value="" onclick="JavaScript:this.value=''" /></li>
                    <li><input name="password" type="password" class="loginpwd" value="" onclick="JavaScript:this.value=''" /></li>
                    <li><input name="" type="submit" class="loginbtn" value="登录" /><label><input name="" type="checkbox" value="" checked="checked" />记住密码</label><label><a href="#">忘记密码？</a></label></li>
                </ul>
            </form>
        </div>

    </div>



    <div class="loginbm">版权所有  2018    山东建筑大学   机器人研究院  </div>


</body>

</html>
