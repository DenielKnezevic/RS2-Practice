using Microsoft.EntityFrameworkCore;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.ProductStateMachine;
using RS2_Vjezba.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(IKorisnikService));

builder.Services.AddDbContext<eProdajaContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<IProizvodiService, ProizvodiService>();
builder.Services.AddTransient<IJediniceMjereService, JediniceMjereService>();
builder.Services.AddTransient<IVrsteProizvodumService, VrsteProizvodumService>();

builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<ActiveState>();
builder.Services.AddTransient<DraftState>();
builder.Services.AddTransient<HiddenState>();
builder.Services.AddTransient<InitialState>();

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
