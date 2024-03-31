using Gateway.Configuration.Options;
using Gateway.DataAccess;
using Gateway.DataAccess.Repositories;
using Gateway.External.Clients.Common;
using Gateway.External.Clients.NotificationService;
using Gateway.External.Clients.ServiceReceiver;
using Gateway.External.Clients.SubscriptionService;
using Microsoft.AspNetCore.Authentication.Cookies;
using IHttpClientFactory = Gateway.External.Clients.Common.IHttpClientFactory;

namespace Gateway
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
            builder.Services.AddDbContext<GatewayDbContext>();
            builder.Services.Configure<ServiceAddressesOptions>(options =>
                builder.Configuration.GetSection(ServiceAddressesOptions.SectionName).Bind(options));

            builder.Services.AddTransient<IHttpClientFactory, HttpClientFactory>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<INotificationServiceClient, NotificationServiceClient>();
            builder.Services.AddTransient<INotificationServiceQueryFactory, NotificationServiceQueryFactory>();
            builder.Services.AddTransient<IServiceReceiverClient, ServiceReceiverClient>();
            builder.Services.AddTransient<IServiceReceiverQueryFactory, ServiceReceiverQueryFactory>();
            builder.Services.AddTransient<ISubscriptionServiceClient, SubscriptionServiceClient>();
            builder.Services.AddTransient<ISubscriptionServiceQueryFactory, SubscriptionServiceQueryFactory>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/sign-in");
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
