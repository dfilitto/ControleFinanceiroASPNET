<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="waControleFinanceiro.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="css/home.css">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulário de login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Login de usuário" CssClass="login">
                <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                <br />
                <asp:TextBox ID="txbLogin" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
                <br />
                <asp:TextBox ID="txbSenha" runat="server" TextMode="Password"></asp:TextBox>
                
                <asp:Button ID="btlogar" runat="server" Text="Logar" OnClick="btlogar_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
