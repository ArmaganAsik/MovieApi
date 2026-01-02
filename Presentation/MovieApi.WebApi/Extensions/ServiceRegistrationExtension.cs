using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.TvShowHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using System.Runtime.CompilerServices;

namespace MovieApi.WebApi.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();

            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<GetMovieWithCategoryQueryHandler>();

            services.AddScoped<GetTvShowQueryHandler>();
            services.AddScoped<GetTvShowByIdQueryHandler>();
            services.AddScoped<CreateTvShowCommandHandler>();
            services.AddScoped<RemoveTvShowCommandHandler>();
            services.AddScoped<UpdateTvShowCommandHandler>();

            services.AddScoped<CreateUserRegisterCommandHandler>();

            return services;
        }
    }
}
