using Otiva.Infrastructure.Modules;
using Otiva.Registrar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices();

builder.Services.AddControllers();

builder.Services.AddAuthentificationModule(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerModule();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.WithOrigins("http://localhost:4040").AllowAnyMethod().AllowAnyHeader());
app.UseCors(builder => builder.WithOrigins("http://salessssssssssssssssssss.site").AllowAnyMethod().AllowAnyHeader());
app.UseCors(builder => builder.WithOrigins("http://192.168.0.92").AllowAnyMethod().AllowAnyHeader());
app.UseCors(builder => builder.WithOrigins("http://192.168.0.92/").AllowAnyMethod().AllowAnyHeader());


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
