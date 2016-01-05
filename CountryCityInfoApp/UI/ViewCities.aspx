<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCities.aspx.cs" Inherits="CountryCityInfoApp.UI.ViewCities" %>

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
     <!-- Navigation -->
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
                <a class="navbar-brand" href="index.html">View Countries</a>
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
    <!-- /.container ---------------------------------------------------------------------------------------------------------->
    
    <form id="form1" runat="server">
         <div class="container1">
            <div class="header"><center><h3>View Cities</h3></center></div>
         <div class="container2">
        <asp:RadioButton ID="cityRadioButton" runat="server" GroupName="city" Text="CityName" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="cityNameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:RadioButton ID="countryRadioButton" runat="server" GroupName="city" Text="Country" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="countryDropDownList" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="searchButton" runat="server" OnClick="searchButton_Click" Text="Search" />
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
        <asp:GridView AutoGenerateColumns="False" ID="cityViewGridView" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="cityViewGridView_PageIndexChanging" PageSize="1">
             <Columns>
                <asp:TemplateField HeaderText="SL#">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Name")%>'></asp:Label>
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
                  <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Location")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Weather">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Weather")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CountryName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AboutCountry">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("AboutCountry")%>'></asp:Label>
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
      </div>
    </div>
    </form>
</body>
</html>
