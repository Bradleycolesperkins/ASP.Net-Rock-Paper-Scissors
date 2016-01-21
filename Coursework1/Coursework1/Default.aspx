<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Coursework1._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><asp:Label ID="title" runat="server" Text=""></asp:Label></h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <asp:Panel ID="Selections" runat="server">
    <asp:Button ID="RockButton" runat="server" Text="Rock" OnClick="RockButton_Click" />
    <asp:Button ID="PaperButton" runat="server" Text="Paper" OnClick="PaperButton_Click" />
    <asp:Button ID="ScissorsButton" runat="server" Text="Scissors" OnClick="ScissorsButton_Click" />
    <asp:Button ID="LizardButton" runat="server" Text="Lizard" OnClick="LizardButton_Click" />
    <asp:Button ID="SpockButton" runat="server" Text="Spock" OnClick="SpockButton_Click" />
    <br />
    <h2><asp:Button ID="ContinueToPlay" runat="server" Text="Press here to play again" OnClick="ContinueToPlay_Click"></asp:Button>
        <asp:Button ID="Logout" runat="server" Text="Press here to Log Out" OnClick="Logout_Click"></asp:Button>
    </h2>
    <h2><asp:Label ID="Result" runat="server" Text="Result: "></asp:Label></h2>
    <br />
    <h3><asp:Label ID="Username" runat="server" Text=""></asp:Label>
    &nbsp;Selected :&nbsp;
    <asp:Label ID="ButtonSelected" runat="server" Text=""></asp:Label></h3>
    <br />
    <h3>Computer Selected: &nbsp;<asp:Label ID="ComputerSelected" runat="server" Text=""></asp:Label></h3>
    </asp:Panel>
    <br /><asp:Panel ID="Stats" runat="server">
    <h2>Statistics</h2>
    <h3>Wins: <asp:Label ID="Wins" runat="server" Text="0"></asp:Label></h3>
    <h3>Ties: <asp:Label ID="Ties" runat="server" Text="0"></asp:Label></h3>
    <h3>Losses: <asp:Label ID="Losses" runat="server" Text="0"></asp:Label></h3>
    <h3>Total Played: <asp:Label ID="total" runat="server" Text="0"></asp:Label></h3>
    </asp:Panel>


</asp:Content>
