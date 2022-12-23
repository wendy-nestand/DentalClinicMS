<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="DjunWCMS.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Djun CMS</title>
    <link rel="stylesheet" href="Style/style.css" />

</head>
<body>
    <div class="container">
        <div class="credentials-container">
            <form class="form credentials-form" id="fmcredentials" runat="server">
                 <label class=" lbl lblUsername" id="lblUsername">Username</label>
                <asp:TextBox class=" input input-username" id="tbUser" placeholder="Username" runat="server" />
                <label class="lbl lblPassword" id="lblPassword" typeof="password">Password</label>
                <asp:TextBox class=" input input-password" id="tbPass" placeholder="Password" runat="server" />
                 <div class="button-container">
                <button class="button btnCancel" id="btnCancel"> Close</button>
                <asp:button class="button btnSignIn" id="btnSignIn" runat="server" OnClick="btnSignIn_Click" Text="Sign In"> </asp:button>
            </div>
            </form>
     
        </div>
        
    </div>
    
</body>
</html>
