

using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

//Permet la génération automatique de documentation des routes
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{   //le premier argument, en l'occurence "v0.1" détermine le lien défini dans c.swaggerEndPoint()
    //Si on a "v1" ici et "/swagger/v01/swagger.json" dans SwaggerEndPoint(), il y aura une fetch error lorsqu'on essaye d'accéder à la documentation
     c.SwaggerDoc("V0.1", new OpenApiInfo { Title = "JamaisASec API", Description = "Donne accès à la base de données gérant pour le client lourd et le site web", Version = "v0.1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/V0.1/swagger.json", "JamaisASec API V0.1");
   });
}


//Possible d'ajouter CORS, regarder documentation ASP.NET CORE
//builder.Services.AddCors(options => {});

app.MapGet("/", () => "Hello World!");

app.Run();
