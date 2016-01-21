<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Coursework1.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Use the form below to create a new account.</h2>
    </hgroup>

      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RPSLSConnectionString1 %>" SelectCommand="SELECT * FROM [LogInEntry]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
      <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
      <asp:Label runat="server" AssociatedControlID="Username">Username</asp:Label>
      <asp:TextBox runat="server" ID="Username" />
      <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
      
      <asp:Label runat="server" AssociatedControlID="DOB">Date Of Birth (MM/DD/YYYY)</asp:Label>
      <asp:TextBox runat="server" ID="DOB" />
      <asp:RegularExpressionValidator ID="format" runat="server" ErrorMessage="This expression does not validate."  ControlToValidate="DOB" ValidationExpression="^(0?[1-9]|1[012])[\/](0?[1-9]|[12][0-9]|3[01])[\/]\d{4}$" />
      <asp:RequiredFieldValidator runat="server" ControlToValidate="DOB" CssClass="field-validation-error" ErrorMessage="The Date Of Birth field is required." />
      <asp:Button runat="server" CommandName="MoveNext" Text="Register" OnClick="Register_Click" />

    <br />

</asp:Content>