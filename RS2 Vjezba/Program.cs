using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RS2_Vjezba.Filters;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.ProductStateMachine;
using RS2_Vjezba.Services.Services;
using RS2_Vjezbe.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    }) ;

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme , Id = "basicAuth"}
            },
            new string[]{}
        }
    });
});
builder.Services.AddAutoMapper(typeof(IKorisnikService));

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddDbContext<eProdajaContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<IProizvodiService, ProizvodiService>();
builder.Services.AddTransient<IJediniceMjereService, JediniceMjereService>();
builder.Services.AddTransient<IVrsteProizvodumService, VrsteProizvodumService>();
builder.Services.AddTransient<IUlogeService, UlogeService>();

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

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<eProdajaContext>();
    //dataContext.Database.Migrate();
}

app.Run();
