using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Universities.Interfaces;
using Universities.models;
using Universities.Repositry;
using Universities.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();


builder.Services.AddDbContext<universityDBContext>(option =>
{
    option.UseSqlServer(config.GetConnectionString("uniconn"), o => { o.CommandTimeout(3000); });

});

//inject  services 

builder.Services.AddScoped<Ilookuprepositry, lookuprepositry>();
builder.Services.AddScoped<IminorService, minorService>();
builder.Services.AddScoped<IApplicationsRepository, ApplicationsRepository> ();
builder.Services.AddScoped<IApplicationsServices, ApplicationsServices> ();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<ICoursesService, CoursesService>();

builder.Services.AddMvcCore().AddAuthorization().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200") // Angular URL
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

using (var serviceScope = app.Services
               .GetRequiredService<IServiceScopeFactory>()
               .CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetService<universityDBContext>())
    {
        context.Database.Migrate();
    }
}


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular"); // Enable CORS
app.UseAuthorization();

app.MapControllers();

app.Run();
