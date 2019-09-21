<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Ch09Cart.ContactUs" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div class="form-group">
        <label class="control-label col-sm-3">Your Name:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-sm-3">Your Zip Code:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="txtZip" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-sm-3">Your Thoughts:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="txtComments" TextMode="MultiLine" runat="server" 
                CssClass="form-control" Rows="6"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-offset-3 col-sm-3">
            <asp:Button ID="btnSubmit" runat="server" Text="Contact Us" CssClass="btn" />
        </div>
    </div>
</asp:Content>