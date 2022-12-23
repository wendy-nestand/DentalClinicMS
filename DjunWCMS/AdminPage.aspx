<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="DjunWCMS.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="./Style/AdminPage.css" />
   <!--<link href="./Style/style.css" rel="stylesheet" />-->
    <!-- CSS only -->
<!--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">-->
    <link rel="stylesheet"
          type="text/css"
          href="./Style/css/bootstrap.css" />
    
</head>

<body>
    <script type="text/javascript"
            href="./Style/js/jquery.js">
    </script>
    <script type="text/javascript"
            href="./Style/js/bootstrap.min.js">
    </script>
    <form class="form-container " id="form1" runat="server">
        <div class="container ">
              <div class="row">
                <div class="col-4 column">
                  
                        <asp:Label CssClass="lbl" ID="Label1" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox CssClass="txb input txbUsername" ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                        <asp:Label cssClass="txb" ID="Label2" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox CssClass="txb input txbPass" ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:Label cssClass="lbl" ID="Label3" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox CssClass="txb input txbName" ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:DropDownList CssClass="ddlType" ID="DropDownList1" runat="server">
                            <asp:ListItem>Secretaire</asp:ListItem>
                            <asp:ListItem>Docteur</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox CssClass="txb input txbNotes" ID="TextBox4" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <asp:Button CssClass="btn btnCreateAccount" ID="Button1" runat="server" Text="Button" />
                </div>
                
                <div class="col-4">
                    
                        <asp:Label ID="Label4" runat="server" Text="Phone/Name"></asp:Label>
                        <asp:TextBox ID="txbFind" runat="server"></asp:TextBox>
                        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                    
                </div>
                <div class="col-4">
                   
                        <asp:Label CssClass="lbl" ID="lblAccountId" runat="server" Text="Account ID"></asp:Label>
                        <asp:TextBox CssClass="txb input txbAccountId" ID="txtAccountId" runat="server"></asp:TextBox>
                        <asp:Label cssClass="txb" ID="lblViewUsername" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox CssClass="txb input txbUsername" ID="txtUser" runat="server"></asp:TextBox>
                        <asp:Label cssClass="lbl" ID="lblName" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox CssClass="txb input txbViewName" ID="txtName" runat="server"></asp:TextBox>
                        <asp:Label CssClass="lbl" ID="lblDob" runat="server" Text="DOB"></asp:Label>
                        <asp:TextBox CssClass="txb input txbDob" ID="txtDob" runat="server"></asp:TextBox>
                        <asp:Label cssClass="txb" ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                        <asp:TextBox CssClass="txb input txbPhone" ID="txtPhone" runat="server"></asp:TextBox>
                        <asp:Label cssClass="lbl" ID="lblType" runat="server" Text="Type"></asp:Label>
                        <asp:TextBox CssClass="txb input txbType" ID="txtType" runat="server"></asp:TextBox>
                        <asp:Label CssClass="lbl" ID="lblNotes" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox CssClass="txb input txbNotes" ID="txtNoteView" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <asp:Label cssClass="txb" ID="lblCreatedOn" runat="server" Text="CreatedOn"></asp:Label>
                        <asp:TextBox CssClass="txb input txbCreatedOn" ID="txtCreate" runat="server"></asp:TextBox>
                        <button class="btn btnDelete">Delete Account</button>
                </div>
               
              </div>
            </div>
         
       
    </form>
  
</body>

    <footer>
        <!-- JavaScript Bundle with Popper -->
<!--<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>-->
    </footer>
</html>
