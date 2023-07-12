using FrontEndAPI.Model;
using FrontEndLibrary.DataAdapter;
using FrontEndLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

EnvironmentSettings settings = builder.Configuration.GetSection("LocalSettings").Get<EnvironmentSettings>();

//Inject Data Adapters
builder.Services.AddSingleton<IPersonAdapter>(a 
    => new PersonAdapter(settings.DBConnectionString));
builder.Services.AddSingleton<IPersonService>(s 
    => new PersonService(s.GetRequiredService<IPersonAdapter>()));

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
