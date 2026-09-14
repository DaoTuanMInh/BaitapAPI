using WebApplication1.IUser;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;
using WebApplication1.Student;
using WebApplication1.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserService,UserService>(); // Dependences Injection :(AddSingleton,AddScoped)
builder.Services.AddTransient<IStudentservice,StudentService>();
// Bai 1,bai2
builder.Services.AddTransient<IProductService, Productservice>();
builder.Services.AddTransient<IOrderService, OrderService>();
//bai 8
builder.Services.AddTransient<ICategoryService, CategoryService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
