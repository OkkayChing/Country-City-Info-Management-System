<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCountries.aspx.cs" Inherits="CountryCityInfoApp.UI.ViewCountries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Countries</title>
    <link href="../Content/Main.css" rel="stylesheet" />
     <!-- Bootstrap Core CSS -->
    <link href="../site-content/css/bootstrap.min.css" rel="stylesheet">
    <link href="..site-content/css/modern-business.css" rel="stylesheet">
	<link href="../site-content/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
</head>
<body>
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">Start Bootstrap</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="../UI/Index.aspx">Home</a>
                    </li>
                    <li>
                        <a href="../UI/CountryEntry.aspx">Country Entry</a>
                    </li>
                    <li>
                        <a href="../UI/CityEntry.aspx">City Entry</a>
                    </li>
                     <li>
                        <a href="../UI/ViewCities.aspx">View Cities</a>
                    </li>
                    <li>
                        <a href="../UI/ViewCountries.aspx">View Countries</a>
                    </li>
                    <li>
                        <a href="../UI/ViewCountries.aspx">About</a>
                    </li>
                 
                    
                </ul>
            </div>
           
        </div>
        
    </nav>
    <form id="form1" runat="server">
         
         <div class="container1">
            <div class="header"><center><h3>View Countries</h3></center></div>
         <div class="container2">
    
        <asp:Label ID="Label1" runat="server" Text="Name :"></asp:Label>
             &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="countryNameTextBox" runat="server" Width="105px"></asp:TextBox>
&nbsp;<asp:Button ID="searchButton" runat="server" OnClick="searchButton_Click" Text="Search" />
             <br />
        <br />
        <asp:GridView AutoGenerateColumns="False" ID="showGridView" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="showGridView_PageIndexChanging" PageSize="1">
            <Columns>
                <asp:TemplateField HeaderText="SL#">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CountryName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="About">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("About")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. Of Dwellers">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("No_Of_Dwellers")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="No. Of City">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("No_OF_City")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
              
                
                   </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
      </div>
    </div>
    </form>
</body>
</html>
