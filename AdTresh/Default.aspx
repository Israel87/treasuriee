<%@ Page Title="treasuriee" Language="C#" MasterPageFile="~/Landing.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdTresh._Default" %>

     
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="logo">  
                <div class="font-icon-detail" style="font-size: 35px; color:white">
                    <i class="pe-7s-graph3" style="color: black; font-weight:900"></i><p style="margin-top: -20px"> treasuriee </p>
                </div>
            </div>
  

   <%-- <label for="inputEmail" class="sr-only">Email address</label>
    <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus runat="server"><br />--%>
    <label for="inputPassword" class="sr-only">Password</label>
    <input type="password" id="inputPassword" class="form-control text-center" placeholder="Enter Password" required runat="server">
      

    <div class="checkbox mb-3">
        <label>
            <input type="checkbox" value="remember-me">
            Remember me
   
        </label>

    </div>
<%--    <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Button" />--%>
    <asp:LinkButton CssClass="btn btn-info btn-block" ID="submit" OnClick="submit_Click" runat="server"><strong>Sign in</strong></asp:LinkButton>

    <%--<button class="btn btn-lg btn-info btn-block" type="submit" runat="server" onclick="btnLogin_Click()">Sign in</button>--%>
    <p class="mt-5 mb-3 text-muted">&copy; <script>document.write(new Date().getFullYear())</script> </p>
               
</asp:Content>

