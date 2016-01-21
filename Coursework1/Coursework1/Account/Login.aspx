<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Coursework1.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <section id="loginForm">
        <h2>Use a local account to log in.</h2>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RPSLSConnectionString1 %>" SelectCommand="SELECT * FROM [LogInEntry] WHERE (([Username] = @Username) AND ([DOB] = @DOB))">
            <SelectParameters>
                <asp:ControlParameter ControlID="Username" Name="Username" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DOB" Name="DOB" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
                            
         <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
                            
         <asp:Label runat="server" AssociatedControlID="UserName">UserName</asp:Label>
         <asp:TextBox runat="server" ID="Username" />
         <asp:RequiredFieldValidator runat="server" ControlToValidate="Username" CssClass="field-validation-error" ErrorMessage="The user name field is required." />

         <asp:Label runat="server" AssociatedControlID="DOB">Date Of Birth (MM/DD/YYYY)</asp:Label>
         <asp:TextBox runat="server" ID="DOB" />
         <asp:RegularExpressionValidator ID="format" runat="server" ErrorMessage="This is not a valid format"  ControlToValidate="DOB" ValidationExpression="^(0?[1-9]|1[012])[\/](0?[1-9]|[12][0-9]|3[01])[\/]\d{4}$" />
         <asp:RequiredFieldValidator runat="server" ControlToValidate="DOB" CssClass="field-validation-error" ErrorMessage="The Date of Birth field is required." />

         <asp:CheckBox runat="server" ID="RememberMe" />
         <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
         <br />
         <asp:Button runat="server" CommandName="Login" Text="Log in" OnClick="LogIn_Click" />
       
         <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>
</asp:Content>
