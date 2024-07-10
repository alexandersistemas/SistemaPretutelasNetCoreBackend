using Sogs.DAL.Repositorios;
using Sogs.IOC;
using Sogs.BLL.Servicios;
using Sogs.Utility;
using Microsoft.Extensions.FileProviders;
using Sogs.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar la configuración SMTP
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Registrar la configuración DocumentSettings
builder.Services.Configure<DocumentSettings>(builder.Configuration.GetSection("DocumentSettings"));

// Registrar el servicio de correo electrónico
builder.Services.AddTransient<EmailService>();

// Inyectar dependencias
builder.Services.InyectarDependencias(builder.Configuration);

// Configurar CORS
builder.Services.AddCors(options => {
    options.AddPolicy("NuevaPolitica", app => {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

// Configurar para servir archivos estáticos desde la carpeta "UploadedFiles"
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "UploadedFiles")),
    RequestPath = "/UploadedFiles"
});

// Cambia a otro puerto como 5001
app.Run();
