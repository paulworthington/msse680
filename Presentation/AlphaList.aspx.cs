using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Service;
using DAL;

namespace Presentation
{
    public partial class AlphaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            if (!string.IsNullOrEmpty(Request.QueryString["letter"]))
            {
                string letter = Request.QueryString["letter"];
                contentLabel.Text = "You selected the letter <strong>" + letter + "</strong>.<br>This is where the query results will be displayed when this feature is implemented.";
            }
        }
    }
}