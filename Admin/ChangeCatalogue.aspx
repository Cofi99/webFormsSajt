<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeCatalogue.aspx.cs" Inherits="IzradaWebFormsSajta.Admin.ChangeCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="ErrorLabel" runat="server" Text="" Font-Bold="true"></asp:Label>

    <h3>Insert Equipment</h3>

    <asp:Panel ID="Panel1" runat="server" CssClass="form-group">

        <asp:Label ID="Label1" runat="server" Text="Equipment Name:" Font-Bold="true"></asp:Label>

        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox>

    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" CssClass="form-group">

        <asp:Label ID="Label2" runat="server" Text="Equipment Manufacturer:" Font-Bold="true"></asp:Label>

        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>

    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" CssClass="form-group">

        <asp:Label ID="Label3" runat="server" Text="Equipment Type:" Font-Bold="true"></asp:Label>

        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>

    </asp:Panel>

    <asp:Panel ID="Panel5" runat="server" CssClass="form-group">

        <asp:Label ID="Label4" runat="server" Text="Equipment Cost:" Font-Bold="true"></asp:Label>

        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>

    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" CssClass="form-group">

        <asp:Button ID="Button1" runat="server"
            Text="Insert Equipment"
            CssClass="btn btn-outline-success btn-success btn-lg" OnClick="Button1_Click"/>

    </asp:Panel>

    <asp:Label ID="lblOutput"
        runat="server"
        Text=""
        Font-Bold="true"></asp:Label>

    <%--Da bi se TextBox-ovi crveneli ako unos nije dobar,
        moramo svuda staviti property EnableClientScript="false".
        Docs: https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.basevalidator.enableclientscript?view=netframework-4.8
        --%>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ErrorMessage="Enter Name!"
        ControlToValidate="TextBox1"       
         ForeColor="red"
         Font-Bold="true"
         EnableClientScript="false"
         Display="None"></asp:RequiredFieldValidator>

    <%--Regularni izraz [a-zA-Z]+ oznacava da su za unos dozvoljena
        samo mala i velika slova abecede jedan ili vise puta.
        Tj. ime koje se unosi mora imati bar jedno malo i/ili veliko slovo
        engleske abecede.
        --%>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
        ErrorMessage="Enter Manufacturer!"
         ControlToValidate="TextBox2"
        ForeColor="red"
         Font-Bold="true"
        EnableClientScript="false"
        Display="None">

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
        runat="server"
        ErrorMessage="Manufacturer Name can only have letters!"
        ControlToValidate="TextBox2"
        ForeColor="Red"
        Font-Bold="true"
        EnableClientScript="false"
        ValidationExpression="[a-zA-Z]+"
        Display="None"
        ></asp:RegularExpressionValidator>

    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
        ErrorMessage="Type!"
         ControlToValidate="TextBox3"
        ForeColor="Red"
        Font-Bold="true"
        EnableClientScript="false"
        Display="None"
        >

        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
        runat="server"
        ErrorMessage="Manufacturer Name can only have letters!"
        ControlToValidate="TextBox3"
        ForeColor="Red"
        Font-Bold="true"
        EnableClientScript="false"
        ValidationExpression="[a-zA-Z]+"
        Display="None"
        ></asp:RegularExpressionValidator>

    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
        ErrorMessage="Cost!"
         ControlToValidate="TextBox4"
        ForeColor="Red"
        Font-Bold="true"
        EnableClientScript="false"
        Display="None"
        >

        <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
        runat="server"
        ErrorMessage="Manufacturer Name can only have letters!"
        ControlToValidate="TextBox4"
        ForeColor="Red"
        Font-Bold="true"
        EnableClientScript="false"
        ValidationExpression="[0-9]\d+"
        Display="None"
        ></asp:RegularExpressionValidator>

    </asp:RequiredFieldValidator>


    <h3>Equipment in Database</h3>

    <asp:sqldatasource id="GridView1Source"
        selectcommand="SELECT * FROM equipmenttbl"
        connectionstring="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DzonijevSajt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" 
        runat="server"/>

    <asp:GridView ID="GridView1" runat="server"
        DataSourceID="GridView1Source"
        EmptyDataText="No Data"
        EmptyDataRowStyle-ForeColor="Red"
         AutoGenerateColumns="true"
         CssClass="table"
         ></asp:GridView>
</asp:Content>
