using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using RabbitMQ.Client;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Security.Policy;
using System.Net;
using System.Xml.Linq;

namespace RabbitMQWebApp
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        

              protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {
            TextBox1.Visible = true;

            // string ss =TextBox1.ToString();
            string ss = TextBox1.Text;
            string ss1 = "producer";
            string ss2 = "consumer";
            if (ss.Equals(ss1))
            {
                //Server.Transfer("WebRMQ.aspx");
                Response.Redirect("WebRMQ.aspx");

            }

            else if (ss.Equals(ss2))
            {
                //Server.Transfer("WebRMQConsumer.aspx");
                Response.Redirect("WebRMQConsumer.aspx");

            }
            else
            {
                MessageBox.Show("SELECT VALID OPTION");
            }
        }

       
    }
}