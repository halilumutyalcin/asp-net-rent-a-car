var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
app.MapControllerRoute("/Anasayfa","{controller=Anasayfa}/{action=Index}/{id?}");

app.Run();
// Araçların plaka, marka, model ve renk bilgisi tutulmalıdır. Her bir aracın dahil olduğu sınıfa 
// ilişkin ID, sınıf ve kiralama bedeli bilgisi tutulmalıdır. Bir müşteri aynı anda birçok araç 
// kiralayabilir. Müşterilerin TCK numarası, adı, adresi ve telefon numarası tutulmalıdır. Her bir 
// kiralama işlemine ilişkin ise tarih ve ücret bilgisi tutulmalıdır.
// halil umut yalçın
//201505018