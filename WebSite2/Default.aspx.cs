using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebSite2;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        DataSet ds = new DataSet();
        ds = SqlHelper.ExecuteDataset(connStr, System.Data.CommandType.Text, "SELECT TOP 1 * FROM AspNetRoles WHERE Id=" + "1");

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            lbl.Text = row["Name"].ToString();

        }

        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
    }
}