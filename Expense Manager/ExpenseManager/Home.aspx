<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExpenseManager.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
                <h1>Add Expense</h1>
            </div>
        <div class="row alert-danger">
        <div class="col-md-3">
        <div class="form-group">
        
        <label>Main Category:</label>
            <asp:DropDownList ID="ddlMainCategory" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        </div>

            <div class="col-md-2">
        <div class="form-group">
        
        <label>Income Category:</label>
            <asp:DropDownList ID="ddlIncCategory" Cssclass="form-control" runat="server"></asp:DropDownList>

        </div>
        </div>

            <div class="col-md-5">
        <div class="form-group">
        
        <label>Description:</label>
            <asp:TextBox ID="txtDesc" Cssclass="form-control" runat="server" TextMode="Multiline"></asp:TextBox>

        </div>
        </div>

            <div class="col-md-3">
        <div class="form-group">
        
        <label>Amount:</label>
            <asp:TextBox ID="txtAmt" Cssclass="form-control" runat="server" TextMode="Number"></asp:TextBox>

        </div> 
      </div> 

        </div> 

        <div class="row">
        <div class="col-md-3">
        <div class="form-group">
            <asp:Button ID="btnSubmit" Cssclass="btn btn-success btn-lg" runat="server" Text="ADD" />

        </div>
        </div>
        </div>

        <div class="row">
        <h3 class="text-center">All Expense List</h3>

        <div class="col-md-1"></div>
        <div class="col-md-10">
        <div class="table-responsive">
            <asp:GridView ID="GridView1" CssClass="table table-responsive table-hover" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>

        </div>

        </div>
        <div class="col-md-1"></div>
       
        </div>
           

      </div> 
  
</asp:Content>
