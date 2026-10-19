<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebErrorsApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Tile Calculator</h1>
            <h2>Standard Tiles</h2>
            <p>Room size 20 meteres square</p>
            <p>What size of tile will you use: Width <asp:TextBox ID="Width" runat="server" Height="25px" Width="76px"></asp:TextBox>
&nbsp;X Length
                <asp:TextBox ID="Length" runat="server" Width="73px" Height="25px"></asp:TextBox>
            &nbsp;
                <asp:Label ID="ErrorLabel" runat="server" Text="ErrorLabel" ForeColor="Red" Visible="False"></asp:Label>
            </p>
            <p>You would need this many of those tiles:
                <asp:Label ID="Quantity" runat="server" Text="0"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Calculate Number of Tiles" Width="220px" OnClick="Button1_Click" />
            </p>
        </section>

    </main>

</asp:Content>
