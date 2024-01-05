using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuration of CORS service to enable cross origin requests and data transfers between different browsers and this server
builder.Services.AddCors(options => options.AddDefaultPolicy(
	include =>
	{
		include.AllowAnyHeader();
		include.AllowAnyMethod();
		include.AllowAnyOrigin();
	}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure dbcontext
builder.Services.AddDbContext<PhaseFmContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
