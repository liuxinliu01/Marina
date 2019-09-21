<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Ch09Cart.ContactUs" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div">
        <article>
            Inland Lake Marina<br/>
            Box 123<br/>
            Inland Lake, Arizona<br/>
            86038<br/>
            (office ph) 928-450-2234<br/>
            (leasing ph) 928-450-2235<br/>
            (fax) 928-450-2236<br/>
            Manager: Glenn Cooke<br/>
            Slip Manager: Kimberley Carson<br/>
            Contact email: info@inlandmarina.com<br/>
        </article>
    </div>
    <div class="form-group" style="margin-top: 50px;">
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
            <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="Contact Us" />
        </div>
    </div>
</asp:Content>