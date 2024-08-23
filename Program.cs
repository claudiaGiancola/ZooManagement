using Microsoft.EntityFrameworkCore;
using ZooManagement;
using Microsoft.OpenApi.Models;
using ZooManagement.Data;
using ZooManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ZooManager API",
        Description = "An ASP.NET Core Web API for managing Zoo animals",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddTransient<IAnimalsRepo, AnimalsRepo>();

builder.Services.AddDbContext<ZooManagementDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ZooManagementDbContext"));
    options.UseSqlite("Data Source=ZooManagement.db");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.MapGet("/", () => "Hello, World!");

app.MapControllers();

static void CreateDbIfNotExists(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ZooManagementDbContext>();
    context.Database.EnsureCreated();

    if (!context.Animals.Any())
    {
        var animal = SampleAnimals.GetAnimals();
        context.Animals.AddRange(animal);
        context.SaveChanges();
    }
    if (!context.Classifications.Any())
    {
        var classification = SampleClassification.GetClassifications();
        context.Classifications.AddRange(classification);
        context.SaveChanges();
    }
    if (!context.Species.Any())
    {
        var species = SampleSpecies.GetSpecies();
        context.Species.AddRange(species);
        context.SaveChanges();
    }
}

CreateDbIfNotExists(app);

app.Run();


// using ZooManagement.Data;

// namespace ZooManagement
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             var host = CreateHostBuilder(args).Build();

//             CreateDbIfNotExists(host);
//             host.Run();
//         }

//         private static void CreateDbIfNotExists(IHost host)
//         {
//             using var scope = host.Services.CreateScope();
//             var services = scope.ServiceProvider;

//             var context = services.GetRequiredService<ZooManagementDbContext>();
//             context.Database.EnsureCreated();

//             if (!context.Animals.Any())
//             {
//                 var animal = SampleAnimals.GetAnimals();
//                 context.Animals.AddRange(animal);
//                 context.SaveChanges();
//             }
//             if (!context.Classifications.Any())
//             {
//                 var classification = SampleClassification.GetClassifications();
//                 context.Classifications.AddRange(classification);
//                 context.SaveChanges();
//             }
//             if (!context.Species.Any())
//             {
//                 var species = SampleSpecies.GetSpecies();
//                 context.Species.AddRange(species);
//                 context.SaveChanges();
//             }
//         }

//         public static IHostBuilder CreateHostBuilder(string[] args) =>
//             Host.CreateDefaultBuilder(args)
//                 .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
//     }
// }