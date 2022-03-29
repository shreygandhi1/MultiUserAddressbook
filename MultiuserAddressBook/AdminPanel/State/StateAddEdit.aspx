<%@ Page Title="" Language="C#" MasterPageFile="~/MultiuserAddressBook/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="MultiuserAddressBook_AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2>State Add Edit Page</h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblmessage" EnableViewState="false" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    Country
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-select"></asp:DropDownList>
                </div><br />
                <div class="col-md-4">
                    State Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control" />
                </div>
                <br />
                <div class="col-md-4">
                    State code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control" />
                </div>
                <br />
                <%--<div class="col-md-4">
                    Creation Date
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCreationDate" CssClass="form-control" />
                </div>--%>
                <div class="col-md-4">
                    
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

