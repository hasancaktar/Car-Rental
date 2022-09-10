using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolves.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//IoC Container. ICarService ba��ml�l��� g�r�rse bellekte CarManager ad�nda  ref olu�tur. Singleton bellekte bir tane ref olu�turur isterse bir milyon tane istek gelsin ayn� instance � verir
//Sinleton i�inde data tutulmad��� zamanlarda kullan�l�r
//builder.Services.AddSingleton<ICarService, CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>  builder.RegisterModule(new AutofacBusinessModule()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); //�imdi ��yle ki �OP yapaca��m�z� bildirmemiz gerekiyor. bunu normalde .net 5 veya 3 te starup i�erisinde bildiriyorduk projeye. fakat .net 6 da startup yok. bu sebeple buraya yazmam�z gerekiyor gerekli kodlar�.
    //Ben bi 3 dakika ara�t�ray�m buraya yazmaya �al��al�m. ard�ndan �al���rsa e�er neyi neden yapt���m�z� anlatay�m sana olur mu? olur peki bir 3 dakika bakay�m ben 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
