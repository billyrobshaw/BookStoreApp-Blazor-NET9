using BookStoreApp.API.Configurations;
using BookStoreApp.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Adding services to the container.
var connString = builder.Configuration.GetConnectionString("BooksStoreAppDbConnection");
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(connString));
//Adding Idenity Services
builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BookStoreDbContext>();

//Adding AutoMapper Service
builder.Services.AddAutoMapper(typeof(MapperConfig));
//Adding Controllers Service
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//Adding Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//Setting up Logger
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)
);

//Buidling Cors and allowing any access
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", 
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});


var app = builder.Build();

// Configure the HTTP request pipeline.

//https://localhost:7060/swagger/index.html
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//Enabling Cors
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
