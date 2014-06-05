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
    public partial class Login : System.Web.UI.Page
    {
        private DatabaseMng mng = new DatabaseMng();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                LoginMenu.Text = "Logout";
                FormsAuthentication.SignOut();
                Response.Redirect(FormsAuthentication.DefaultUrl); 
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
           
                if (tb_voornaam.Text != "" || tb_pw.Text != "")
                {
                    Gebruiker per1 = mng.GetGebruiker(tb_voornaam.Text);
                    if (per1 != null)
                    {
                        if (per1.Wachtwoord == tb_pw.Text)
                        {
                            FormsAuthentication.RedirectFromLoginPage(this.tb_voornaam.Text, this.cb_remember.Checked);
                        }
                        else
                        {
                            this.InvalidLogin.Visible = true;
                        }
                    }
                    else
                    {
                        this.InvalidLogin.Visible = true;
                    }
                }
                else
                {
                    this.InvalidLogin.Visible = true;
                }



            }
        }
    }
}