using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TrafficPrediction.Models;
namespace TrafficPrediction.Controllers
{
    
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ContentResult Save(User user)
        {
            string status = "";

            using SqlConnection con = new SqlConnection("data source=./SQLEXPRESS; database=TrafficPrediction; integrated security=SSPI");

            string query = "INSERT INTO UserRegister(Name,Email,Password) VALUES(@Name, @Email, @Password)";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;

                con.Open();

                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                status = (cmd.ExecuteNonQuery() >= 1) ? "Record is saved Successfully!" : "Record is not saved";
                status += "<br/>";
            }

            using (SqlCommand cmd = new SqlCommand("select * from UserRegister"))
            {
                cmd.Connection = con;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    status += "<b>name:</b> " + sdr["Name"] + "<br/> <b>Email:</b> " + sdr["Email"] + "<br>";
                }
            }
            return Content(status);
        }
    }
}
