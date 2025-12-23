using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductCatCategory.Infrastructure.Repositories;
using ProductCatProducts.Application.UseCases.CatProducts.Create;
using ProductCatProducts.Infrastructure.Repositories;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.Services;
using ProductInventory.Application.UseCases.CatCategory.Create;
using ProductInventory.Application.UseCases.CatCategory.Delete;
using ProductInventory.Application.UseCases.CatCategory.Get;
using ProductInventory.Application.UseCases.CatCategory.Update;
using ProductInventory.Application.UseCases.CatProducts.Create;
using ProductInventory.Application.UseCases.CatProducts.Delete;
using ProductInventory.Application.UseCases.CatProducts.Get;
using ProductInventory.Application.UseCases.Inventory.Create;
using ProductInventory.Application.UseCases.Inventory.Delete;
using ProductInventory.Application.UseCases.Inventory.Get;
using ProductInventory.Application.UseCases.Inventory.Update;
using ProductInventory.Application.UseCases.InventoryMovements.Create;
using ProductInventory.Application.UseCases.InventoryMovements.Get;
using ProductInventory.Application.UseCases.Login;
using ProductInventory.Application.UseCases.User;
using ProductInventory.Infrastructure.Context;
using ProductInventory.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IPassService, PassService>();
builder.Services.AddScoped<IInventoryMovementsRepository, InventoryMovementsRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<ICatProductsRepository, CaProductRepository>();
builder.Services.AddScoped<ICatCategoryRepository, CatCategoryRepository>();
builder.Services.AddScoped<UserHandler>();
builder.Services.AddScoped<LoginHandler>();
builder.Services.AddScoped<UpdateInventoryHandler>();
builder.Services.AddScoped<DeleteInventoryHandler>();
builder.Services.AddScoped<CreateInventoryHandler>();
builder.Services.AddScoped<GetInventoryHandler>();
builder.Services.AddScoped<UpdateCatCategoryHandler>();
builder.Services.AddScoped<DeleteCatCategoryHandler>();
builder.Services.AddScoped<CreateCatCategoryHandler>();
builder.Services.AddScoped<GetCatCategoryHandler>();
builder.Services.AddScoped<UpdateCatProductsHandler>();
builder.Services.AddScoped<DeleteCatProductsHandler>();
builder.Services.AddScoped<CreateCatProductsHandler>();
builder.Services.AddScoped<GetCatProductsHandler>();
builder.Services.AddScoped<GetInventoryMovementsHandler>();
builder.Services.AddScoped<CreateInventoryMovementsHandler>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


