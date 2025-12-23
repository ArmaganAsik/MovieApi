using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
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
    public class UpdateTvShowCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateTvShowCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTvShowCommand command)
        {
            TvShow tvShow = await _context.TvShows.FindAsync(command.TvShowId);
            tvShow.Title = command.Title;
            tvShow.CoverImageUrl = command.CoverImageUrl;
            tvShow.Rating = command.Rating;
            tvShow.Description = command.Description;
            tvShow.FirstAirDate = command.FirstAirDate;
            tvShow.CreatedYear = command.CreatedYear;
            tvShow.AverageEpisodeDuration = command.AverageEpisodeDuration;
            tvShow.SeasonCount = command.SeasonCount;
            tvShow.EpisodeCount = command.EpisodeCount;
            tvShow.Status = command.Status;
            tvShow.CategoryId = command.CategoryId;
            await _context.SaveChangesAsync();
        }
    }
}
