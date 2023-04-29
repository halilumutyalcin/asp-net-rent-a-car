using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Models;

namespace Rent_A_Car.Controllers;

public class Anasayfa : Controller
{
    public static List<Araba> _arabaListe = new List<Araba>()
    {
        new Araba()
        {
            ArabaID = 1,
            ArabaPlaka = "34ABC34",
            ArabaMarka = "Mercedes Benz",
            ArabaModel = "C220"
        },
        new Araba()
        {
            ArabaID = 2,
            ArabaPlaka = "34DEF34",
            ArabaMarka = "Renault",
            ArabaModel = "Captur"
        },

    };
    public IActionResult Index()
    {
        ViewBag.Arabalar = _arabaListe;
        return View(_arabaListe);
    }
    public Anasayfa() { }
    // public IActionResult Listele()
    // {
    //     return View();
    // }


    // public IActionResult Detay(int id) {
    //
    //     UrunModel urun = _urunListe.FirstOrDefault(a => a.UrunID == id);
    //
    //     return View(urun);
    // }
    // public IActionResult Duzenle(int id)
    // {
    //
    //     return View();
    // }
    // public IActionResult Sil(int id)
    // {
    //
    //     return View();
    // }


    // [HttpGet]
    // public IActionResult Ekle()
    // {
    //     return View();
    // }



    // [HttpPost]
    // public IActionResult Ekle(UrunModel model) //int UrunID,string UrunAdi,string UrunMarka, string UrunKategori,int StokAdedi
    // {
    //     _urunListe.Add(model);
    //     return View();
    // }

    
    // GET
 
}