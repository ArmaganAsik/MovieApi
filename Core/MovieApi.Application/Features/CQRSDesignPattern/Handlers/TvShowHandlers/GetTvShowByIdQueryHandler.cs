using MovieApi.Application.Features.CQRSDesignPattern.Queries.TvShowQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.TvShowResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.TvShowHandlers
{
    public class GetTvShowByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetTvShowByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetTvShowByIdQueryResult> Handle(GetTvShowByIdQuery query)
        {
            TvShow tvShow = await _context.TvShows.FindAsync(query.TvShowId);
            return new GetTvShowByIdQueryResult
            {
                TvShowId = tvShow.TvShowId,
                Title = tvShow.Title,
                CoverImageUrl = tvShow.CoverImageUrl,
                Rating = tvShow.Rating,
                Description = tvShow.Description,
                FirstAirDate = tvShow.FirstAirDate,
                CreatedYear = tvShow.CreatedYear,
                AverageEpisodeDuration = tvShow.AverageEpisodeDuration,
                SeasonCount = tvShow.SeasonCount,
                EpisodeCount = tvShow.EpisodeCount,
                Status = tvShow.Status,
                CategoryId = tvShow.CategoryId
            };
        }
    }
}
