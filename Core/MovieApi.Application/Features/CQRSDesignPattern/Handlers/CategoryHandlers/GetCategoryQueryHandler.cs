using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                Name = x.Name
            }).ToList();
        }
    }
}
