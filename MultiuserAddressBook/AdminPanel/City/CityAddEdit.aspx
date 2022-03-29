<%@ Page Title="" Language="C#" MasterPageFile="~/MultiuserAddressBook/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="MultiuserAddressBook_AdminPanel_City_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City Add Edit Page</h2>
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
                    State
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control"></asp:DropDownList><br />
                </div>
                <div class="col-md-4">
                    City Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    STD Code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    Pin Code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" /><br />
                </div>
                <%--<div class="col-md-4">
                    Creation Date
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCreationDate" CssClass="form-control" /><br />
                </div>--%>
                <div class="col-md-4">
                    
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click" />
                </div>
                </div>
            </div>
        </div>
</asp:Content>

