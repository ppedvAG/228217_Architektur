using ppedv.BerlinBytes.Model.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string conString = "Server=(localdb)\\mssqllocaldb;Database=BerlinBytes_Test;Trusted_Connection=true;";
builder.Services.AddScoped<IUnitOfWork>(x => new ppedv.BerlinBytes.Data.Db.EfUnitOfWork(conString));

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
