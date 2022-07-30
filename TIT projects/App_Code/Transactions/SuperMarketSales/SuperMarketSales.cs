using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// properties of table SuperMarketSales
/// </summary>
public class SuperMarketSales
{

    public string Invoice_ID { get; set; } //primary key
    public string Branch { get; set; }
    public string City { get; set; }
    public string Customer_Type { get; set; }
    public string Gender { get; set; }
    public string Product_Line { get; set; }
    public double Unit_Price { get; set; }
    public int Quantity { get; set; }
    public double Tax_5 { get; set; }
    public double Total { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Payment { get; set; }
    public double Cogs { get; set; }
    public double Gross_Margin_Percentage { get; set; }
    public double Gross_Income { get; set; }
    public double Rating { get; set; }

}
