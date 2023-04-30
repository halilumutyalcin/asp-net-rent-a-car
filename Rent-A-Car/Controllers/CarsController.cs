using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Models;
using System.Data.SqlClient;

namespace Rent_A_Car.Controllers
{
    public class CarsController : Controller
    {
        public Araba araba = new Araba();


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Araba model) //int UrunID,string UrunAdi,string UrunMarka, string UrunKategori,int StokAdedi
        {

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=cars;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO arabalarTablosu " +
                    "(id,plaka,marka,model,renk)VALUES " + "(@id,@plaka,@marka,@model,@renk);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", model.ArabaID);
                        command.Parameters.AddWithValue("@plaka", model.ArabaPlaka);
                        command.Parameters.AddWithValue("@marka", model.ArabaMarka);
                        command.Parameters.AddWithValue("@model", model.ArabaModel);
                        command.Parameters.AddWithValue("@renk", model.ArabaRenk);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();

        }



    }
}
