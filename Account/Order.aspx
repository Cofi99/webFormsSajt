<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="IzradaWebFormsSajta.Account.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Izaberi zeljenu robu" CssClass="input-group-text"></asp:Label><br />
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown"></asp:DropDownList><br />

    <asp:Label ID="Label2" runat="server" Text="Unesi kolicinu zeljene robe" CssClass="input-group-text"></asp:Label><br />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Morate uneti kolicinu!!!" ControlToValidate="TextBox1" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Niste dobro uneli kolicinu!!!" ValidationExpression="[0-9]\d+" ControlToValidate="TextBox1" EnableClientScript="False" ForeColor="Red"></asp:RegularExpressionValidator>
    <br />

    <asp:Button ID="Button1" runat="server" Text="Poruci" CssClass="btn btn-outline-success btn-success btn-lg" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Shipments Worldwide" CssClass="input-group-text" Visible="False"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table"></asp:GridView>

    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
</asp:Content>
