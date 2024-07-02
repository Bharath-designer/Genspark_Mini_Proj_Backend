
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;
using EventManagementApp.Context;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Repositories;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EventManagementApp
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            })
                .ConfigureApiBehaviorOptions(options =>
                    options.SuppressModelStateInvalidFilter = true
                )
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                    };
                });


            builder.Services.AddDbContext<EventManagementDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
            );

            #region Services
            builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
            builder.Services.AddScoped(typeof(ITokenService), typeof(TokenService));
            builder.Services.AddScoped(typeof(IEventCategoryService), typeof(EventCategoryService));
            builder.Services.AddScoped(typeof(IQuotationRequestService), typeof(QuotationRequestService));
            builder.Services.AddScoped(typeof(IQuotationResponseService), typeof(QuotationResponseService));
            builder.Services.AddScoped(typeof(IClientResponseService), typeof(ClientResponseService));
            builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
            builder.Services.AddScoped(typeof(IPaymentService), typeof(PaymentService));
            builder.Services.AddScoped(typeof(IAdminService), typeof(AdminService));
            builder.Services.AddScoped(typeof(IScheduledEventService), typeof(SchedulesEventService));
            builder.Services.AddScoped(typeof(INotificationService), typeof(NotificationService));


            #endregion

            #region Repositories
            builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRespository));
            builder.Services.AddScoped(typeof(IEventCategoryRepository), typeof(EventCategoryRepository));  
            builder.Services.AddScoped(typeof(IQuotationRequestRepository), typeof(QuotationRequestRepository));
            builder.Services.AddScoped(typeof(IQuotationResponseRepository), typeof(QuotationResponseRepository));
            builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            builder.Services.AddScoped(typeof(ITransactionRepository), typeof(TransactionRepository));
            builder.Services.AddScoped(typeof(IScheduledEventRepository), typeof(ScheduledEventRepository));
            builder.Services.AddScoped(typeof(INotificationRepository), typeof(NotificationRepository));

            #endregion




            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
