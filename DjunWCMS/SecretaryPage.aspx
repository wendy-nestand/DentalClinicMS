<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecretaryPage.aspx.cs" Inherits="DjunWCMS.SecretaryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SecretaryPage</title>
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
</head>
<body>
     <script type="text/javascript"
            href="./Style/js/jquery.js">
    </script>
    <script type="text/javascript"
            href="./Style/js/bootstrap.min.js">
    </script>
    <form class="form-container " id="form2" runat="server">
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
                 <h2 class="text-success fw-bold text-center">Secretary Panel </h2>
                 <hr class="bg-primary"/>
                    <div class="row">
                        <asp:Button ID="btnPatientProfile" runat="server" Text="Client"  />
                        <asp:Button CssClass="button-container bg-gradient border-0  " ID="btnReservation" runat="server" Text="Reservation"  />
                    </div>


                

        </div>
    </div>
       </div>
        </div>

        </form>
</body>
</html>
