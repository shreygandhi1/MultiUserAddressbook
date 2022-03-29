<%@ Page Title="" Language="C#" MasterPageFile="~/MultiuserAddressBook/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="MultiuserAddressBook_AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact List</h2>
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
                <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" CssClass="btn btn-dark" NavigateUrl="~/MultiuserAddressBook/Adminpanel/Contact/ContactAddEdit.aspx" />
            </div>
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" OnRowCommand="gvContact_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("ContactID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%#"~/MultiuserAddressBook/Adminpanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID".ToString().Trim()) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                    <asp:BoundField DataField="CountryID" HeaderText="CountryID" />
                     <asp:BoundField DataField="StateID" HeaderText="StateID" />
                     <asp:BoundField DataField="CityID" HeaderText="CityID" />
                     <asp:BoundField DataField="ContactCategoryID" HeaderText="ContactCategoryID" />
                     <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                     <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                     <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo" />
                     <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
                     <asp:BoundField DataField="Email" HeaderText="Email" />
                     <asp:BoundField DataField="Age" HeaderText="Age"  />
                     <asp:BoundField DataField="Address" HeaderText="Address" />
                     <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                     <asp:BoundField DataField="FaceBookID" HeaderText="FaceBookID" />
                     <asp:BoundField DataField="LinkedINID" HeaderText="LinkedINID" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Date" />

                     
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgContactPhotoPath" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
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

