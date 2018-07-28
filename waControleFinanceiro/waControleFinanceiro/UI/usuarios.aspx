<%@ Page Title="" Language="C#" MasterPageFile="~/UI/SiteBackend.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="waControleFinanceiro.UI.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de usuários">
    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
    <br />
    <asp:TextBox ID="txbId" runat="server"></asp:TextBox>
    <asp:CheckBox ID="cbAdm" runat="server" Text="Administrador" />
    <br />
    <asp:Label ID="lbNome" runat="server" Text="Nome"></asp:Label>
    <br />
    <asp:TextBox ID="txbNome" runat="server" Width="717px"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
    <br />
    <asp:TextBox ID="txbEmail" runat="server" Width="717px"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Senha"></asp:Label>
    <br />
    <asp:TextBox ID="txbSenha" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Confirmar Senha"></asp:Label>
    <br />
    <asp:TextBox ID="txbConfirmarSenha" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Foto"></asp:Label>
    <br />
    <asp:FileUpload ID="fuFoto" runat="server" />
    <br />
    <br />
    <asp:Button ID="btSalvar" runat="server" Text="Salvar" OnClick="btSalvar_Click" />
</asp:Panel>
    <asp:Repeater ID="Repeater1" runat="server">
    </asp:Repeater>
<br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
        <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
        <asp:BoundField DataField="senha" HeaderText="senha" SortExpression="senha" />
        <asp:BoundField DataField="foto" HeaderText="foto" SortExpression="foto" />
        <asp:BoundField DataField="administrador" HeaderText="administrador" SortExpression="administrador" />
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="~/imagens/usuarios/{0}" HeaderText="Foto">
        </asp:ImageField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mymoneyConnectionString %>" SelectCommand="SELECT * FROM [usuarios]"></asp:SqlDataSource>
</asp:Content>
