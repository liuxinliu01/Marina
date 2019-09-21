<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Ch09Cart.WebForm2" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainPlaceHolder" runat="server">

        <h2>Register</h2>

        <!--- Register start  -->
       <div class="center-page">
           <label class="col-xs-11">First Name:</label>
           <div class="col-xs-11">
               <asp:TextBox ID="fnameTextBox" runat="server" Class="form-control" placeholder="First Name"></asp:TextBox>
           </div>

           <label class="col-xs-11">Last Name:</label>
           <div class="col-xs-11">
               <asp:TextBox ID="lnameTextBox" runat="server" Class="form-control" placeholder="Last Name"></asp:TextBox>
           </div>

           <label class="col-xs-11">Phone Number:</label>
           <div class="col-xs-11">
               <asp:TextBox ID="phoneTextBox" runat="server" class="form-control" placeholder="Phone Number"></asp:TextBox>
           </div>

           <label class="col-xs-11">City:</label>
           <div class="col-xs-11">
               <asp:TextBox ID="cityTextBox" runat="server" Class="form-control" placeholder="City"></asp:TextBox>
           </div>
           <div class="col-md-2"></div>
           <div class="col-xs-11 space-vert">
               <asp:Button ID="registerButton" runat="server" Class="btn btn-success" Text="Register" OnClick="registerButton_Click" />
           </div>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarinaConnectionString %>" SelectCommand="SELECT [ID], [FirstName], [LastName], [Phone], [City] FROM [Customer]"></asp:SqlDataSource>
             <div class="form-group">
                     <div class="col-md-2"></div>
                     <div class="col-md-6">
                         <asp:Label ID="lblError" runat="server" CssClass="text-danger" ></asp:Label>
                     </div>

                  </div>
    
       </div>
    </asp:Content>
