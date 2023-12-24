using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("https://localhost:44398"));
}); // Cross Origin Request => API'ye izin verilen yerin d���nda bir istek geldi�inde hem burada hem taray�c�da bir g�venlik tehditi
// alg�land�g�ndan dolay� izin verilmez.
// Origin : �stek yap�lan yer.

var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Kullan�c�ya token verdi�imiz zaman issuer olarak appsettingste girilen issuer atan�yor mu onu kontrol eder.
        ValidateAudience = true,
        ValidateLifetime = true, // Token'�n ge�erlilik s�resini appsettingstekiyle ayn� olup olmad���n� kontrol eder.
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
    };
});

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddSingleton<ICarService,CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();
//builder.Services.AddSingleton<IBrandService,BrandManager>();
//builder.Services.AddSingleton<IBrandDal,EfBrandDal>();
//builder.Services.AddSingleton<ICustomerService, CustomerManager>();
//builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();
//builder.Services.AddSingleton<IRentalService, RentalManager>();
//builder.Services.AddSingleton<IRentalDal, EfRentalDal>();
//builder.Services.AddSingleton<IColorService, ColorManager>();
//builder.Services.AddSingleton<IColorDal, EfColorDal>();
//builder.Services.AddSingleton<IUserService, UserManager>();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Bir istek geldi�inde Auth vs. istiyorsan�z o Auth'un devreye girmesini middleware ile ger�ekle�tirirz.
app.UseCors(builder => builder.WithOrigins("https://localhost:44398").AllowAnyHeader()); // Header : Get,Post,Put,Patch vb.
app.UseHttpsRedirection();

app.UseAuthentication(); // Bir yere girmek i�in anahtar (giri� anahtar�)
app.UseAuthorization(); // Girilen yerde yap�labilecek �eyler (yetki)
//Middlewarelar s�ral� �al���r.

app.MapControllers();

app.Run();
