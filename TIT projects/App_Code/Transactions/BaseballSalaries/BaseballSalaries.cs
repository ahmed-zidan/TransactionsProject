using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// used as a table reference to database table called BaseballSalaries
/// </summary>
public class BaseballSalaries
{
    
    public int Id { get; set; }
    public string Player { get; set; }

    public string Team { get; set; }
    public string Position { get; set; }
    public string Salary { get; set; }

}