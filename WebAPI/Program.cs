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
//IoC Container. ICarService baðýmlýlýðý görürse bellekte CarManager adýnda  ref oluþtur. Singleton bellekte bir tane ref oluþturur isterse bir milyon tane istek gelsin ayný instance ý verir
//Sinleton içinde data tutulmadýðý zamanlarda kullanýlýr
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
    app.UseSwaggerUI(); //Þimdi þöyle ki ÂOP yapacaðýmýzý bildirmemiz gerekiyor. bunu normalde .net 5 veya 3 te starup içerisinde bildiriyorduk projeye. fakat .net 6 da startup yok. bu sebeple buraya yazmamýz gerekiyor gerekli kodlarý.
    //Ben bi 3 dakika araþtýrayým buraya yazmaya çalýþalým. ardýndan çalýþýrsa eðer neyi neden yaptýðýmýzý anlatayým sana olur mu? olur peki bir 3 dakika bakayým ben 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
