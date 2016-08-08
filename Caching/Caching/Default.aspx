<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Caching.Default" %>

<%@ Register TagPrefix="CC" TagName="Time" Src="CurrentTime.ascx" %>
<%@ Register TagPrefix="CC" TagName="Cities" Src="CitiesControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        div.panel {
            margin: 5px;
            padding: 5px;
            border: thin solid black;
        }
    </style>
</head>
<body>
    <div class="panel">
        The time from the page is <%= DateTime.Now.ToLongTimeString() %>
    </div>
    <div class="panel">
        The time from the code-behind page is <%= GetTime() %>
    </div>
    <div class="panel">
        <CC:Time runat="server" />
    </div>
    <div class="panel">
        <CC:Cities runat="server" />
    </div>
</body>
</html>
