// using Microsoft.EntityFrameworkCore;
// using ZooManagement.Repositories;

// namespace ZooManagement
// {
//     public class Startup
//     {
//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         private static string CORS_POLICY_NAME = "_ZooManagementCorsPolicy";

//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddDbContext<ZooManagementDbContext>(options =>
//             {
//                 options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
//                 options.UseSqlite("Data Source=ZooManagement.db");
//             });

//             services.AddCors(options =>
//             {
//                 options.AddPolicy(CORS_POLICY_NAME, builder =>
//                     builder
//                         .WithOrigins("http://localhost:3000")
//                         .AllowAnyMethod()
//                         .AllowAnyHeader());
//             });


//             services.AddControllers();
//             services.AddTransient<IAnimalsRepo, AnimalsRepo>();
//         }

//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             if (env.IsDevelopment())
//             {
//                 app.UseDeveloperExceptionPage();
//             }
//             else
//             {
//                 app.UseHsts();
//             }

//             app.UseHttpsRedirection();

//             app.UseRouting();
            
//             app.UseCors(CORS_POLICY_NAME);

//             app.UseEndpoints(endpoints => endpoints.MapControllers());
//         }
//     }
// }
