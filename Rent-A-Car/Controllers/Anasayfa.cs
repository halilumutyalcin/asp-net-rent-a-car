using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Models;
using System.Data.SqlClient;
namespace Rent_A_Car.Controllers;

public class Anasayfa : Controller
{
// çalışıyor ve araba cons yok 
    // public static List<Araba> _arabaListe = new List<Araba>()
    // {
    //     new Araba()
    //     {
    //         ArabaID = 1,
    //         ArabaPlaka = "34ABC34",
    //         ArabaMarka = "Mercedes Benz",
    //         ArabaModel = "C220"
    //     },
    //     new Araba()
    //     {
    //         ArabaID = 2,
    //         ArabaPlaka = "34DEF34",
    //         ArabaMarka = "Renault",
    //         ArabaModel = "Captur"
    //     },
    //
    // };
    // public IActionResult Index()
    // {
    //     ViewBag.Arabalar = _arabaListe;
    //     return View(_arabaListe);
    // }
    // public Anasayfa() { }

    public List<Araba> _arabalar = new List<Araba>();

    public Anasayfa()
    {



        try
        {
            String connectionString = "Data Source=ASUS;Initial Catalog=cars;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "Select * from arabalarTablosu";
                
                using (SqlCommand command = new SqlCommand(sql,connection)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    { 
                        
                        while (reader.Read())
                        {

                            Araba araba = new Araba();
                            araba.ArabaID = reader.GetInt32(0);
                            araba.ArabaPlaka = reader.GetString(1);
                            araba.ArabaMarka = reader.GetString(2);
                            araba.ArabaModel = reader.GetString(3);
                            araba.ArabaRenk = reader.GetString(4);

                            _arabalar.Add(araba);

                        }

                    }
                }
            }



        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception is" + ex.ToString());
        }


        // _liste = new List<Araba>()
        // {
        //     new Araba(1,"34 ABC 37","Mercedes Benz",arabaModel:"C220"),
        //     new Araba(2,"34 DEF 37","Renault",arabaModel:"Captur"),
        //     new Araba(3,"34 XYZ 37","Peugeot",arabaModel:"508"),
        // };
    }

    public IActionResult Index()
    { 
        return View(_arabalar);
    }
    
    
}