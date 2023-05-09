using Rent_A_Car.Models;
using System.Numerics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
app.MapControllerRoute("/Anasayfa","{controller=Anasayfa}/{action=Index}/{id?}");

app.Run();
//Ara�lar�n plaka, marka, model ve renk bilgisi tutulmal�d�r. Her bir arac�n dahil oldu�u s�n�fa 
//ili�kin ID, s�n�f ve kiralama bedeli bilgisi tutulmal�d�r. Bir m��teri ayn� anda bir�ok ara� 
//kiralayabilir. M��terilerin TCK numaras�, ad�, adresi ve telefon numaras� tutulmal�d�r. Her bir 
//kiralama i�lemine ili�kin ise tarih ve �cret bilgisi tutulmal�d�r.


//Ara�lar(plaka, model, renk, marka, id)
//S�n�f(Kiralama bedeli, Id, s�n�f)

//M��teri(telefon, TC, ad, adres)

//Kirala/tarih, �cret, m��teri TC, araba plaka) I



