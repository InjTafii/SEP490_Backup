
using BusinessObject.Data;
using DataAccessLayer.DataLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Implements;
using Services.Interfaces;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IEssayTaskRepository, EssayTaskRepository>();
            builder.Services.AddScoped<IWorkbookCategoryRepository, WorkbookCategoryRepository>();
            builder.Services.AddScoped<IWorkbookRepository, WorkbookRepository>();
            builder.Services.AddScoped<IEssayTaskService, EssayTaskService>();
            builder.Services.AddScoped<IWorkbookCategoryService, WorkbookCategoryService>();
            builder.Services.AddScoped<IWorkbookService, WorkbookService>();
            builder.Services.AddScoped<WorkbookDAO>();
            builder.Services.AddScoped<EssayTaskDAO>();
            builder.Services.AddScoped<WorkbookCategoryDAO>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MyDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 33))));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
