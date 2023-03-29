<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoPage.aspx.cs" Inherits="DjunWCMS.InfoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             
                    
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                             <div class="form-group mt-1">
                                <asp:TextBox ID="txtAccountId" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="form-group mt-1">
                                <asp:TextBox ID="txtUsername" placeholder="Enter a user name" CssClass="form-control" runat="server"></asp:TextBox>
                               
                            </div>
                            <div class="form-group mt-1">
                                <asp:TextBox ID="txtPassword"  placeholder="Enter a password"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                           
                            <div class="form-group mt-2">
                                <asp:TextBox ID="txtName" runat="server" TabIndex="3" MaxLength="75" CssClass="form-control"
                                    placeholder="Enter your full name"></asp:TextBox>
                            </div>
                             <div class="form-group mt-2">
                                <asp:Textbox ID="clDob" CssClass="form-control"  runat="server"></asp:Textbox>
                            </div>
                            <div class="form-group mt-2">
                                <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" TabIndex="3" MaxLength="75" CssClass="form-control"
                                    placeholder="Enter a phone number"></asp:TextBox>
                            </div>
                              <div class="form-group mt-2">
                                <%-- <asp:select class="form-select" id="selectType" aria-label="Default select example">
                                  <option selected ="selected">Open this select menu</option>
                                  <option value="1">Secretaire</option>
                                  <option value="2">Docteur</option>
                                  <option value="3">Admin</option>
                                </asp:select>--%>
                                <asp:DropDownList ID="ddlType" runat="server" >  
                                <asp:ListItem>Secretaire </asp:ListItem>  
                                <asp:ListItem>Docteur</asp:ListItem>  
                                <asp:ListItem>Patient</asp:ListItem>  
                            </asp:DropDownList> 
                            </div>
                             <div class="form-group mt-2">
                                <asp:TextBox ID="txtNoteView" runat="server" TextMode="Phone" TabIndex="3" MaxLength="75" CssClass="form-control"
                                    placeholder="Enter a notes"></asp:TextBox>
                            </div>
                             <div class="form-group mt-2">
                                <asp:TextBox ID="txtCreate" runat="server" TextMode="Phone" TabIndex="3" MaxLength="75" CssClass="form-control"
                                    ></asp:TextBox>
                            </div>
                          

                             <div class="form-group mt-2">
                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" TabIndex="3" MaxLength="75" CssClass="form-control"
                                    placeholder="Enter a comment"></asp:TextBox>
                            </div>
                        </div>
                    </>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-info" />
                        <button type="button" class="btn btn-info">
                            Cancel</button>
                    </div>
                </div>
           
    </form>
</body>
</html>
