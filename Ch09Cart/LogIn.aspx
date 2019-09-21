<%@ Page Title="LogIn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Ch09Cart.WebForm1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainPlaceHolder" runat="server">
        <!--- Sign in start  -->
        <div>
            <div class="form-horizontal">
                <h2>Log In</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="First Name:"></asp:Label>
                    <div class="col-md-3 col-lg-7">
                       <asp:TextBox ID="fname" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" CssClass="text-danger" ErrorMessage="Please enter first Name" ControlToValidate="fname"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Last Name:"></asp:Label>
                    <div class="col-md-3 col-lg-7">
                       <asp:TextBox ID="lname" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Last Name is required" ControlToValidate="lname"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                        <div class="col-md-2"></div>
                    <div class="">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarinaConnectionString %>" SelectCommand="SELECT [ID], [FirstName], [LastName], [Phone], [City] FROM [Customer]"></asp:SqlDataSource>
                       <asp:Button ID="loginButton" runat="server" class="btn btn-primary" Text="Log In" OnClick="loginButton_Click" />
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Register.aspx" class="btn btn-link" CausesValidation="False">Register</asp:LinkButton>
                    </div>
                   
                </div>
                 <div class="form-group">
                     <div class="col-md-2"></div>
                     <div class="col-md-6">
                         <asp:Label ID="lblError" runat="server" CssClass="text-danger" ></asp:Label>
                     </div>

                  </div>
                
                
            </div>
        </div>
  </asp:Content>
