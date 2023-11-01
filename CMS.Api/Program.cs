using CMS.BusinessLogic.Interface;
using CMS.BusinessLogic.Repository;
using CMS.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IDbConnection>(prov => new SqlConnection(prov.GetService<IConfiguration>().GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IChoir, ChoirRepo>();
builder.Services.AddScoped<IPastor, PastorRepo>();
builder.Services.AddScoped<ISourceofIncome, SourceofIncomeRepo>();
builder.Services.AddScoped<IMember, MemberRepo>();
builder.Services.AddScoped<IMedia, MediaRepo>();




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
    



