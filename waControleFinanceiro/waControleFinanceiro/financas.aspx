<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBackend.Master" AutoEventWireup="true" CodeBehind="financas.aspx.cs" Inherits="waControleFinanceiro.financas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de finanças">
        <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label> <br />
        <asp:TextBox ID="txbId" runat="server" Enabled="false" ></asp:TextBox> 
        <br />
        <asp:Label ID="Label2" runat="server" Text="Data"></asp:Label>
        <asp:Calendar ID="CData" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
        <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
        <br />
        <asp:DropDownList ID="DLTipo" runat="server">
            <asp:ListItem Selected="True">Receita</asp:ListItem>
            <asp:ListItem>Despesa</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Descrição"></asp:Label>
        <br />
        <asp:TextBox ID="txbDescricao" runat="server" Rows="4" TextMode="MultiLine" Width="50%"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Valor"></asp:Label>
        <br />
        <asp:TextBox ID="txbValor" runat="server" TextMode="Number"></asp:TextBox>

        <br />

        <br />
        <asp:Button ID="btSalvar" runat="server" Text="Inserir" OnClick="btSalvar_Click" />
        <asp:Button ID="btCancelar" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btCancelar_Click" />
        
    </asp:Panel> 
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="valor" HeaderText="Valor" />
            <asp:BoundField DataField="tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="data" HeaderText="Data" dataformatstring="{0:dd/MM/yyyy}" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </asp:Content>
