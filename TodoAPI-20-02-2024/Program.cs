using Microsoft.EntityFrameworkCore;
using TodoAPI_20_02_2024.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//cors ekledik
builder.Services.AddCors(s =>s.AddDefaultPolicy(
    p=>p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() ));



builder.Services.AddDbContext<TodoContext>(builder => builder.UseInMemoryDatabase("TodoList"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();


//dizinlerde index html default yapýlýr
app.UseDefaultFiles();
//static dosyalarýn dýþarýya açýlmasý (wwwroot)
app.UseStaticFiles();


//cors
app.UseCors();

app.UseAuthorization();



app.MapControllers();

//veri tabaný yoksa oluþtur
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoContext>();
    db.Database.EnsureCreated();

}
app.Run();



// Install-Package Microsoft.EntityFrameworkCore
// Install-Package Microsoft.EntityFrameworkCore.InMemory
