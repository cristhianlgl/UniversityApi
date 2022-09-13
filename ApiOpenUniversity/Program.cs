// 1. usings to work with  EntityFramework
using ApiOpenUniversity.DataBase;
using ApiOpenUniversity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//2.  Get ConnetionString to settings
string conn = builder.Configuration.GetConnectionString("default");

//3. add DbContext
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(conn);
});


builder.Services.AddControllers();

//4. add services
builder.Services.AddScoped<IStudentService, StudentService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
