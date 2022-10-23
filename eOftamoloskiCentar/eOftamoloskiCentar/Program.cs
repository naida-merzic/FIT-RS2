using eOftamoloskiCentar.Filters;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using eOftamoloskiCentar.Services.ArtikalStateMachine;
using eOftamoloskiCentar.Services.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});

builder.Services.AddTransient<IArtikliService, ArtikliService>();
builder.Services.AddTransient<IDijagnozaService, DijagnozaService>();
builder.Services.AddTransient<IVrstaArtiklaService, VrstaArtiklaService>();
builder.Services.AddTransient<IUposlenikService, UposlenikService>();
builder.Services.AddTransient<IKlijentService, KlijentService>();
builder.Services.AddTransient<ISpolService, SpolService>();
builder.Services.AddTransient<ITerminService, TerminService>();
builder.Services.AddTransient<INovostService, NovostService>();
builder.Services.AddTransient<IRacunService, RacunService>();
builder.Services.AddTransient<IKorisnickiRacun, KorisnickiRacunService>();



//register state machine all states
builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialArtikalState>();
builder.Services.AddTransient<DraftArtikalState>();
builder.Services.AddTransient<ActiveArtikalState>();
builder.Services.AddTransient<IService<eOftamoloskiCentar.Model.Rola, BaseSearchObject>, BaseService<eOftamoloskiCentar.Model.Rola, Rola, BaseSearchObject>>();

builder.Services.AddAutoMapper(typeof(IArtikliService));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

//builder.Services.AddSingleton<IArtikliService, ArtikliService>();

builder.Services.AddDbContext<OftamoloskiCentarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<OftamoloskiCentarContext>();
    //dataContext.Database.Migrate();
}

app.Run();
