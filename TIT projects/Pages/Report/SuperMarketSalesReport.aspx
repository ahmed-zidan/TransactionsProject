<%@ Page Title="Super Market Sales Report" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="SuperMarketSalesReport.aspx.cs" Inherits="Pages_Report_SuperMarketSalesReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="superMarketSalesReportSection">

        <div class="superMarketSalesReportContent">
            <h1 class="title">Super Market Sales Report</h1>
            <div class="options">
                <p class="Branch">Branch</p>

                <asp:DropDownList ID="ddlShow" CssClass="DDL" runat="server">
                    <asp:ListItem Selected="True">All</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>

            </div>

            <div class="reportDate">
                
                    <p class="title">From:</p>
                    <asp:TextBox ID="txtFrom" CssClass="ReportTxt" runat="server" TextMode="Date"></asp:TextBox>
            
                    <p class="title">To:</p>
                    <asp:TextBox ID="txtTo" CssClass="ReportTxt" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <div class="ex">
            <asp:Button ID="btnExcel" Text="Excel" CssClass="excel btn btn-success" runat="server" OnClick="btnExcel_Click" />
            </div>
        </div>




    </section>



</asp:Content>
