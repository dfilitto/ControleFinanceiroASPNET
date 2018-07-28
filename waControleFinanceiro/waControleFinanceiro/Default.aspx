<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBackend.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="waControleFinanceiro.UI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
<asp:Label ID="lbNome" runat="server" Text="Label"></asp:Label>
<br />
<asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
<asp:Label ID="lbEmail" runat="server" Text="Label"></asp:Label>
<br />
<asp:Image ID="IUser" runat="server" />
<br />
</asp:Content>
