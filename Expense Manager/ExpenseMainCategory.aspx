<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ExpenseMainCategory.aspx.cs" Inherits="ExpenseManager.ExpenseMainCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Expense Main Category</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
<div class="row">
<div class="col-md-4"></div>
<div class="col-md-4">
<div class="form-group">
<label>Enter Expense Type:</label>
    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControltoValidate="TextBox1" ErrorMessage="* enter expense type..." ForeColor="Red"></asp:RequiredFieldValidator>
</div>

    <div class="col-md-4">
    <div class="form-group">
    <asp:Button ID="Button1" CssClass="btn btn-success btn-lg" runat="server" Text="Submit" OnClick="Button1_Click" />
        
</div>
</div>
<div class="col-md-4">



</div>
</div>

<div class="row">
<div class="col-md-12">
    <asp:GridView ID="GridView1" CssClass="table table-hover" runat="server" EmptyDataText="Record Not Found" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
</div>
</div>
</div>
</asp:Content>
