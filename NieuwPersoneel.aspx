<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NieuwPersoneel.aspx.cs" Inherits="Opdracht1.NieuwPersoneel" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">

    <p>
        <asp:RadioButtonList ID="Geslacht" runat="server">
            <asp:ListItem Value="M">Man</asp:ListItem>
            <asp:ListItem Value="V">Vrouw</asp:ListItem>
        </asp:RadioButtonList>
    </p>

    <p>
        <asp:Label ID="LabelVoornaam" runat="server" Text="Voornaam"></asp:Label>
        <asp:TextBox ID="TextBoxVoornaam" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="LabelAchternaam" runat="server" Text="Achternaam"></asp:Label>
        <asp:TextBox ID="TextBoxAchternaam" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="LabelGeboren" runat="server" Text="Geboren"></asp:Label>
        <asp:Calendar ID="CalendarGeboren" runat="server"></asp:Calendar>
    </p>

    <p>
        <asp:Button ID="Button1" runat="server" Text="Toevoegen"  OnClick="Button1_Click" />
    </p>

</asp:Content>