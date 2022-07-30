<%@ Page Title="Log" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="Log" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <section class="loginContents">
        <div class="container ">
            
            <div class="row">
                
                <div class="col-md-3">
                    <asp:TextBox placeholder="Username" ID="txtUsername" CssClass="txtLogIn" runat ="server"></asp:TextBox>
                </div>

            </div>

            <div class="row">
               
                <div class="col-md-3">    
                <asp:TextBox type ="password" placeholder="Password" ID="txtPasword" CssClass="txtLogIn" runat ="server"></asp:TextBox>
                </div>


            </div>

            <div class="row">
                <asp:Button Text="Login" ID="btnLogIn" CssClass="btn btn-success" runat="server" OnClick="btnLogIn_Click" />
            </div>

        </div>




    </section>



    

</asp:Content>