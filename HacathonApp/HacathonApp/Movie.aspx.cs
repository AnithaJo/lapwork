using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HacathonApp
{
    public partial class Movie : System.Web.UI.Page
    {
        string timing = "";
        string numberofseats = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            Label1.Text = mname;
            Label3.Text = tname;
            DropDownList1.Items.Add("1");
            DropDownList1.Items.Add("2");
            DropDownList1.Items.Add("3");
            DropDownList1.Items.Add("4");
            DropDownList1.Items.Add("5");
            DropDownList1.Items.Add("6");
            DropDownList1.Items.Add("7");
            DropDownList1.Items.Add("8");
            DropDownList1.Items.Add("9");
            DropDownList1.Items.Add("10");
            DropDownList1.Items.Add("11");
            DropDownList1.Items.Add("12");
            DropDownList1.Items.Add("13");
            DropDownList1.Items.Add("14");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            int i = int.Parse(DropDownList1.SelectedValue);
            Response.Redirect(String.Format("SeatsLayout.aspx?num_of={0}&timing={1}&moviename={2}&theatrename={3}", Server.UrlEncode(i.ToString()), Server.UrlEncode(timing), Server.UrlEncode(mname), Server.UrlEncode(tname)));
            //Response.Redirect("SeatsLayout.aspx?selected=" + Server.UrlEncode(i.ToString()));
                
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");

        }

       
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
             timing = RadioButtonList1.SelectedValue;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberofseats = DropDownList1.SelectedValue;
        }
    }
}