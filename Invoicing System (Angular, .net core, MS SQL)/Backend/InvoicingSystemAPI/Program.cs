using WebApplication1.implementation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<CustomerControllerService>();
builder.Services.AddScoped<ProductControllerService>();
builder.Services.AddScoped<InvoiceControllerService>();
builder.Services.AddScoped<AdminControllerService>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(a=>a.AddPolicy(name:"AllowOrigin",b=>b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
