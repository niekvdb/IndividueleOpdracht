using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht
{
    public partial class Producten : System.Web.UI.Page
    {

        private DatabaseMng mng = new DatabaseMng();
        private List<Product> products = new List<Product>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Btn_PlaatsVraag.Enabled = true;
                Btn_Review.Enabled = true;
                LoginMenu.Text = "Logout";
                RegMenu.Visible = false;
            }
        }
        protected void btn_AddItem_Click(object sender, EventArgs e)
        {
            products = mng.GetAlleProducten();
            if (lbox_Rentables.SelectedItem == null)
            {
                string error = "SELECTEER IETS";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
                return;
            }

            if (txt_Chosen1.Text == "")
            {
                string item = Convert.ToString(lbox_Rentables.SelectedItem);
                string naam = item.Substring(6, 12);
                foreach (Product p in products)
                {
                    if (p.Naam == naam)
                    {
                        Label1.Text = Convert.ToString(p.Prijs);
                        txt_Chosen1.Text =p.Naam;
                        Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
                    }
                }
            }
            else if (txt_Chosen2.Text == "")
            {
                string item = Convert.ToString(lbox_Rentables.SelectedItem);
                string naam = item.Substring(6, 12);
                foreach (Product p in products)
                {
                    if (p.Naam == naam)
                    {
                        Label2.Text = Convert.ToString(p.Prijs);
                        txt_Chosen2.Text = p.Naam;
                        Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
                    }
                }
            }
            else if (txt_Chosen3.Text == "")
            {
                string item = Convert.ToString(lbox_Rentables.SelectedItem);
                string naam = item.Substring(6, 12);
                foreach (Product p in products)
                {
                    if (p.Naam == naam)
                    {
                        Label3.Text = Convert.ToString(p.Prijs);
                        txt_Chosen3.Text = p.Naam;
                        Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
                    }
                }
            }
            else if (txt_Chosen4.Text == "")
            {
                string item = Convert.ToString(lbox_Rentables.SelectedItem);
                string naam = item.Substring(6, 12);
                foreach (Product p in products)
                {
                    if (p.Naam == naam)
                    {
                        Label4.Text = Convert.ToString(p.Prijs);
                        txt_Chosen4.Text = p.Naam;
                        Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
                    }
                }
            }
            else if (txt_Chosen5.Text == "")
            {
                string item = Convert.ToString(lbox_Rentables.SelectedItem);
                string naam = item.Substring(6, 12);
                foreach (Product p in products)
                {
                    if (p.Naam == naam)
                    {
                        Label5.Text = Convert.ToString(p.Prijs);
                        txt_Chosen5.Text = p.Naam;
                        Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text)+Convert.ToInt32(Label5.Text));
                    }
                }
            }
        }

        protected void Remove1_Click(object sender, EventArgs e)
        {
            txt_Chosen1.Text = "";
            Label1.Text = "0";
            Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
        }

        protected void Remove2_Click(object sender, EventArgs e)
        {
            txt_Chosen2.Text = "";
            Label2.Text = "0";
            Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
        }

        protected void Remove3_Click(object sender, EventArgs e)
        {
            txt_Chosen3.Text = "";
            Label3.Text = "0";
            Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
        }

        protected void Remove4_Click(object sender, EventArgs e)
        {
            txt_Chosen4.Text = "";
            Label4.Text = "0";
            Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text));
        }

        protected void Remove5_Click(object sender, EventArgs e)
        {
            txt_Chosen5.Text = "";
            Label5.Text = "0";
            Totaal.Text = Convert.ToString(Convert.ToInt32(Label1.Text) + Convert.ToInt32(Label2.Text) + Convert.ToInt32(Label3.Text) + Convert.ToInt32(Label4.Text)+Convert.ToInt32(Label5.Text));
        }

        protected void btn_Finish_Click(object sender, EventArgs e)
        {

        }


        protected void btn_ShowINfo_Click(object sender, EventArgs e)
        {
            if (lbox_Rentables.SelectedItem == null)
            {
                string error = "SELECTEER IETS";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
                return;
            }
            string selected = lbox_Rentables.SelectedItem.ToString();
            string naam = selected.Substring(6, 12);
            Product x = mng.GetProduct(naam);
            LaatProductzien(x);
        }
        public void Refresh()
        {
            products = mng.GetAlleProducten();
            lbox_Rentables.Items.Clear();
            foreach (Product product in products)
            {
                lbox_Rentables.Items.Add(product.ToString());
            }
        }

        protected void btn_Refresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        protected void Btn_Review_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                int score;
                if (!Int32.TryParse(Tbox_Review_score.Text, out score))
                {
                    string error = "VOER EEN NUMMER IN";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
                }
                else
                {
                    string selected = TextBox1.Text;
                    string naam = selected.Substring(6, 12);
                    Product product = mng.GetProduct(naam);
                    Review rev = new Review(DateTime.Now, Tbox_Review_Reactie.Text, Tbox_Review_titel.Text, Convert.ToInt32(Tbox_Review_score.Text));
                    mng.AddReview(1, product.Naam, rev.Titel, rev.Datum, rev.Tekst, rev.Score);
                    LaatProductzien(product);                  
                }
            }
            else
            {
                string error = "Kies een Product";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
            }

        }

        protected void Btn_PlaatsVraag_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                string selected = TextBox1.Text;
                string naam = selected.Substring(6, 12);
                Product product = mng.GetProduct(naam);
                Vraag vra = new Vraag(DateTime.Now, Tbox_Vraag_Vraag.Text, Tbox_Vraag_titel.Text);
                mng.AddVraag(1, product.Naam, vra.Tekst, vra.Datum, vra.Titel);
                LaatProductzien(product);
            }
            else
            {
                string error = "Kies een Product";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
            }
        }

        protected void Btn_Zoek_Click(object sender, EventArgs e)
        {
            Product product = mng.GetProduct(TextBox2.Text);
           if( product!=null)
           {
               LaatProductzien(product);              
           }
           else
           {
               string error = "PRODUCT NIET GEVONDEN";
               ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
           }
        }
        public void LaatProductzien(Product product)
        {
            List<Vraag> vragen = mng.GetVraag(product.Naam);
            List<Review> reviews = mng.GetReview(product.Naam);
            if (reviews != null)
            {
                TextBox1.Text = product.ToString();
                foreach (Review rev in reviews)
                {
                    TextBox1.Text = TextBox1.Text + rev.ToString();
                }
                if (vragen != null)
                {
                    foreach (Vraag vra in vragen)
                    {
                        TextBox1.Text = TextBox1.Text + vra.ToString();
                    }
                }
            }
            else
            {
                TextBox1.Text = product.ToString();
                if (vragen != null)
                {
                    foreach (Vraag vra in vragen)
                    {
                        TextBox1.Text = TextBox1.Text + vra.ToString();
                    }
                }
            }
        }
    }
}