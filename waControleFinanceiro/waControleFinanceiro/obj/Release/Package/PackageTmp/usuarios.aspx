<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBackend.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="waControleFinanceiro.UI.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de usuários" BorderStyle="None">
    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
    <br />
    <asp:TextBox ID="txbId" runat="server" Enabled="False"></asp:TextBox>
    <asp:CheckBox ID="cbAdm" runat="server" Text="Administrador" />
    <br />
    <asp:Label ID="lbNome" runat="server" Text="Nome"></asp:Label>
    <br />
    <asp:TextBox ID="txbNome" runat="server" Width="717px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNome" runat="server" ErrorMessage="Campo nome obrigatório" ControlToValidate="txbNome"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
       
    <br />
    <asp:TextBox ID="txbEmail" runat="server" Width="717px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbEmail" ErrorMessage="Campo e-mail obrigatório"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Senha"></asp:Label>
        <br />
        <asp:TextBox ID="txbSenha" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbSenha" ErrorMessage="Campo senha obrigatório"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Confirmar Senha"></asp:Label>
    <br />
    <asp:TextBox ID="txbConfirmarSenha" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbConfirmarSenha" ErrorMessage="Campo senha obrigatório"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Foto"></asp:Label>
    <br />
    <asp:FileUpload ID="fuFoto" runat="server" />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbSenha" ControlToValidate="txbConfirmarSenha" ErrorMessage="As senhas não conferem"></asp:CompareValidator>
    <br />
    <br />
    <asp:Button ID="btSalvar" runat="server" Text="Inserir" OnClick="btSalvar_Click" />
        <asp:Button ID="btCancelar" runat="server" OnClick="btCancelar_Click" Text="Cancelar" CausesValidation="False" />
</asp:Panel>
    <asp:Repeater ID="Repeater1" runat="server">
    </asp:Repeater>
<br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" BorderStyle="Solid" >
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True">
        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle Width="10%" />
        </asp:CommandField>
        <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" >
        <ItemStyle Width="5%" />
        </asp:BoundField>
        <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" >
        <ControlStyle Width="15%" />
        <ItemStyle Width="40%" />
        </asp:BoundField>
        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" >
        <ItemStyle Width="35%" />
        </asp:BoundField>
        <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="~/imagens/usuarios/{0}" HeaderText="Foto">
            <ControlStyle Height="150px" />
            <ItemStyle Width="10%" />
        </asp:ImageField>
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" Height="100px" VerticalAlign="Middle" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mymoneyConnectionString %>" SelectCommand="SELECT * FROM [usuarios]" DeleteCommand="DELETE FROM [usuarios] WHERE [id] = @id" InsertCommand="INSERT INTO [usuarios] ([email], [nome], [senha], [foto], [administrador]) VALUES (@email, @nome, @senha, @foto, @administrador)" UpdateCommand="UPDATE [usuarios] SET [email] = @email, [nome] = @nome, [senha] = @senha, [foto] = @foto, [administrador] = @administrador WHERE [id] = @id">
    <DeleteParameters>
        <asp:Parameter Name="id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="email" Type="String" />
        <asp:Parameter Name="nome" Type="String" />
        <asp:Parameter Name="senha" Type="String" />
        <asp:Parameter Name="foto" Type="String" />
        <asp:Parameter Name="administrador" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="email" Type="String" />
        <asp:Parameter Name="nome" Type="String" />
        <asp:Parameter Name="senha" Type="String" />
        <asp:Parameter Name="foto" Type="String" />
        <asp:Parameter Name="administrador" Type="Int32" />
        <asp:Parameter Name="id" Type="Int32" />
    </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
