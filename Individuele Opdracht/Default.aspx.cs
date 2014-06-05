using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Configuration;
using System.Configuration;

namespace Individuele_Opdracht
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                LoginMenu.Text = "Logout";
                RegMenu.Visible = false;
            }
        }
    }
}