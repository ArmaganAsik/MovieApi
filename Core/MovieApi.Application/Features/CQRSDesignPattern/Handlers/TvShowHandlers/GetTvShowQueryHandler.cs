using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.TvShowResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.TvShowHandlers
{
    public class GetTvShowQueryHandler
    {
        private readonly MovieContext _context;

        public GetTvShowQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetTvShowQueryResult>> Handle()
        {
            List<TvShow> tvShows = await _context.TvShows.ToListAsync();
            return tvShows.Select(x => new GetTvShowQueryResult
            {
                TvShowId = x.TvShowId,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                FirstAirDate = x.FirstAirDate,
                CreatedYear = x.CreatedYear,
                AverageEpisodeDuration = x.AverageEpisodeDuration,
                SeasonCount = x.SeasonCount,
                EpisodeCount = x.EpisodeCount,
                Status = x.Status,
                CategoryId = x.CategoryId
            }).ToList();
        }
    }
}
