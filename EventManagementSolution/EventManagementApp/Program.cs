
using EventManagementApp.Context;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Repositories;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                    options.SuppressModelStateInvalidFilter = true
                );

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EventManagementDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
            );

            #region Services
            builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
            #endregion

            #region Repositories
            builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRespository));
            #endregion


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
