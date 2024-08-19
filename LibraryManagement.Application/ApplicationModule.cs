using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagement.Application.Validators;
using LibraryManagement.Application.Commands.UserCommands.CreateCommonUser;

namespace LibraryManagement.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => 
                config.RegisterServicesFromAssemblyContaining<CreateCommonUserCommand>());

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateCommonUserCommand>();

            return services;
        }

    }
}
