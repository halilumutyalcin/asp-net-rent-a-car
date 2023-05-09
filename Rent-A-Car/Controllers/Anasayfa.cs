using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Models;
using System.Data.SqlClient;
namespace Rent_A_Car.Controllers;

public class Anasayfa : Controller
{

    public List<Araba> _arabalar = new List<Araba>();

    public Anasayfa()
    {



        try
        {
            String connectionString = "Data Source=ASUS;Initial Catalog=db;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "Select * from araba";
                
                using (SqlCommand command = new SqlCommand(sql,connection)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {

                        while (reader.Read())
                        {

                            Araba okunanAraba = new Araba();
                            okunanAraba.ArabaPlaka = reader.GetString(0);
                            okunanAraba.ArabaMarka = reader.GetString(1);
                            okunanAraba.ArabaModel = reader.GetString(2);
                            okunanAraba.ArabaRenk = reader.GetString(3);
                            okunanAraba.ArabaSinifID = reader.GetInt32(4);
                            Console.WriteLine(okunanAraba);
                            _arabalar.Add(okunanAraba);

                        }

                    }
                }
            }



        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception is" + ex.ToString());
        }


    }

    public IActionResult Index()
    { 
        return View(_arabalar);
    }
    
    
}