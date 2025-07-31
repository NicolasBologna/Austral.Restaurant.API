using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Extensions;
using Austral.Restaurant.API.Repositories.Implementations;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Implementations;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string AllowAllPolicy = "AllowAll";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestaurantApiContext>(dbContextOptions =>
{
    dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:RestaurantAPI"]);
});

#region Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
#endregion

#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllPolicy, policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(AllowAllPolicy);

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();