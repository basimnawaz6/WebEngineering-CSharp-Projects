using FeedBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using FeedBackWithUI.Models;

namespace YourProjectName.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=FeedbackDB;Trusted_Connection=true;Encrypt=false;TrustServerCertificate=true";
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GiveFeedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GiveFeedback(Feedback feedback)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Feedbacks (StudentName, Course, Comments, Rating, DateSubmitted) VALUES (@StudentName, @Course, @Comments, @Rating, @DateSubmitted)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentName", feedback.StudentName);
                cmd.Parameters.AddWithValue("@Course", feedback.Course);
                cmd.Parameters.AddWithValue("@Comments", feedback.Comments);
                cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
                cmd.Parameters.AddWithValue("@DateSubmitted", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("FeedbackSummary", feedback);
        }

        [HttpGet]
        public IActionResult FeedbackSummary(Feedback feedback)
        {
            return View(feedback);
        }

        [HttpGet]
        public IActionResult AllFeedbacks()
        {
            List<Feedback> feedbacks = new List<Feedback>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Feedbacks ORDER BY DateSubmitted DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    feedbacks.Add(new Feedback
                    {
                        Id = (int)reader["Id"],
                        StudentName = reader["StudentName"].ToString(),
                        Course = reader["Course"].ToString(),
                        Comments = reader["Comments"].ToString(),
                        Rating = (int)reader["Rating"]
                    });
                }
            }

            return View(feedbacks);
        }
    }
}
