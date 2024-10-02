using JWTAuthAPI.Data;
using JWTAuthAPI.Services;
using JWTAuthAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using JWTAuthAPI.Shared.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyWorldDbContext>(options => {options.UseSqlServer(builder.Configuration.GetConnectionString("sampleDb"));
});
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options => 
{ 
        options.AddPolicy(name: "BlazorCors", 
            policy => 
            { 
                policy.WithOrigins("http://localhost:5236")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
});

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection(nameof(TokenSettings)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("BlazorCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
