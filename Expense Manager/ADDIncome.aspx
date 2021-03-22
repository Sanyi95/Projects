<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADDIncome.aspx.cs" Inherits="ExpenseManager.ADDIncome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Income</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
<div class="row">
<div class="col-md-4"></div>
<div class="col-md-4">
<div class="form-group">
<label class="text-uppercase">Income Category</label>
    <asp:DropDownList ID="ddlMainCategory" runat="server"></asp:DropDownList>
</div>

<div class="form-group">
<label class="text-uppercase">Income Category</label>
    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Button ID="Button1" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="ADD" />
</div>

</div>
<div class="col-md-4"></div>
</div>

<div class="row">
<div class="col-md-2"></div>
<div class="col-md-8">
    <asp:GridView ID="GridView1" CssClass="table table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

</div>
<div class="col-md-2"></div>
</div>

</div>

</asp:Content>
