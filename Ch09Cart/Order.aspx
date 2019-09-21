<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Ch09Cart.Order" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div class="row"><%-- end of row 2 --%>
        <div class="col-sm-8"><%-- end of row 2 --%>
            <div class="form-group">
                <label class="col-sm-6">Please select a Dock:</label>
                <div class="col-sm-6">
                    <asp:DropDownList ID="ddlDocks" runat="server" AutoPostBack="True" 
                        DataSourceID="ObjectDataSource1" DataTextField="Name" 
                        DataValueField="DockID" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="Ch09Cart.Models.DockDB"></asp:ObjectDataSource>
                    <br />
                </div>
            </div>   
        </div>
    </div><%-- end of row 2 --%>
    <div class="row"><%-- end of row 2 --%>
        <div class="col-sm-12">
            <div class="form-group">
                &nbsp;<div class="col-sm-3">
                    <%-- end of row 2 --%>
                    <asp:GridView ID="SlipGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="LinqDataSourceSlip" OnSelectedIndexChanged="SlipGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="Width" HeaderText="Width" ReadOnly="True" SortExpression="Width" />
                            <asp:BoundField DataField="Length" HeaderText="Length" ReadOnly="True" SortExpression="Length" />
                            <asp:BoundField DataField="DockID" HeaderText="DockID" ReadOnly="True" SortExpression="DockID" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSourceSlip" runat="server" ContextTypeName="Ch09Cart.SlipDataContext" EntityTypeName="" Select="new (ID, Width, Length, DockID)" TableName="Slips" Where="DockID == @DockID">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="ddlDocks" Name="DockID" PropertyName="SelectedValue" Type="Int32" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                </div>
                <div class="col-sm-7">
                    <asp:Label ID="SlipIDLabel" runat="server" Text="Slip ID"></asp:Label>
                    <asp:TextBox ID="SlipIDTextBox" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="LeaseStatusLabel" runat="server" Text="Slip lease status" Visible="False"></asp:Label>
                    <br />
                    <asp:GridView ID="LeaseStatusGridView" runat="server" Visible="False">
                    </asp:GridView>
                    <br />
                    </div>
            
                <br />
                <br />
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <asp:Button ID="LeaseBtn" runat="server" Text="Lease" 
                        onclick="LeaseBtn_Click" CssClass="btn" />
                    <asp:Button ID="btnCart" runat="server" Text="Go to Cart" 
                        PostBackUrl="~/Cart.aspx" CausesValidation="False" CssClass="btn" />
                </div>
            </div>
        </div>
    </div><%-- end of row 2 --%>
</asp:Content>
<asp:Content ID="footerContent" runat="server" contentplaceholderid="footerPlaceHolder">
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="headPlaceholder">
</asp:Content>

