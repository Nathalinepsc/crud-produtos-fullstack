using Microsoft.EntityFrameworkCore;
using ProjetoNsaSenhora.Data;
using ProjetoNsaSenhora.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers
builder.Services.AddControllers();

// Swagger (interface de teste)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura a conexão com o banco de dados MySQL
var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mysqlOptions =>
        {
            mysqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

// Redireciona HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita CORS para permitir requisições de qualquer origem
app.UseAuthorization();

// Ativa controllers
app.MapControllers();

// Inicia a aplicação
app.Run();
