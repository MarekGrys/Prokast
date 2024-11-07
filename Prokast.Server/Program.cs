using Microsoft.EntityFrameworkCore;
using Prokast.Server;
using Prokast.Server.Entities;
using Prokast.Server.Services;



var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProkastServerDbContext>(opt=>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ILogInService, LogInService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5500",
                                              "http://localhost:3001");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
