﻿using System;
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
                LoginMenu.Text = "Logout";
                RegMenu.Visible = false;
            }
        }
        protected void btn_AddItem_Click(object sender, EventArgs e)
        {
            if (lbox_Rentables.SelectedItem == null)
            {
                string error = "SELECTEER IETS";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + error + "');", true);
                return;
            }

            if (txt_Chosen1.Text == "")
            {
                txt_Chosen1.Text = Convert.ToString(lbox_Rentables.SelectedItem);
            }
            else if (txt_Chosen2.Text == "")
            {
                txt_Chosen2.Text = Convert.ToString(lbox_Rentables.SelectedItem);
            }
            else if (txt_Chosen3.Text == "")
            {
                txt_Chosen3.Text = Convert.ToString(lbox_Rentables.SelectedItem);
            }
            else if (txt_Chosen4.Text == "")
            {
                txt_Chosen4.Text = Convert.ToString(lbox_Rentables.SelectedItem);
            }
            else if (txt_Chosen5.Text == "")
            {
                txt_Chosen5.Text = Convert.ToString(lbox_Rentables.SelectedItem);
            }
        }

        protected void Remove1_Click(object sender, EventArgs e)
        {
            txt_Chosen1.Text = "";
            Label1.Text = "€";
        }

        protected void Remove2_Click(object sender, EventArgs e)
        {
            txt_Chosen2.Text = "";
            Label2.Text = "€";
        }

        protected void Remove3_Click(object sender, EventArgs e)
        {
            txt_Chosen3.Text = "";
            Label3.Text = "€";
        }

        protected void Remove4_Click(object sender, EventArgs e)
        {
            txt_Chosen4.Text = "";
            Label4.Text = "€";
        }

        protected void Remove5_Click(object sender, EventArgs e)
        {
            txt_Chosen5.Text = "";
            Label5.Text = "€";
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
            List<Review> reviews = mng.GetReview(x.Naam);
            if (reviews != null)
            {
                TextBox1.Text = x.ToString();
                foreach (Review rev in reviews)
                {
                    TextBox1.Text = TextBox1.Text + rev.ToString();
                }
            }
            else
            {
                TextBox1.Text = x.ToString();
            }
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

        }

        protected void Btn_PlaatsVraag_Click(object sender, EventArgs e)
        {

        }
  
    }
}