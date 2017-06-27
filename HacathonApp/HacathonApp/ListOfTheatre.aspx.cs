using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HacathonApp
{
    public partial class ListOfTheatre : System.Web.UI.Page
    {
        

        public class Movie
        {
            public string theatrename { get; set; }
            public string theatreaddress { get; set; }
            //public string moviename { get; set; }
            //public float price { get; set; }
            ////public DateTime  showtime{ get; set; }
            //public int availableseats { get; set; }
            //public int bookedseats { get; set; }
            //public int blockedsseats { get; set; }

        }



        protected void Page_Load(object sender, EventArgs e)
        {
            string mvname = Server.UrlDecode(Request.QueryString["moviename"]);
           
            Label3.Text = mvname;
            string value1;
            string value2;
            string value3;
                        string value4;
            List<Movie> student = new List<Movie>();

            string _connString =
       ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
            SqlConnection con = new SqlConnection(_connString);
            con.Open();
            SqlCommand com = new SqlCommand("select theatrename,theatreaddress from Theatre where moviename ='"+mvname+"'",con);
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //adapter.SelectCommand = com;
            //adapter.Fill(ds);

            SqlDataReader dr ;
            try
            {
                //con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    student.Add(new Movie()
                    {
                        
                        theatrename = (string) dr["theatrename"],
                        theatreaddress = (string)dr["theatreaddress"],
                        //moviename = (string)dr["moviename"],
                        //price = (float)dr["price"],
                        ////showtime =(DateTime)( dr["showtime"]),
                        //availableseats = (int)dr["availableseats"],
                        //bookedseats = (int)dr["bookedseats"],
                        //blockedsseats = (int)dr["blockedseats"]
                    });

                }
                LinkButton1.Text = student[0].theatrename;
                LinkButton2.Text = student[1].theatrename;
                LinkButton3.Text = student[2].theatrename;
                LinkButton4.Text = student[3].theatrename;

                Label4.Text = student[0].theatreaddress;
                Label5.Text = student[1].theatreaddress;
                Label6.Text = student[2].theatreaddress;
                Label7.Text = student[3].theatreaddress;

                dr.Close();

                    con.Close();
            }
            catch (Exception exp)
            {

                throw exp;
            }
            finally
            {

                con.Close();
            }




        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            LinkButton btn = sender as LinkButton;
            string tname = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(mname), Server.UrlEncode(tname)));
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            LinkButton btn = sender as LinkButton;
            string tname = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(mname), Server.UrlEncode(tname)));
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            LinkButton btn = sender as LinkButton;
            string tname = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(mname), Server.UrlEncode(tname)));
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {

            string mname = Server.UrlDecode(Request.QueryString["moviename"]);
            LinkButton btn = sender as LinkButton;
            string tname = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(mname), Server.UrlEncode(tname)));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}