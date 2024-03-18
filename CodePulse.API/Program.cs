
using CodePulse.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Get the Connection String from appSetting.json to use in Dbcontext
            var connection_url = builder.Configuration.GetConnectionString("CodePulseConnectionString");

            // connecting Dbcontext in program.cs and giving db connection string using sqlserver method() from EFCore
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection_url));

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
        }
    }
}