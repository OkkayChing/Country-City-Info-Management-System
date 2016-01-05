<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeBehind="CityEntry.aspx.cs" Inherits="CountryCityInfoApp.UI.CityEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>City Entry</title>
     <link href="../Content/font-awesome.css" rel="stylesheet" />
    <link href="../froala_editor_1.2.7/css/froala_editor.css" rel="stylesheet" />
    <link href="../froala_editor_1.2.7/css/froala_style.css" rel="stylesheet" />
       <link href="../Content/Main.css" rel="stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../site-content/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="..site-content/css/modern-business.css" rel="stylesheet"/>
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
                <a class="navbar-brand" href="index.html">City Entry</a>
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
    <div>
        <div class="container1">
            <div class="header"><center><h3>City Entry Page</h3></center></div>
         <div class="container2">
    
        <asp:Label ID="Label1" runat="server" Text="Name :"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="About :"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <textarea id="edit" cols="20" name="edit" rows="2"></textarea><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="No. of dwellers :"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="noOfDwellersTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Location :"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="locationTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Weather :"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="weatherTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Country :"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="countryDropDownList" runat="server" Width="13%">
        </asp:DropDownList>
             <br />
        <br />
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cancelButton" runat="server" Text="Cancel" OnClick="cancelButton_Click" />
        <br />
        <asp:Label ID="showLabel" runat="server"></asp:Label>
        <br />
        <asp:GridView AutoGenerateColumns="False" ID="cityShowGridView" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
             <Columns>
                <asp:TemplateField HeaderText="SL#">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CityName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="Dwellers">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("No_Of_Dwellers")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Weather">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CountryName")%>'></asp:Label>
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
    </div>
    </form>
    <script src="../Scripts/jquery-2.1.4.js"></script>
    <script src="../froala_editor_1.2.7/js/froala_editor.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/tables.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/lists.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/colors.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/media_manager.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/font_family.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/font_size.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/video.min.js"></script>
    <script src="../froala_editor_1.2.7/js/plugins/block_styles.min.js"></script>
    <script>
        $(function () {
            $('#edit').editable({ inlineMode: false, height: 150, width:750, alwaysBlank: true })
        });
  </script>
</body>
</html>
