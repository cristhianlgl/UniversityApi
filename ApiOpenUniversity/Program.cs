// 1. usings to work with  EntityFramework
using ApiOpenUniversity.DataBase;
using ApiOpenUniversity.ExtensionMethods;
using ApiOpenUniversity.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//2.  Get ConnetionString to settings
string conn = builder.Configuration.GetConnectionString("default");

//3. add DbContext
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(conn);
});

//TODO: 
// 7. add services of JWT authorization
builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();

//4. add services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();

//8. add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

//5. cors configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "corsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//9. add config swagger to take care of authorization of JWT 
builder.Services.AddSwaggerGen(options => 
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT authorization header using bearer scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
    
});

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

// 6. tell app to use cors
app.UseCors("corsPolicy");

app.Run();
