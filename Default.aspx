<%@ Page Title="Home" MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Opdracht1.Default" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <asp:GridView ID="personeelslijst" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Geslacht" HeaderText="Geslacht" />
            <asp:BoundField DataField="Voornaam" HeaderText="Voornaam" />
            <asp:BoundField DataField="Achternaam" HeaderText="Achternaam" />
            <asp:BoundField DataField="Geboren" HeaderText="Geboren" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="EditPersoneel.aspx?ID={0}" Text="Wijzigen" HeaderText="Wijzigen"/>
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="DeletePersoneel.aspx?ID={0}" Text="Verwijderen" HeaderText="Verwijderen"/>
        </Columns>
    </asp:GridView>

    <p>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="NieuwPersoneel.aspx" runat="server">Nieuw Personeel</asp:HyperLink>
    </p>
</asp:Content>