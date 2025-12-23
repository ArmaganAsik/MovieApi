using MovieApi.Application.Features.CQRSDesignPattern.Commands.TvShowCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.TvShowHandlers
{
    public class CreateTvShowCommandHandler
    {
        private readonly MovieContext _context;

        public CreateTvShowCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTvShowCommand command)
        {
            _context.TvShows.Add(new TvShow
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                FirstAirDate = command.FirstAirDate,
                CreatedYear = command.CreatedYear,
                AverageEpisodeDuration = command.AverageEpisodeDuration,
                SeasonCount = command.SeasonCount,
                EpisodeCount = command.EpisodeCount,
                Status = command.Status,
                CategoryId = command.CategoryId,
                Category= command.Category
            });
            await _context.SaveChangesAsync();
        }
    }
}
