using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieWithCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieWithCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieWithCategoryQueryResult>> Handle()
        {
            List<Movie> movies = await _context.Movies.Include(y=>y.Category).ToListAsync();
            return movies.Select(x => new GetMovieWithCategoryQueryResult
            {
                MovieId = x.MovieId,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            }).ToList();
        }
    }
}
