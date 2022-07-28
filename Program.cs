var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cada vez que se inyecte la interfaz IHelloWorldService se va a crear un nuevo objeto de HelloWorldService
// builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); 
builder.Services.AddScoped <IHelloWorldService>(p=> new HelloWorldService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

// app.UseWelcomePage();
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
