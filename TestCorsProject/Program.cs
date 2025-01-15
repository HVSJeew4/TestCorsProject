using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICorsPolicyService, CorsPolicyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(async corsBuilder =>
{
    using var scope = app.Services.CreateScope();
    var corsService = scope.ServiceProvider.GetRequiredService<ICorsPolicyService>();
    var allowedOrigins = await corsService.GetAllowedOriginsAsync();

    corsBuilder.WithOrigins(allowedOrigins.ToArray())
               .AllowAnyHeader()
               .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
