using ContactApp;
using ContactApp.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seeder>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Konfiguracja CORS
builder.Services.AddCors(options => options.AddPolicy(name: "FrontContactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        }
        ));
                          

var app = builder.Build();
//Sprawdzanie argumentów uruchomienia aplikacji i uruchamianie seeda danych
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app); // sprawdzenie czy aplikacja uruchomiono z jednym argumentem i czy ten argument do seeddata jaœli tak to wywo³a funkcjie SeedData

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seeder>();
        service.SeedDataContext();
    }
}
app.UseCors("FrontContactApp");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseAuthentication();



app.MapControllers();

app.Run();
