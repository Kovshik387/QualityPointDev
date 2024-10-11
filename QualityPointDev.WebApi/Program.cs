using QualityPointDev.WebApi;
using QualityPointDev.WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAppCors();
builder.Services.AddAppAutoMappers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAppCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

