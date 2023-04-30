using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Models;
using System.Data.SqlClient;
using System.Reflection;

namespace Rent_A_Car.Controllers
{
    public class CarsController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Araba model) 
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
            return RedirectToAction("Index", "Anasayfa");

        }

        [HttpGet]

        public IActionResult Edit(int id) 
        {
            Araba araba = new Araba();
            
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=cars;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from arabalarTablosu Where id="+id.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read())
                            {


                                araba.ArabaID = reader.GetInt32(0);
                                araba.ArabaPlaka = reader.GetString(1);
                                araba.ArabaMarka = reader.GetString(2);
                                araba.ArabaModel = reader.GetString(3);
                                araba.ArabaRenk = reader.GetString(4);

                            }
                           
                                        
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.id = araba.ArabaID;
            ViewBag.plaka = araba.ArabaPlaka;
            ViewBag.marka = araba.ArabaMarka;
            ViewBag.model = araba.ArabaModel;
            ViewBag.renk = araba.ArabaRenk;
            return View();
        }



        [HttpPost]

        public IActionResult Edit(Araba model)
        {
            Console.WriteLine(model);

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=cars;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE arabalarTablosu SET plaka=@plaka, marka=@marka, model=@model, renk=@renk WHERE id=@id";

                    Console.WriteLine(sql);
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

            return RedirectToAction("Index", "Anasayfa");
        }


        public IActionResult Delete(int id)
        {
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=cars;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from arabalarTablosu Where id=" + id.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Anasayfa");
        }


    }
}
