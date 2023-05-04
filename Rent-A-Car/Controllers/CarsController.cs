using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Models;
using System.Data.SqlClient;
using System.Reflection;

namespace Rent_A_Car.Controllers
{
    public class CarsController : Controller
    {
        #region Cars

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Araba model) 
        {

            String ad = "";
            int arabaUcret = 0;
            Console.WriteLine(model.ArabaSinifID);
            if (model.ArabaSinifID == 1)
            {
                ad = "SUV";
                arabaUcret = 500;
            }
            else if (model.ArabaSinifID == 2)
            {
                ad = "Sedan";
                arabaUcret = 200;
            }
            else if (model.ArabaSinifID == 3)
            {
                ad = "Hatchback";
                arabaUcret = 100;
            }
            else if (model.ArabaSinifID == 4)
            {
                ad = "Station Wagon";
                arabaUcret = 400;
            }




            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO araba " +
                    "(plaka,marka,model,renk,sinifID,sinifAdi,ucret)VALUES " + "(@plaka,@marka,@model,@renk,@sinifID,@sinifAdi,@ucret);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@plaka", model.ArabaPlaka);
                        command.Parameters.AddWithValue("@marka", model.ArabaMarka);
                        command.Parameters.AddWithValue("@model", model.ArabaModel);
                        command.Parameters.AddWithValue("@renk", model.ArabaRenk);
                        command.Parameters.AddWithValue("@sinifID", model.ArabaSinifID);
                        command.Parameters.AddWithValue("@sinifAdi", ad);
                        command.Parameters.AddWithValue("@ucret", arabaUcret);
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

        public IActionResult Edit(string id) 
        {
            Araba araba = new Araba();
            
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from araba Where plaka=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read())
                            {


                                araba.ArabaPlaka = reader.GetString(0);
                                araba.ArabaMarka = reader.GetString(1);
                                araba.ArabaModel = reader.GetString(2);
                                araba.ArabaRenk = reader.GetString(3);
                                araba.ArabaSinifID = reader.GetInt32(4);
                                araba.ArabaUcret = reader.GetInt32(6);

                            }
                           
                                        
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.plaka = araba.ArabaPlaka;
            ViewBag.marka = araba.ArabaMarka;
            ViewBag.model = araba.ArabaModel;
            ViewBag.renk = araba.ArabaRenk;
            ViewBag.sinifID = araba.ArabaSinifID;
            return View();
        }


        [HttpPost]

        public IActionResult Edit(Araba model)
        {
            String ad = "";
            int arabaUcret = 0;
            Console.WriteLine(model.ArabaSinifID);
            if (model.ArabaSinifID == 1)
            {
                ad = "SUV";
                arabaUcret = 500;
            }
            else if (model.ArabaSinifID == 2)
            {
                ad = "Sedan";
                arabaUcret = 200;
            }
            else if (model.ArabaSinifID == 3)
            {
                ad = "Hatchback";
                arabaUcret = 100;
            }
            else if (model.ArabaSinifID == 4)
            {
                ad = "Station Wagon";
                arabaUcret = 400;
            }

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE araba SET marka=@marka, model=@model, renk=@renk , sinifID=@sinifID, sinifAdi=@sinifAdi, ucret=@ucret  WHERE plaka=@plaka";

                    Console.WriteLine(sql);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@plaka", model.ArabaPlaka);
                        command.Parameters.AddWithValue("@marka", model.ArabaMarka);
                        command.Parameters.AddWithValue("@model", model.ArabaModel);
                        command.Parameters.AddWithValue("@renk", model.ArabaRenk);
                        command.Parameters.AddWithValue("@sinifID", model.ArabaSinifID);
                        command.Parameters.AddWithValue("@sinifAdi", ad);
                        command.Parameters.AddWithValue("@ucret", arabaUcret);
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


        public IActionResult Delete(string id)
        {
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from araba Where plaka=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
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
        public IActionResult Rent(string id)
        {
            Araba araba = new Araba();

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from araba Where plaka=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                araba.ArabaPlaka = reader.GetString(0);
                                araba.ArabaMarka = reader.GetString(1);
                                araba.ArabaModel = reader.GetString(2);
                                araba.ArabaRenk = reader.GetString(3);
                                araba.ArabaSinifID = reader.GetInt32(4);
                                araba.ArabaSinifAdi = reader.GetString(5);
                                araba.ArabaUcret = reader.GetInt32(6);
                 

                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(araba.ArabaUcret);
            ViewBag.plaka = araba.ArabaPlaka;
            ViewBag.marka = araba.ArabaMarka;
            ViewBag.model = araba.ArabaModel;
            ViewBag.renk = araba.ArabaRenk;
            ViewBag.sinifID = araba.ArabaSinifID;
            ViewBag.sinifAdi = araba.ArabaSinifAdi;
            ViewBag.ucret = araba.ArabaUcret;

            return View();
        }

        [HttpPost]

        public IActionResult Rent(Musteri model,int ucret)
        {



            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO musteri " +
                    "(tck,ad,adres,telefon)VALUES " + "(@tck,@ad,@adres,@telefon);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", model.MusteriTCK);
                        command.Parameters.AddWithValue("@ad", model.MusteriAd);
                        command.Parameters.AddWithValue("@adres", model.MusteriAdres);
                        command.Parameters.AddWithValue("@telefon", model.MusteriTelefon);
                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO kira " +
                    "(tarih,ucret)VALUES " + "(@tarih,@ucret);";
                    DateTime today = DateTime.Today;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tarih", today.ToString());
                        command.Parameters.AddWithValue("@ucret", ucret);

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

        #endregion

        #region Customers

        public List<Musteri> _musteriler = new List<Musteri>();
        public IActionResult Customers()
        {
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from musteri";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                Musteri musteri = new Musteri();
                                musteri.MusteriTCK = reader.GetInt64(0);
                                musteri.MusteriAd = reader.GetString(1);
                                musteri.MusteriAdres = reader.GetString(2);
                                musteri.MusteriTelefon = reader.GetInt64(3);

                                Console.WriteLine(musteri);
                                _musteriler.Add(musteri);

                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is" + ex.ToString());
            }
            return View(_musteriler);
        }

        [HttpGet]

        public IActionResult CustomersEdit(long id)
        {
            Musteri musteri = new Musteri();

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from musteri Where tck=@tck";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                musteri.MusteriTCK = reader.GetInt64(0);
                                musteri.MusteriAd = reader.GetString(1);
                                musteri.MusteriAdres = reader.GetString(2);
                                musteri.MusteriTelefon = reader.GetInt64(3);
                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.tck = musteri.MusteriTCK;
            ViewBag.ad = musteri.MusteriAd;
            ViewBag.adres = musteri.MusteriAdres;
            ViewBag.telefon = musteri.MusteriTelefon;
            return View();
        }


        [HttpPost]

        public IActionResult CustomersEdit(Musteri model)
        {


            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE musteri SET tck=@tck, ad=@ad, adres=@adres, telefon=@telefon WHERE tck=@tck";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@tck", model.MusteriTCK);
                        command.Parameters.AddWithValue("@ad", model.MusteriAd);
                        command.Parameters.AddWithValue("@adres", model.MusteriAdres);
                        command.Parameters.AddWithValue("@telefon", model.MusteriTelefon);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Bura");
            }

            return RedirectToAction("Customers", "Cars");
        }


        public IActionResult CustomersDelete(long id)
        {
            Console.WriteLine(id);
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from musteri Where tck=@tck";
                    

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", id);
                        command.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Customers", "Cars");
        }


        [HttpGet]
        public IActionResult CustomersCreate()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CustomersCreate(Musteri model)
        {

           


            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO musteri " +
                    "(tck,ad,adres,telefon)VALUES " + "(@tck,@ad,@adres,@telefon);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", model.MusteriTCK);
                        command.Parameters.AddWithValue("@ad", model.MusteriAd);
                        command.Parameters.AddWithValue("@adres", model.MusteriAdres);
                        command.Parameters.AddWithValue("@telefon", model.MusteriTelefon);
                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Customers", "Cars");

        }


        #endregion


        public List<Kira> _kiralar = new List<Kira>();
        public IActionResult Rents()
        {
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from kira";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                Kira kira = new Kira();
                                kira.tarih = reader.GetString(0);
                                kira.ucret = reader.GetInt32(1);
                                _kiralar.Add(kira);

                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is" + ex.ToString());
            }
            return View(_kiralar);
        }









    }
}
