using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Reflection;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;

namespace HacathonApp
{
    
    //public class seats
    //{
    //    public int clicks { get; set; }
    //    public bool blocked { get; set; }
    //}
    //public class sample
    //{
    //   public List<seats> seats { get; set; }
    //}
    public partial class SeatsLayout : System.Web.UI.Page
    {


        //string location = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json";
        static async Task bar(JObject o2, int i, int num)
        {
            var price = 300;

            if (Convert.ToInt32(o2["Seat" + i][0]["flag"]) == 0)
            {
                var flag = Convert.ToInt32(o2["Seat" + i][0]["flag"]);
                flag = 1;
                o2["Seat" + i][0]["flag"] = flag;



                File.WriteAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json", o2.ToString());

                // write JSON directly to a file
                using (StreamWriter file1 = File.CreateText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"))
                using (JsonTextWriter writer = new JsonTextWriter(file1))
                {
                    o2.WriteTo(writer);
                }
                await Task.Delay(20000);

                JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"));
                // read JSON directly from a file
                using (StreamReader file = File.OpenText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {

                    o2 = (JObject)JToken.ReadFrom(reader);
                }



                var clicks = Convert.ToInt32(o2["Seat" + i][0]["clicks"]);
                if (clicks > 1)
                {
                    price = clicks * price;
                }
                if (Convert.ToInt32(o2["Seat" + i][0]["deselected"]) != 0)
                {
                    var desel = Convert.ToInt32(o2["Seat" + i][0]["deselected"]);
                    price = (price / clicks) * (clicks - desel);
                }
                o2["Seat" + i][0]["clicks"] = 0;
                o2["Seat" + i][0]["price"] = price;
                File.WriteAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json", o2.ToString());

                // write JSON directly to a file
                using (StreamWriter file1 = File.CreateText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"))
                using (JsonTextWriter writer = new JsonTextWriter(file1))
                {
                    o2.WriteTo(writer);
                }
            }

            else
                {
                await Task.Delay(20000);
                JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"));
                // read JSON directly from a file
                using (StreamReader file = File.OpenText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {

                    o2 = (JObject)JToken.ReadFrom(reader);
                }
                if (num == Convert.ToInt32(o2["Seat" + i][0]["no.ofseats"]))
                    price = Convert.ToInt32(o2["Seat" + i][0]["price"]);

            }
            Action act = ()=> price++;
            Task a = new Task(act);
            return ;
        }
        public int matching(string j, int info)
        {
            var i = Convert.ToInt32(j);
            int num = info;
            JObject o2 = new JObject();
            JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"));
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {

                o2 = (JObject)JToken.ReadFrom(reader);
                var s = o2["Seat" + i][0]["clicks"];

                var w = Convert.ToInt32(s);
                w += 1;
                o2["Seat" + i][0]["no.ofseats"] = num;

                o2["Seat" + i][0]["clicks"] = w;
              

            }
            File.WriteAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json", o2.ToString());

            // write JSON directly to a file
            using (StreamWriter file1 = File.CreateText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file1))
            {
                o2.WriteTo(writer);
            }
           var t=bar(o2, i, num);
            JObject o3 = JObject.Parse(File.ReadAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"));
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\HacathonApp\HacathonApp\DATA.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {

                o2 = (JObject)JToken.ReadFrom(reader);
            }
           return Convert.ToInt32(o2["Seat" + i][0]["price"]);
        }


        int flag = 0;
        string seat_num = "";

        int num_of;


        public object MessageBox { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int num_of = int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));

        }

        protected void Button100_Click(object sender, EventArgs e)
        {
            int i= int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));
            string timing = Server.UrlDecode(Request.QueryString["timing"]);
            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            Response.Redirect(String.Format("BookingDeatils.aspx?num_of={0}&timing={1}&moviename={2}&theatrename={3}", Server.UrlEncode(i.ToString()), Server.UrlEncode(timing), Server.UrlEncode(mname), Server.UrlEncode(tname)));
        }


        protected void Button101_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movie.aspx");
        }


        int statusheck(int num, Button button)
        {
            int num_of = int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));

            ////button.BackColor = System.Drawing.Color.Red;
            //button.ForeColor = Color.White;
            num_of--;


            return num_of;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string j = "";
            //var price = 0;
            //var num = 1;
            int num_of = int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));


            if (num_of != 0 && Button1.BackColor != Color.Green)
            {

                Button2_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button1.BackColor == System.Drawing.Color.Green)
            {

                
                Button1.BackColor = System.Drawing.Color.Red;
                Button1.ForeColor = System.Drawing.Color.Red;
                
                num_of--;
                if (flag == 0)
                {
                    j = Button1.Text;
                    seat_num = j;
                    flag = 1;
                }
                else
                {
                    j = seat_num;
                    if (num_of == 0)
                        flag = 0;
                }
                var price = matching(j, num_of);
                var price1 = 800;
                if (price1 > price)

                {
                    price = price1; 
                   // string pg = "Prce may vary. check befor booking";
                    string display = "Prce may vary. check befor booking";
                    ClientScript.RegisterStartupScript(GetType(), "Payment Succeeded", "alert('" + display + "');", true);
                    int i = int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));
                    string timing = Server.UrlDecode(Request.QueryString["timing"]);
                    string mname = Server.UrlDecode(Request.QueryString["moviename"]);
                    string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
                    Response.Redirect(String.Format("MessageWeb.aspx?num_of={0}&timing={1}&moviename={2}&theatrename={3}&selected={4}", Server.UrlEncode(i.ToString()), Server.UrlEncode(timing), Server.UrlEncode(mname), Server.UrlEncode(tname), Server.UrlEncode(price.ToString())));
                    //Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

                }

                Button2_Click(new object(), new EventArgs());

            }

          

            //if (price1 > price)

            //{
            //    price = price1;
            //    Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            //}


        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int num_of = int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));
            string j = "";
            //var price = 0;
            //var num = 1;

            if (num_of != 0 && Button2.BackColor != Color.Green)
            {

                Button3_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button2.BackColor == System.Drawing.Color.Green)
            {


                Button2.BackColor = System.Drawing.Color.Red;
                Button2.ForeColor = System.Drawing.Color.Red;
                //Button current = (Button)sender;
                //current.ForeColor = Color.White;
             
                num_of--;
                if (flag == 0)
                {
                    j = Button2.Text;
                    seat_num = j;
                    flag = 1;
                }
                else
                {
                    j = seat_num;
                    if (num_of == 0)
                        flag = 0;
                }
                var price = matching(j, num_of);
                var price1 = 800;
                if (price1 > price)

                {
                    price = price1;
                    string pg = "Prce may vary. check befor booking";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup",
                       string.Format("ShowPopup('{0}');", pg), true);
                    Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

                }
                Button3_Click(new object(), new EventArgs());

            }

           
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

            int num_of = int.Parse(Server.UrlDecode(Request.QueryString["num_of"]));
            string j = "";
            //var price = 0;
            //var num = 1;

            if (num_of != 0 && Button3.BackColor != Color.Green)
            {

                Button4_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button3.BackColor == System.Drawing.Color.Green)
            {


                Button3.BackColor = System.Drawing.Color.Red;
                Button3.ForeColor = System.Drawing.Color.Red;
                //Button current = (Button)sender;
                //current.ForeColor = Color.Red;
                if (Button3 != null)
                    Button3.BackColor = SystemColors.Control;
                num_of--;
                if (flag == 0)
                {
                    j = Button3.Text;
                    seat_num = j;
                    flag = 1;
                }
                else
                {
                    j = seat_num;
                    if (num_of == 0)
                        flag = 0;
                }
                var price = matching(j, num_of);
                var price1 = 800;
                if (price1 > price)

                {
                    price = price1;
                    string pg = "Prce may vary. check befor booking";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup",
                       string.Format("ShowPopup('{0}');", pg), true);
                    Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

                }
                Button4_Click(new object(), new EventArgs());

            }


        


    }
        protected void Button4_Click(object sender, EventArgs e)
        {
            var num = 4;
            var info = statusheck(num, Button2);

            var j = Button4.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button4.BackColor != Color.Green)
            {

                Button5_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button4.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button4 != null)
                    Button4.BackColor = SystemColors.Control;
                num_of--;

                Button5_Click(new object(), new EventArgs());

            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button5.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button5.BackColor != Color.Green)
            {

                Button6_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button5.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button5 != null)
                    Button5.BackColor = SystemColors.Control;
                num_of--;

                Button6_Click(new object(), new EventArgs());

            }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button6.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button6.BackColor != Color.Green)
            {

                Button7_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button6.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button6 != null)
                    Button6.BackColor = SystemColors.Control;
                num_of--;

                Button7_Click(new object(), new EventArgs());

            }
        }
        protected void Button7_Click(object sender, EventArgs e)

        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button7.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button7.BackColor != Color.Green)
            {

                Button8_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button7.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button7 != null)
                    Button7.BackColor = SystemColors.Control;
                num_of--;

                Button8_Click(new object(), new EventArgs());

            }

        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button8.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button8.BackColor != Color.Green)
            {

                Button10_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button8.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button8 != null)
                    Button8.BackColor = SystemColors.Control;
                num_of--;

                Button10_Click(new object(), new EventArgs());

            }
        }


        protected void Button10_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button10.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button10.BackColor != Color.Green)
            {

                Button11_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button10.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button10 != null)
                    Button10.BackColor = SystemColors.Control;
                num_of--;

                Button11_Click(new object(), new EventArgs());

            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button11.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button11.BackColor != Color.Green)
            {

                Button12_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button11.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button11 != null)
                    Button11.BackColor = SystemColors.Control;
                num_of--;

                Button12_Click(new object(), new EventArgs());

            }
        }


        protected void Button12_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button12.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button12.BackColor != Color.Green)
            {

                Button13_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button12.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button12 != null)
                    Button12.BackColor = SystemColors.Control;
                num_of--;

                Button13_Click(new object(), new EventArgs());

            }
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button13.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button13.BackColor != Color.Green)
            {

                Button14_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button13.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button13 != null)
                    Button13.BackColor = SystemColors.Control;
                num_of--;

                Button14_Click(new object(), new EventArgs());

            }
        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button14.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button14.BackColor != Color.Green)
            {

                Button15_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button14.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button14 != null)
                    Button14.BackColor = SystemColors.Control;
                num_of--;

                Button15_Click(new object(), new EventArgs());

            }
        }
        protected void Button15_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button15.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button15.BackColor != Color.Green)
            {

                Button16_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button15.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button15 != null)
                    Button15.BackColor = SystemColors.Control;
                num_of--;

                Button16_Click(new object(), new EventArgs());

            }
        }
        protected void Button16_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button16.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button16.BackColor != Color.Green)
            {

                Button17_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button16.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button16 != null)
                    Button16.BackColor = SystemColors.Control;
                num_of--;

                Button17_Click(new object(), new EventArgs());

            }
        }
        protected void Button17_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button17.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button17.BackColor != Color.Green)
            {

                Button18_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button17.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button17 != null)
                    Button17.BackColor = SystemColors.Control;
                num_of--;

                Button18_Click(new object(), new EventArgs());

            }
        }
        protected void Button18_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button18.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button18.BackColor != Color.Green)
            {

                Button19_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button18.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button18 != null)
                    Button18.BackColor = SystemColors.Control;
                num_of--;

                Button19_Click(new object(), new EventArgs());

            }

        }
        protected void Button19_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button19.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button19.BackColor != Color.Green)
            {

                Button20_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button19.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button19 != null)
                    Button19.BackColor = SystemColors.Control;
                num_of--;

                Button20_Click(new object(), new EventArgs());

            }
        }
        protected void Button20_Click(object sender, EventArgs e)
        {
            var num = 3;
            var info = statusheck(num, Button2);

            var j = Button20.Text;
            var price = matching(j, info);

            var price1 = 800;

            if (price1 > price)

            {
                price = price1;
                Response.Redirect("MessageWeb.aspx?selected=" + Server.UrlEncode(price.ToString()));

            }

            if (num_of != 0 && Button20.BackColor != Color.Green)
            {

                Button21_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button20.BackColor == System.Drawing.Color.Green)
            {

                //int nofseats = 3;
                //button.BackColor = System.Drawing.Color.Red;
                Button current = (Button)sender;
                current.ForeColor = Color.Red;
                if (Button20 != null)
                    Button20.BackColor = SystemColors.Control;
                num_of--;

                Button21_Click(new object(), new EventArgs());

            }
        }
        protected void Button21_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button21.BackColor != System.Drawing.Color.Green)
            {

                Button22_Click(new object(), new EventArgs());

            }
            if (num_of != 0 && Button21.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button21);
                Button22_Click(sender, e);

            }

        }
        protected void Button22_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button22.BackColor != System.Drawing.Color.Green)
            {

                Button23_Click(sender, e);

            }
            if (num_of != 0 && Button22.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button22);
                Button23_Click(sender, e);

            }

        }
        protected void Button23_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button23.BackColor != System.Drawing.Color.Green)
            {

                Button24_Click(sender, e);

            }
            if (num_of != 0 && Button23.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button23);
                Button24_Click(sender, e);

            }

        }
        protected void Button24_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button24.BackColor != System.Drawing.Color.Green)
            {

                Button25_Click(sender, e);

            }
            if (num_of != 0 && Button24.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button24);
                Button25_Click(sender, e);

            }
        }
        protected void Button25_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button25.BackColor != System.Drawing.Color.Green)
            {

                Button26_Click(sender, e);

            }
            if (num_of != 0 && Button25.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button25);
                Button26_Click(sender, e);

            }
        }
        protected void Button26_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button26.BackColor != System.Drawing.Color.Green)
            {

                Button27_Click(sender, e);

            }
            if (num_of != 0 && Button26.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button26);
                Button27_Click(sender, e);

            }
        }
        protected void Button27_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button27.BackColor != System.Drawing.Color.Green)
            {

                Button28_Click(sender, e);

            }
            if (num_of != 0 && Button27.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button27);
                Button28_Click(sender, e);

            }

        }
        protected void Button28_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button28.BackColor != System.Drawing.Color.Green)
            {

                Button29_Click(sender, e);

            }
            if (num_of != 0 && Button28.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button28);
                Button29_Click(sender, e);

            }

        }
        protected void Button29_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button29.BackColor != System.Drawing.Color.Green)
            {

                Button30_Click(sender, e);

            }
            if (num_of != 0 && Button29.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button29);
                Button30_Click(sender, e);

            }

        }
        protected void Button30_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button30.BackColor != System.Drawing.Color.Green)
            {

                Button32_Click(sender, e);

            }
            if (num_of != 0 && Button30.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button30);
                Button32_Click(sender, e);

            }

        }
        protected void Button32_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button32.BackColor != System.Drawing.Color.Green)
            {

                Button33_Click(sender, e);

            }
            if (num_of != 0 && Button32.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button32);
                Button33_Click(sender, e);

            }

        }

        protected void Button33_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button33.BackColor != System.Drawing.Color.Green)
            {

                Button34_Click(sender, e);

            }
            if (num_of != 0 && Button33.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button33);
                Button34_Click(sender, e);

            }

        }
        protected void Button34_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button34.BackColor != System.Drawing.Color.Green)
            {

                Button35_Click(sender, e);

            }
            if (num_of != 0 && Button34.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button34);
                Button35_Click(sender, e);

            }
        }
        protected void Button35_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button35.BackColor != System.Drawing.Color.Green)
            {

                Button36_Click(sender, e);

            }
            if (num_of != 0 && Button35.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button35);
                Button36_Click(sender, e);

            }
        }
        protected void Button36_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button36.BackColor != System.Drawing.Color.Green)
            {

                Button37_Click(sender, e);

            }
            if (num_of != 0 && Button36.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button36);
                Button37_Click(sender, e);

            }

        }
        protected void Button37_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button37.BackColor != System.Drawing.Color.Green)
            {

                Button38_Click(sender, e);

            }
            if (num_of != 0 && Button37.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button37);
                Button38_Click(sender, e);

            }

        }
        protected void Button38_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button38.BackColor != System.Drawing.Color.Green)
            {

                Button39_Click(sender, e);

            }
            if (num_of != 0 && Button38.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button38);
                Button39_Click(sender, e);

            }
        }
        protected void Button39_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button39.BackColor != System.Drawing.Color.Green)
            {

                Button40_Click(sender, e);

            }
            if (num_of != 0 && Button39.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button39);
                Button40_Click(sender, e);

            }

        }
        protected void Button40_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button40.BackColor != System.Drawing.Color.Green)
            {

                Button41_Click(sender, e);

            }
            if (num_of != 0 && Button40.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button40);
                Button41_Click(sender, e);

            }

        }
        protected void Button41_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button41.BackColor != System.Drawing.Color.Green)
            {

                Button42_Click(sender, e);

            }
            if (num_of != 0 && Button41.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button41);
                Button42_Click(sender, e);

            }

        }
        protected void Button42_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button42.BackColor != System.Drawing.Color.Green)
            {

                Button43_Click(sender, e);

            }
            if (num_of != 0 && Button42.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button42);
                Button43_Click(sender, e);

            }
        }
        protected void Button43_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button43.BackColor != System.Drawing.Color.Green)
            {

                Button44_Click(sender, e);

            }
            if (num_of != 0 && Button43.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button43);
                Button44_Click(sender, e);

            }
        }
        protected void Button44_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button44.BackColor != System.Drawing.Color.Green)
            {

                Button45_Click(sender, e);

            }
            if (num_of != 0 && Button44.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button44);
                Button45_Click(sender, e);

            }
        }
        protected void Button45_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button45.BackColor != System.Drawing.Color.Green)
            {

                Button46_Click(sender, e);

            }
            if (num_of != 0 && Button45.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button45);
                Button46_Click(sender, e);

            }

        }
        protected void Button46_Click(object sender, EventArgs e)
        {
            var num = 46;


            if (num_of != 0 && Button46.BackColor != System.Drawing.Color.Green)
            {

                Button47_Click(sender, e);

            }
            if (num_of != 0 && Button46.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button46);
                Button47_Click(sender, e);

            }
        }
        protected void Button47_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button47.BackColor != System.Drawing.Color.Green)
            {

                Button48_Click(sender, e);

            }
            if (num_of != 0 && Button47.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button47);
                Button48_Click(sender, e);

            }
        }
        protected void Button48_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button48.BackColor != System.Drawing.Color.Green)
            {

                Button49_Click(sender, e);

            }
            if (num_of != 0 && Button48.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button48);
                Button49_Click(sender, e);

            }

        }
        protected void Button49_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button49.BackColor != System.Drawing.Color.Green)
            {

                Button50_Click(sender, e);

            }
            if (num_of != 0 && Button49.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button49);
                Button50_Click(sender, e);

            }
        }
        protected void Button50_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button50.BackColor != System.Drawing.Color.Green)
            {

                Button51_Click(sender, e);

            }
            if (num_of != 0 && Button50.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button50);
                Button51_Click(sender, e);

            }
        }
        protected void Button51_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button51.BackColor != System.Drawing.Color.Green)
            {

                Button52_Click(sender, e);

            }
            if (num_of != 0 && Button51.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button51);
                Button52_Click(sender, e);

            }

        }
        protected void Button52_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button52.BackColor != System.Drawing.Color.Green)
            {

                Button53_Click(sender, e);

            }
            if (num_of != 0 && Button52.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button52);
                Button53_Click(sender, e);

            }

        }
        protected void Button53_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button53.BackColor != System.Drawing.Color.Green)
            {

                Button54_Click(sender, e);

            }
            if (num_of != 0 && Button53.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button53);
                Button54_Click(sender, e);

            }

        }
        protected void Button54_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button54.BackColor != System.Drawing.Color.Green)
            {

                Button55_Click(sender, e);

            }
            if (num_of != 0 && Button54.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button54);
                Button55_Click(sender, e);

            }

        }
        protected void Button55_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button55.BackColor != System.Drawing.Color.Green)
            {

                Button56_Click(sender, e);

            }
            if (num_of != 0 && Button55.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button55);
                Button56_Click(sender, e);

            }

        }
        protected void Button56_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button56.BackColor != System.Drawing.Color.Green)
            {

                Button57_Click(sender, e);

            }
            if (num_of != 0 && Button56.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button56);
                Button57_Click(sender, e);

            }

        }
        protected void Button57_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button57.BackColor != System.Drawing.Color.Green)
            {

                Button58_Click(sender, e);

            }
            if (num_of != 0 && Button57.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button57);
                Button58_Click(sender, e);

            };

        }
        protected void Button58_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button58.BackColor != System.Drawing.Color.Green)
            {

                Button59_Click(sender, e);

            }
            if (num_of != 0 && Button58.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button58);
                Button59_Click(sender, e);

            }

        }
        protected void Button59_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button59.BackColor != System.Drawing.Color.Green)
            {

                Button60_Click(sender, e);

            }
            if (num_of != 0 && Button59.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button59);
                Button60_Click(sender, e);

            }
        }
        protected void Button60_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button60.BackColor != System.Drawing.Color.Green)
            {

                Button61_Click(sender, e);

            }
            if (num_of != 0 && Button60.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button60);
                Button61_Click(sender, e);

            }

        }
        protected void Button61_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button61.BackColor != System.Drawing.Color.Green)
            {

                Button62_Click(sender, e);

            }
            if (num_of != 0 && Button61.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button61);
                Button62_Click(sender, e);

            }

        }
        protected void Button62_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button62.BackColor != System.Drawing.Color.Green)
            {

                Button63_Click(sender, e);

            }
            if (num_of != 0 && Button62.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button62);
                Button63_Click(sender, e);

            }

        }
        protected void Button63_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button63.BackColor != System.Drawing.Color.Green)
            {

                Button64_Click(sender, e);

            }
            if (num_of != 0 && Button63.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button63);
                Button64_Click(sender, e);

            }
        }
        protected void Button64_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button64.BackColor != System.Drawing.Color.Green)
            {

                Button65_Click(sender, e);

            }
            if (num_of != 0 && Button64.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button64);
                Button65_Click(sender, e);

            }
        }
        protected void Button65_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button65.BackColor != System.Drawing.Color.Green)
            {

                Button66_Click(sender, e);

            }
            if (num_of != 0 && Button65.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button65);
                Button66_Click(sender, e);

            }
        }
        protected void Button66_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button66.BackColor != System.Drawing.Color.Green)
            {

                Button67_Click(sender, e);

            }
            if (num_of != 0 && Button66.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button66);
                Button67_Click(sender, e);

            }

        }
        protected void Button67_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button67.BackColor != System.Drawing.Color.Green)
            {

                Button68_Click(sender, e);

            }
            if (num_of != 0 && Button67.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button67);
                Button68_Click(sender, e);

            }
        }
        protected void Button68_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button68.BackColor != System.Drawing.Color.Green)
            {

                Button69_Click(sender, e);

            }
            if (num_of != 0 && Button68.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button68);
                Button69_Click(sender, e);

            }

        }
        protected void Button69_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button69.BackColor != System.Drawing.Color.Green)
            {

                Button70_Click(sender, e);

            }
            if (num_of != 0 && Button69.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button69);
                Button70_Click(sender, e);

            }
        }
        protected void Button70_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button71.BackColor != System.Drawing.Color.Green)
            {

                Button71_Click(sender, e);

            }
            if (num_of != 0 && Button71.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button71);
                Button71_Click(sender, e);

            }

        }
        protected void Button71_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button70.BackColor != System.Drawing.Color.Green)
            {

                Button72_Click(sender, e);

            }
            if (num_of != 0 && Button70.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button70);
                Button72_Click(sender, e);

            }

        }
        protected void Button72_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button72.BackColor != System.Drawing.Color.Green)
            {

                Button73_Click(sender, e);

            }
            if (num_of != 0 && Button72.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button72);
                Button73_Click(sender, e);

            }

        }
        protected void Button73_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button73.BackColor != System.Drawing.Color.Green)
            {

                Button74_Click(sender, e);

            }
            if (num_of != 0 && Button73.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button73);
                Button74_Click(sender, e);

            }
        }
        protected void Button74_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button74.BackColor != System.Drawing.Color.Green)
            {

                Button75_Click(sender, e);

            }
            if (num_of != 0 && Button74.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button74);
                Button75_Click(sender, e);

            };

        }
        protected void Button75_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button75.BackColor != System.Drawing.Color.Green)
            {

                Button76_Click(sender, e);

            }
            if (num_of != 0 && Button75.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button75);
                Button76_Click(sender, e);

            }

        }
        protected void Button76_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button76.BackColor != System.Drawing.Color.Green)
            {

                Button77_Click(sender, e);

            }
            if (num_of != 0 && Button76.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button76);
                Button77_Click(sender, e);

            }

        }
        protected void Button77_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button77.BackColor != System.Drawing.Color.Green)
            {

                Button78_Click(sender, e);

            }
            if (num_of != 0 && Button77.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button77);
                Button78_Click(sender, e);

            }

        }
        protected void Button78_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button78.BackColor != System.Drawing.Color.Green)
            {

                Button79_Click(sender, e);

            }
            if (num_of != 0 && Button78.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button78);
                Button79_Click(sender, e);

            }

        }
        protected void Button79_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button79.BackColor != System.Drawing.Color.Green)
            {

                Button80_Click(sender, e);

            }
            if (num_of != 0 && Button79.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button79);
                Button80_Click(sender, e);

            }

        }
        protected void Button80_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button80.BackColor != System.Drawing.Color.Green)
            {

                Button81_Click(sender, e);

            }
            if (num_of != 0 && Button80.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button80);
                Button81_Click(sender, e);

            }
        }
    
      
    
    protected void Button81_Click(object sender, EventArgs e)
    {
        var num = 1;


        if (num_of != 0 && Button81.BackColor != System.Drawing.Color.Green)
        {

            Button82_Click(sender, e);

        }
        if (num_of != 0 && Button81.BackColor == System.Drawing.Color.Green)
        {
            num_of = statusheck(num, Button81);
            Button82_Click(sender, e);

        }
    }
  
        protected void Button82_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button82.BackColor != System.Drawing.Color.Green)
            {

                Button83_Click(sender, e);

            }
            if (num_of != 0 && Button82.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button82);
                Button83_Click(sender, e);

            }

        }
        protected void Button83_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button83.BackColor != System.Drawing.Color.Green)
            {

                Button84_Click(sender, e);

            }
            if (num_of != 0 && Button83.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button83);
                Button84_Click(sender, e);

            }

        }
        protected void Button84_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button84.BackColor != System.Drawing.Color.Green)
            {

                Button85_Click(sender, e);

            }
            if (num_of != 0 && Button84.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button84);
                Button85_Click(sender, e);

            }

        }
        protected void Button85_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button85.BackColor != System.Drawing.Color.Green)
            {

                Button86_Click(sender, e);

            }
            if (num_of != 0 && Button85.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button85);
                Button86_Click(sender, e);

            }

        }
        protected void Button86_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button86.BackColor != System.Drawing.Color.Green)
            {

                Button87_Click(sender, e);

            }
            if (num_of != 0 && Button86.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button86);
                Button87_Click(sender, e);

            }

        }
        protected void Button87_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button87.BackColor != System.Drawing.Color.Green)
            {

                Button88_Click(sender, e);

            }
            if (num_of != 0 && Button87.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button87);
                Button88_Click(sender, e);

            }

        }
        protected void Button88_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button88.BackColor != System.Drawing.Color.Green)
            {

                Button89_Click(sender, e);

            }
            if (num_of != 0 && Button88.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button88);
                Button89_Click(sender, e);

            }

        }
        protected void Button89_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button89.BackColor != System.Drawing.Color.Green)
            {

                Button90_Click(sender, e);

            }
            if (num_of != 0 && Button89.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button89);
                Button90_Click(sender, e);

            }

        }
        protected void Button90_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button90.BackColor != System.Drawing.Color.Green)
            {

                Button91_Click(sender, e);

            }
            if (num_of != 0 && Button90.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button90);
                Button91_Click(sender, e);

            }

        }
        protected void Button91_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button91.BackColor != System.Drawing.Color.Green)
            {

                Button92_Click(sender, e);

            }
            if (num_of != 0 && Button91.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button91);
                Button92_Click(sender, e);

            }

        }
        protected void Button92_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button92.BackColor != System.Drawing.Color.Green)
            {

                Button93_Click(sender, e);

            }
            if (num_of != 0 && Button92.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button92);
                Button93_Click(sender, e);

            }

        }
        protected void Button93_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button93.BackColor != System.Drawing.Color.Green)
            {

                Button94_Click(sender, e);

            }
            if (num_of != 0 && Button93.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button93);
                Button94_Click(sender, e);

            }

        }
        protected void Button94_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button94.BackColor != System.Drawing.Color.Green)
            {

                Button95_Click(sender, e);

            }
            if (num_of != 0 && Button94.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button94);
                Button95_Click(sender, e);

            }
        }
       
        protected void Button95_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button95.BackColor != System.Drawing.Color.Green)
            {

                Button96_Click(sender, e);

            }
            if (num_of != 0 && Button95.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button95);
                Button96_Click(sender, e);

            }

        }
        protected void Button96_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button96.BackColor != System.Drawing.Color.Green)
            {

                Button97_Click(sender, e);

            }
            if (num_of != 0 && Button96.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button96);
                Button97_Click(sender, e);

            }

        }
    
        void Button97_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button97.BackColor != System.Drawing.Color.Green)
            {

                Button98_Click(sender, e);

            }
            if (num_of != 0 && Button97.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button97);
                Button98_Click(sender, e);

            }

        }
        protected void Button98_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button98.BackColor != System.Drawing.Color.Green)
            {

                Button99_Click(sender, e);

            }
            if (num_of != 0 && Button98.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button98);
                Button99_Click(sender, e);

            }

        }
        protected void Button99_Click(object sender, EventArgs e)
        {
            var num = 1;


            if (num_of != 0 && Button99.BackColor != System.Drawing.Color.Green)
            {

                Button1_Click(sender, e);

            }
            if (num_of != 0 && Button99.BackColor == System.Drawing.Color.Green)
            {
                num_of = statusheck(num, Button99);
                Button1_Click(sender, e);

            }

        }

        protected void Button7_Click1(object sender, EventArgs e)
        {

        }

       
    }



}

