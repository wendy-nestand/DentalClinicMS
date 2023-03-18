<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="DjunWCMS.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdminPage</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <style type="text/css">
    body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous"/>

<%--         <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous"/>--%>
        <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" />
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                 
       <!-- New Code -->

        <style>
         .cssPager td
        {
              padding-left: 4px;     
              padding-right: 4px;   
              

          }
         .sizeTab{
           
             padding-right:-80px;
         }
    </style>
  <div class="container text-center">
   <div class="row">
    <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
    <div class="border p-2 mt-1">  
         <h2 class="text-success fw-bold text-center">Admin Panel </h2>
         <hr class="bg-primary"/>

        <asp:GridView ID="GridView1" Width="100%" border="0" CellPadding="0" Class="table table-responsive"
                        HeaderStyle-BackColor="#0099cc" 
                        HeaderStyle-ForeColor="White" 
                        ForeColor="#333333"
                        GridLines="None" runat="server" 
                        ShowFooter="true" AllowPaging="true" 
                        PageSize="5" AutoGenerateColumns="false"
                        DataKeyNames="account_id" 
                        OnPageIndexChanging="gvDetails_PageIndexChanging"
                        OnRowCommand ="gvDetails_RowCommand" OnRowEditing="gvEdit"
                        OnRowDeleting="GridView1_RowDeleting"
            >

             <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Back"
            NextPageText="Next" LastPageText="Last" />
            <Columns>

                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblAccountId" runat="server" Text='<%# Eval("account_id")%>'/>
                    </ItemTemplate>
                </asp:TemplateField>
       
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblAccountName" runat="server" Text='<%# Eval("account_name")%>'/>
                    </ItemTemplate>
                    
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Date">
                    <ItemTemplate>
                        <asp:Label ID="lblAccountCreationDate" runat="server" TextMode="Date" Text='<%# Eval("account_creation_date")%>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText = "Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblAccountPhone" Width="100%" runat="server" Text='<%# Eval("account_phone")%>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>

               <%-- <asp:TemplateField HeaderText="Action">
                   <ItemTemplate >
                        <asp:LinkButton runat="server" ID="link" CommandArgument='<%# Eval("account_id") %>' OnClick="link_Click">Edit</asp:LinkButton>
                   </ItemTemplate>
               </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="Action">              
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CommandName="Edit" runat="server" Text="Edit" />
                        <%--<asp:LinkButton runat="server" ID="link" class="btn btn-info" CommandArgument="<%# Eval("account_id") %>" OnClick="link_Click1" ><i class="bi bi-pencil-square" ></i> &nbsp;Edit</asp:LinkButton>--%>
                        <asp:LinkButton ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" CommandName="Delete" class="btn btn-danger"> <i class="bi bi-trash"> &nbsp;Delete</i> </asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>            
                        <asp:LinkButton  runat="server" OnClick="linkAdd_Click" class="btn btn-info" id="linkAdd" CommandName="AddNew" ValidationGroup="validation"><i class="bi bi-person-plus"></i>&nbsp;Add New</asp:LinkButton>
                    </FooterTemplate>
                 </asp:TemplateField>
            </Columns>

            <EditRowStyle BackColor="#787777" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True"></HeaderStyle>
                                <PagerStyle BackColor="#666666" CssClass="cssPager" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />  

        </asp:GridView>   
        <asp:Label runat="server" class="text-primary text-center" Font-Bold="true" Font-Size="Larger" ID="lblPagePos"></asp:Label>
        <br /><br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
       <br />
   </div>
</div>
</div>

       <div>
      
        </div>
       </div>
        <!-- Fin New Code -->
<!-- /.col-lg-12 -->

    </form>
   <footer>
        <!-- JavaScript Bundle with Popper -->
<!--<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>-->
    </footer>

     <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
     <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js" integrity="sha384-mQ93GR66B00ZXjt0YO5KlohRA5SY2XofN4zfuZxLkoj1gXtW8ANNCe9d5Y3eG5eD" crossorigin="anonymous"></script>
</body>

   
</html>
