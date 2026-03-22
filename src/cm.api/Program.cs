using cm.Application.Contract;
using cm.Application.Contract.cm.Application.Interfaces;
using cm.Application.Interfaces;
using cm.Application.Service;
using cm.Application.Services;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;
using cm.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetConnectionString("connection");

builder.Services.AddDbContext<AppDbContext>((context) => context.UseSqlServer(config));
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IAcedemicRecordRepository, AcedemicRecordRepository>();
builder.Services.AddTransient<ICatalogCourseRepository, CatalogCourseRepository>();
builder.Services.AddTransient<IFacultyRepository, FacultyRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IProfessorRepository, ProfesorRepository>();
builder.Services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>(); 
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICatalogCourseService, CatalogCourseService>();


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