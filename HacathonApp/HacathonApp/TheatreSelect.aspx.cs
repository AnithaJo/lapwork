using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace HacathonApp
{
    public partial class TheatreSelect : System.Web.UI.Page
    {

        public class Theatre
        {
            //public string theatrename { get; set; }
            //public string theatreaddress { get; set; }
            public string moviename { get; set; }
            //public float price { get; set; }
            ////public DateTime  showtime{ get; set; }
            //public int availableseats { get; set; }
            //public int bookedseats { get; set; }
            //public int blockedsseats { get; set; }

        }
        List<Theatre> student = new List<Theatre>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);

           
            List<Theatre> student = new List<Theatre>();

            string _connString =
            ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
            SqlConnection con = new SqlConnection(_connString);
            con.Open();
            SqlCommand com = new SqlCommand("select moviename from Theatre where theatrename  = '"+tname+"'", con);
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataSet ds = new DataSet();e
            //adapter.SelectCommand = com;
            //adapter.Fill(ds);

            SqlDataReader dr;
            try
            {
                //con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    student.Add(new Theatre()
                    {

                        //theatrename = (string)dr["theatrename"],
                        //theatreaddress = (string)dr["theatreaddress"],
                        moviename = (string)dr["moviename"]
                        //price = (float)dr["price"],
                        ////showtime =(DateTime)( dr["showtime"]),
                        //availableseats = (int)dr["availableseats"],
                        //bookedseats = (int)dr["bookedseats"],
                        //blockedsseats = (int)dr["blockedseats"]
                    });

                }

                LinkButton1.Text = student[0].moviename;
                LinkButton2.Text = student[1].moviename;
                LinkButton3.Text = student[2].moviename;

                LinkButton4.Text = student[3].moviename;
                LinkButton5.Text = student[4].moviename;

                LinkButton6.Text = student[5].moviename;

                ImageButton1.ImageUrl = @"~/images/" + student[0].moviename+".jpg";
                ImageButton2.ImageUrl = @"~/images/" + student[1].moviename+ ".jpg";
                ImageButton3.ImageUrl = @"~/images/" + student[2].moviename + ".jpg";
                ImageButton4.ImageUrl = @"~/images/" + student[3].moviename + ".jpg";
                ImageButton5.ImageUrl = @"~/images/" + student[4].moviename + ".jpg";
                ImageButton6.ImageUrl = @"~/images/" + student[5].moviename + ".jpg";
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            LinkButton btn = sender as LinkButton;
            string movie_name = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(movie_name), Server.UrlEncode(tname)));
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            LinkButton btn = sender as LinkButton;
            string movie_name = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(movie_name), Server.UrlEncode(tname)));
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            LinkButton btn = sender as LinkButton;
            string movie_name = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(movie_name), Server.UrlEncode(tname)));
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            LinkButton btn = sender as LinkButton;
            string movie_name = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(movie_name), Server.UrlEncode(tname)));
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            LinkButton btn = sender as LinkButton;
            string movie_name = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(movie_name), Server.UrlEncode(tname)));
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            string tname = Server.UrlDecode(Request.QueryString["theatrename"]);
            LinkButton btn = sender as LinkButton;
            string movie_name = btn.Text;
            //Response.Redirect("Movie.aspx?moviename=" + Server.UrlEncode(movie_name));
            Response.Redirect(String.Format("Movie.aspx?moviename={0}&theatrename={1}", Server.UrlEncode(movie_name), Server.UrlEncode(tname)));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
           
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
           
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}