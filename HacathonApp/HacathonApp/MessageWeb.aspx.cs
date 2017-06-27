using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HacathonApp
{
    public partial class MessageWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           Label1.Text = (Server.UrlDecode(Request.QueryString["selected"]));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pg = "Payment Succeeded";
            string price = Label1.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup",
               string.Format("ShowPopup('{0}');", pg), true);
            int i = int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));
            string timing = Server.UrlDecode(Request.QueryString["timing"]);
            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            Response.Redirect(String.Format("BookingDetails.aspx?num_of={0}&timing={1}&moviename={2}&theatrename={3}&price={4}", Server.UrlEncode(i.ToString()), Server.UrlEncode(timing), Server.UrlEncode(mname), Server.UrlEncode(tname), Server.UrlEncode(price)));
            //Response.Redirect(String.Format("BookingDetails.aspx?price={0}", Server.UrlEncode(price)));

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatsLayout.aspx");
        }
    }
}