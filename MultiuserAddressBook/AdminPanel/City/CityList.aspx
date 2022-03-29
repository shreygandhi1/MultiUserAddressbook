<%@ Page Title="" Language="C#" MasterPageFile="~/MultiuserAddressBook/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="MultiuserAddressBook_AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMessage" runat="server" EnableViewState ="false"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div>
                <asp:HyperLink runat="server" ID="hlAddCity" Text="Add New City" CssClass="btn btn-dark" NavigateUrl="~/MultiuserAddressBook/Adminpanel/City/CityAddEdit.aspx" />
            </div>
            </div>
        </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gvCity" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" OnRowCommand="gvCity_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("CityID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%#"~/MultiuserAddressBook/Adminpanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID".ToString().Trim())%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CityID" HeaderText="CityID" />
                    <asp:BoundField DataField="StateID" HeaderText="StateID" />
                    <asp:BoundField DataField="CityName" HeaderText="Name" />
                    <asp:BoundField DataField ="STDCode" HeaderText="Code" />
                    <asp:BoundField DataField="PinCode" HeaderText="PinCode" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Date" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

