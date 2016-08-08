<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CitiesControl.ascx.cs" Inherits="Caching.CitiesControl" %>

Here are some cicies:
<%= GetCities() %>
(Rendered at <%= GetTimeStamp() %>)