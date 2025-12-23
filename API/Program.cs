using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// DB Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Password Hasher
builder.Services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();

// Add HttpContextAccessor for logging
builder.Services.AddHttpContextAccessor();

// CORS - Allow all for development
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Controllers with JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use PascalCase
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var passwordHasher = services.GetRequiredService<IPasswordHasher<AppUser>>();

        // Apply migrations
        context.Database.Migrate();

        // Seed default users
        if (!context.Users.Any(u => u.UserName == "admin"))
        {
            var adminUser = new AppUser
            {
                UserName = "admin",
                FullName = "System Administrator",
                Role = "Admin"
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");
            context.Users.Add(adminUser);
        }

        if (!context.Users.Any(u => u.UserName == "reception"))
        {
            var receptionUser = new AppUser
            {
                UserName = "reception",
                FullName = "Reception Desk",
                Role = "Receptionist"
            };
            receptionUser.PasswordHash = passwordHasher.HashPassword(receptionUser, "Reception@123");
            context.Users.Add(receptionUser);
        }

        // Seed sample guests if table is empty
        if (!context.Guests.Any())
        {
            context.Guests.AddRange(
                new Guest
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Phone = "123-456-7890",
                    Email = "john.doe@email.com",
                    Address = "123 Main St, New York",
                    IDType = "National ID",
                    IDNumber = "ID123456789",
                    Notes = "VIP Customer",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsActive = true
                },
                new Guest
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Phone = "987-654-3210",
                    Email = "jane.smith@email.com",
                    Address = "456 Oak Ave, Los Angeles",
                    IDType = "Passport",
                    IDNumber = "P987654321",
                    Notes = "Allergic to peanuts",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsActive = true
                },
                new Guest
                {
                    FirstName = "Robert",
                    LastName = "Johnson",
                    Phone = "555-123-4567",
                    Email = "robert.j@email.com",
                    Address = "789 Pine Rd, Chicago",
                    IDType = "Driver's License",
                    IDNumber = "DL789012345",
                    Notes = "Prefers non-smoking room",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsActive = true
                }
            );
        }

        context.SaveChanges();
        Console.WriteLine("Database seeded successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error seeding database: {ex.Message}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Management API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();