<%@ Page Title="Upload Super market sales" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/Pages/Upload/UploadSuperMarketSales.aspx.cs" Inherits="Pages_Upload_UploadSuperMarketSales" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-MarketSales">
        <h1>Super Market Sales</h1>
        
        <div class="MarketUploadContent">
           <div class="uploadBtn">

           <asp:FileUpload ID="FileUpload1"    runat="server"  BackColor="green" Width="333px" Font-Size="Large"  />
           <asp:Button ID="btnShow" text="show Sheets" CssClass="show btn btn-success" runat="server" OnClick="btnShow_Click" />
           <asp:DropDownList ID="ddlUpload" CssClass="ddlUpload" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUpload_SelectedIndexChanged" Font-Size="20px"></asp:DropDownList>
            
           </div>
            <div class="maketSalesContent">
                <asp:Panel runat="server" ScrollBars="Auto">
                    <asp:label ID="lblFiirstTenRows" CssClass="lblFiirstTenRows" runat="server"></asp:label>
                    <asp:GridView ID="grMarket" runat="server" BackColor="White"  BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="True" Font-Size="12px">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>

                   <asp:Button ID="btnUploadData" visible ="false" CssClass="show btn btn-success" text ="Upload File" runat="server" OnClick="btnUploadData_Click" />

                 </asp:Panel>

               

            </div>

        </div>

    </section>




</asp:Content>