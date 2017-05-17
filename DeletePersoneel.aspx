<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeletePersoneel.aspx.cs" Inherits="Opdracht1.DeletePersoneel" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">

    <p>
        Wilt u dit lid verwijderen?
    </p>


    <asp:Button ID="Button1" runat="server" Text="Ja"  OnClick="Button1_Click" />
     &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Nee"  OnClick="Button2_Click" />

</asp:Content>