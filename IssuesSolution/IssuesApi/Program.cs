//THIS IS OUR ENTRY POINT FOR OUR APPLICATION

//CREATES A BUILDER OBJECT WITH DEFAULT SERVICES ATTACHED TO IT
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//a Container is an Inversion of Control (IOC) Container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Use Reflection at runtime to document your API with an openapi3.0 spec

//Above this line is "setup" configuration
var app = builder.Build();
//Everything after this line is mapping requests that come in from the Web Server



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();// makes the "Services.AddSwaggerGen()" available through a URL
    app.UseSwaggerUI();// Makes a web page available at /swagger/index.html that reads the above open api spec and shows a UI
}



app.UseAuthorization();




app.MapControllers();

//Go Find all my controllers

//Ctrl + F5 //Run in Development Mode
//Will Save, Build and Compile then generates a new window with the Swagger URL
app.Run();// Blocking Call. This is the webserver (kestrel) running and listing as long as the application runs...
