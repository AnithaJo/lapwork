using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HacathonApp
{
    public partial class BookingDetails : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string timing = Server.UrlDecode(Request.QueryString["timing"]);
            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            string price= Server.UrlDecode(Request.QueryString["price"]);
            Label2.Text = mname;
            Label3.Text = tname;
            Label4.Text = timing;
            Label6.Text = price;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string display = "Payment Succeeded!";
            ClientScript.RegisterStartupScript(GetType(), "Payment Succeeded", "alert('" + display + "');", true);
        }
    }
}