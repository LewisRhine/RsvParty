using Microsoft.EntityFrameworkCore;
using RsvParty.Data;
using Microsoft.AspNetCore.Identity;
using RsvParty.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RsvpContext>(options => options.UseSqlite("Data Source=rsvp.db"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<RsvpContext>()
    .AddDefaultTokenProviders();
builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors",
        policy =>
        {
            policy.WithOrigins("http://localhost:63342/")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
        });
});
builder.Host.UseSystemd();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DevCors");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();