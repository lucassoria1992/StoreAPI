var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("nueva politica", app =>
    {
        app.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("nueva politica"); // Colocar antes de app.UseHttpsRedirection()
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();






