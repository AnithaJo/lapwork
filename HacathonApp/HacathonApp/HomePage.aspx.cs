using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HacathonApp
{
    public partial class HomePage : System.Web.UI.Page
    {

        public String CurrentTheatrename
        {
            get
            {
                return TextBox1.Text;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            DropDownList1.Items.Add("Movie");
            DropDownList1.Items.Add("Theatre");

            ImageButton4.ImageUrl = @"C:\Users\admin\Downloads\sqlandimages\images\DHOOM 420.jpg";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
        

            if(DropDownList1.Text =="Movie")
            {
                Response.Redirect("ListOfTheatre.aspx?moviename="+ Server.UrlEncode(name));
            }
           else
            {
                Response.Redirect("TheatreSelect.aspx?theatrename=" + Server.UrlEncode(name));
            }
            
          
           


        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            var movie4 = "DHOOM 420";
            Response.Redirect("ListOfTheatre.aspx?moviename=" + Server.UrlEncode(movie4));
        }
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            var movie4 = "HORRIBLE BOSSES";
            Response.Redirect("ListOfTheatre.aspx?moviename=" + Server.UrlEncode(movie4));
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            var movie4 = "KRISSH THE RETURN OF JADDU";
            Response.Redirect("ListOfTheatre.aspx?moviename=" + Server.UrlEncode(movie4));
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            var movie4 = "NEED FOR SPEED UNWANTED";
            Response.Redirect("ListOfTheatre.aspx?moviename=" + Server.UrlEncode(movie4));
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            var movie4 = "SATURDAY NIGHT AT HONEYWELL";
            Response.Redirect("ListOfTheatre.aspx?moviename=" + Server.UrlEncode(movie4));
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            var movie4 = "WONDER WOMAN";
            Response.Redirect("ListOfTheatre.aspx?moviename=" + Server.UrlEncode(movie4));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}