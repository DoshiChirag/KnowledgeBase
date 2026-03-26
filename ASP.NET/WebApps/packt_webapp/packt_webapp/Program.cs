using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseContentRoot(Directory.GetCurrentDirectory());

var app = builder.Build();  
   

builder.Build().Run();








    


