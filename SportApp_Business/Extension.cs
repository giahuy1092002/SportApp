using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Automapper;
using Org.BouncyCastle.Asn1.X509.Qualified;
using SportApp_Infrastructure.Services;

namespace SportApp_Business
{
    public static class Extension
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddInfrastructureService(configuration);
            services.AddMediatR(typeof(SignUpCommand).Assembly);
            services.AddMediatR(typeof(CreateUserCommand).Assembly);
            services.AddMediatR(typeof(SignInCommand).Assembly);
            services.AddAutoMapper(typeof(AutomapperProfile));
            services.AddTransient(typeof(TokenService));
            services.AddTransient(typeof(ImageService));
            return services;
        }
    }
}
