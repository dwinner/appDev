﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiteralDemo.aspx.cs" Inherits="OtherControls.LiteralDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        div {
            margin-bottom: 10px;
        }

            div.message {
                color: <asp:Literal ID="colorLiteral" Text="red" runat="server"/>;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="message">
            The color for this text is set by a literal control
        </div>
        <div>
            Enter a color:
        <input id="colorInput" runat="server" />
            <button type="submit">Submit</button>
        </div>
    </form>
</body>
</html>
