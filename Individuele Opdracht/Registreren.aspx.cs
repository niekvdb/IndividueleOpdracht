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
    public partial class Registreren : System.Web.UI.Page
    {
        private DatabaseMng mng = new DatabaseMng();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                LoginMenu.Text = "Logout";
                Response.Redirect("Default.aspx");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                if (mng.BestaatGebruiker(tb_voornaam.Text))
                {
                    string error = "gebruiker bestaat al";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
                    
               }
                else
                {
                    if(mng.MaakGebruiker(tb_voornaam.Text, tb_pw.Text))
                    {
                        Response.Redirect("login.aspx");
                    
                    }
                    
                }
            }
        }
    }
}