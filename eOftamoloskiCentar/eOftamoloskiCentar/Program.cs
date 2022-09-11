using eOftamoloskiCentar.Services;
using eOftamoloskiCentar.Services.ArtikalStateMachine;
using eOftamoloskiCentar.Services.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IArtikliService, ArtikliService>();
builder.Services.AddTransient<IOsobeService, OsobeService>();
builder.Services.AddTransient<IDijagnozaService, DijagnozaService>();
builder.Services.AddTransient<IVrstaArtiklaService, VrstaArtiklaService>();
builder.Services.AddTransient<IUposlenikService, UposlenikService>();

//register state machine all states
builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialArtikalState>();
builder.Services.AddTransient<DraftArtikalState>();
builder.Services.AddTransient<ActiveArtikalState>();

builder.Services.AddAutoMapper(typeof(IOsobeService));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
