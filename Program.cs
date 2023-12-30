using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSingleton<IUsersRepository, DbUsersRepository>();
builder.Services.AddScoped<IUsersRepository, DbUsersRepository>();
builder.Services.AddDbContext<DatabaseConf>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 22))));

builder.Services.AddControllers();
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
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DatabaseConf>();
    dbContext.Database.Migrate();
}
app.Run();