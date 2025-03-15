using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;

        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            List<Cast> casts = await _context.Casts.ToListAsync();
            return casts.Select(x => new GetCastQueryResult
            {
                CastId = x.CastId,
                Title = x.Title,
                Name = x.Name,
                Surname = x.Surname,
                ImageUrl = x.ImageUrl,
                Overview = x.Overview,
                Biography = x.Biography
            }).ToList();
        }
    }
}
