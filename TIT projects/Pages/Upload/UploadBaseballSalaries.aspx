<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UploadBaseballSalaries.aspx.cs" Inherits="Pages_Upload_UploadBaseballSalaries" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="BaseballSalaries">
        <div class="contents">
            <h4 class="title">Upload Baseball Salaries</h4>
            
            
            <div class="fileName">
                <p>File Name : </p>
                <asp:Label Text=" No File Selected" ForeColor="Red" runat="server" ID="lblFileName"></asp:Label>
            </div>

            <asp:Panel Visible="false" ID="pnlGridView" CssClass="pnlGridView" runat="server" ScrollBars="Both">
                <asp:GridView ID="grBaseball" CssClass="grBaseball" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">


                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />


                </asp:GridView>

            </asp:Panel>
            
            <div class="btns">
                <asp:Button text="Upload" ID="btnUpload" CssClass="myBtn btn btn-success" runat="server" OnClick="btnUpload_Click" />
                <asp:Button Text="Execute" ID="Button1" CssClass="myBtn btn btn-success" runat="server" />

            </div>


        </div>


        <div id="UploadBaseballSalaryPopUp" class="UploadBaseballSalaryPopUp">
            <div class="closeBtnContainer">
            <%--<asp:Button Text="&times;" id="closeBtn" class="closeBtn" runat="server"/>--%>
            <Button  id="Button2" class="closeBtn">&times;</Button>
            </div>
            
            <div class="selectExcel">
                <asp:FileUpload ID="flUpload" CssClass="flUpload" runat="server" BorderStyle="Double" Font-Overline="False" Font-Strikeout="False" />
                <asp:Button ID="btnShowSheets" text="Show Sheets" CssClass="show btn btn-success" runat="server" OnClick="btnShowSheets_Click" EnableTheming="True" />
            </div>
            <div class="ddlSheetsContainer">
                <asp:DropDownList  ID="ddlSheets"  CssClass="ddlSheets" runat="server"></asp:DropDownList>
            </div>

            <div class="showContainer">
            <asp:Button ID="btnSelect" Text="Select" CssClass="show btn btn-success" runat="server" OnClientClick="select_button" OnClick="select_button" />
            </div>
            
        </div>

        <div Id="overlay" ></div>

        

        



    </section>
    

</asp:Content>