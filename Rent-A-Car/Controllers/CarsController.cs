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


            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO araba " +
                    "(plaka,marka,model,renk,sinifID)VALUES " + "(@plaka,@marka,@model,@renk,@sinifID);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@plaka", model.ArabaPlaka);
                        command.Parameters.AddWithValue("@marka", model.ArabaMarka);
                        command.Parameters.AddWithValue("@model", model.ArabaModel);
                        command.Parameters.AddWithValue("@renk", model.ArabaRenk);
                        command.Parameters.AddWithValue("@sinifID", model.ArabaSinifID);
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

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from sınıf Where id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", model.ArabaSinifID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                arabaUcret = reader.GetInt32(0);
                                ad = reader.GetString(2);

                            }


                        }


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
                    String sql = "UPDATE araba SET marka=@marka, model=@model, renk=@renk , sinifID=@sinifID  WHERE plaka=@plaka";

                    Console.WriteLine(sql);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@plaka", model.ArabaPlaka);
                        command.Parameters.AddWithValue("@marka", model.ArabaMarka);
                        command.Parameters.AddWithValue("@model", model.ArabaModel);
                        command.Parameters.AddWithValue("@renk", model.ArabaRenk);
                        command.Parameters.AddWithValue("@sinifID", model.ArabaSinifID);

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

            String ad = "";
            int arabaUcret = 0;

            


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
                 

                            }


                        }


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
                    String sql = "Select * from sınıf Where id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", araba.ArabaSinifID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                arabaUcret = reader.GetInt32(0);
                                ad = reader.GetString(2);

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
            ViewBag.sinifAdi = ad;
            ViewBag.ucret = arabaUcret;


            return View();
        }

        [HttpPost]

        public IActionResult Rent(Musteri model,int ucret,string plaka)
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
                    "(tarih,ucret,musteri_tc,araba_plaka)VALUES " + "(@tarih,@ucret,@tc,@plaka);";
                    DateTime bugun = DateTime.Now;
                    string tarihVeSaat = bugun.ToString("dd/MM/yyyy HH:mm");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tarih", tarihVeSaat);
                        command.Parameters.AddWithValue("@ucret", ucret);
                        command.Parameters.AddWithValue("@tc",model.MusteriTCK);
                        command.Parameters.AddWithValue("@plaka", plaka);

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
            }

            return RedirectToAction("Customers", "Cars");
        }


        public IActionResult CustomersDelete(long id)
        {

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

        #region Kira
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
                                kira.musteri_tc = reader.GetInt64(2); 
                                kira.araba_plaka = reader.GetString(3); 
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

        [HttpGet]
        public IActionResult RentsCreate()
        {
            return View();
        }



        [HttpPost]
        public IActionResult RentsCreate(Kira model)
        {
            

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO kira " +
                    "(tarih,ucret,musteri_tc,araba_plaka)VALUES " + "(@tarih,@ucret,@tc,@plaka);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tarih", model.tarih);
                        command.Parameters.AddWithValue("@ucret", model.ucret);
                        command.Parameters.AddWithValue("@tc", model.musteri_tc);
                        command.Parameters.AddWithValue("@plaka", model.araba_plaka);
                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Rents", "Cars");

        }

        [HttpGet]

        public IActionResult RentsEdit(string id)
        {
            Console.WriteLine(id);
            Kira kira = new Kira();

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from kira Where tarih=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                kira.tarih = reader.GetString(0);
                                kira.ucret = reader.GetInt32(1);
                                kira.musteri_tc = reader.GetInt64(2);
                                kira.araba_plaka = reader.GetString(3);

                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.tarih = kira.tarih;
            ViewBag.ucret = kira.ucret;
            ViewBag.tc = kira.musteri_tc;
            ViewBag.plaka = kira.araba_plaka;
            return View();
        }


        [HttpPost]

        public IActionResult RentsEdit(Kira model)
        {


            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE kira SET ucret=@ucret, musteri_tc=@tck, araba_plaka=@plaka  WHERE tarih=@tarih";

                    Console.WriteLine(sql);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ucret", model.ucret);
                        command.Parameters.AddWithValue("@tck", model.musteri_tc);
                        command.Parameters.AddWithValue("@plaka", model.araba_plaka);
                        command.Parameters.AddWithValue("@tarih", model.tarih);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Rents", "Cars");
        }


        public IActionResult RentsDelete(string id)
        {
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from kira Where tarih=@id";

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

            return RedirectToAction("Rents", "Cars");
        }



        #endregion

        #region Araç Sınıfları


        public List<Sınıf> _siniflar = new List<Sınıf>();
        public IActionResult Sınıf()
        {
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from sınıf";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                Sınıf sinif = new Sınıf();
                                sinif.sinifUcret = reader.GetInt32(0);
                                sinif.sinifID = reader.GetInt32(1);
                                sinif.sinifAdi = reader.GetString(2);
                                _siniflar.Add(sinif);

                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is" + ex.ToString());
            }
            return View(_siniflar);
        }

        [HttpGet]
        public IActionResult SınıfCreate()
        {
            Console.WriteLine("123");
            return View();
        }



        [HttpPost]
        public IActionResult SınıfCreate(Sınıf model)
        {


            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO sınıf " +
                    "(kiralama_bedeli,id,sınıf)VALUES " + "(@ucret,@sid,@sınıfAdi);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@sid", model.sinifID);
                        command.Parameters.AddWithValue("@ucret", model.sinifUcret);
                        command.Parameters.AddWithValue("@sınıfAdi", model.sinifAdi);
                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Sınıf", "Cars");

        }

        [HttpGet]

        public IActionResult SınıfEdit(int id)
        {
            Console.WriteLine(id);
            Sınıf sinif = new Sınıf();

            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from sınıf Where id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                sinif.sinifUcret = reader.GetInt32(0);
                                sinif.sinifID = reader.GetInt32(1);
                                sinif.sinifAdi = reader.GetString(2);

                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.ucret = sinif.sinifUcret;
            ViewBag.id = sinif.sinifID;
            ViewBag.adi = sinif.sinifAdi;
            return View();
        }


        [HttpPost]

        public IActionResult SınıfEdit(Sınıf model)
        {


            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE sınıf SET kiralama_bedeli=@ucret,sınıf=@sınıf  WHERE id=@id";

                    Console.WriteLine(sql);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ucret", model.sinifUcret);
                        command.Parameters.AddWithValue("@sınıf", model.sinifAdi);
                        command.Parameters.AddWithValue("@id", model.sinifID);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Sınıf", "Cars");
        }


        public IActionResult SınıfDelete(string id)
        {
            try
            {
                String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from sınıf Where id=@id";

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

            return RedirectToAction("Sınıf", "Cars");
        }


        #endregion 



    }
}
