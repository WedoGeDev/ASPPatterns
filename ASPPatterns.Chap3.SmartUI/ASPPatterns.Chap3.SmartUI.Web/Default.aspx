<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col">
            Display Prices with:
            <asp:DropDownList ID="ddlDiscountType" OnSelectedIndexChanged="ddlDiscountType_SelectedIndexChanged" runat="server" AutoPostBack="true">
                <asp:ListItem Value="0">No Discount</asp:ListItem>
                <asp:ListItem Value="1">Trade Discount</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ShopConnectionString %>' SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" ReadOnly="True" InsertVisible="False" SortExpression="ProductId"></asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"></asp:BoundField>
                    <asp:BoundField DataField="RRP" HeaderText="RRP" SortExpression="RRP"></asp:BoundField>
                    <asp:TemplateField HeaderText="SellingPrice" SortExpression="SellingPrice">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSellingPrice" Text='<%# Bind("SellingPrice") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Discount">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDiscount"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Savings">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSavings"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
