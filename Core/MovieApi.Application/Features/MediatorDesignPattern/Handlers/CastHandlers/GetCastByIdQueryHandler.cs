using MediatR;
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
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            Cast cast = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = cast.CastId,
                Title = cast.Title,
                Name = cast.Name,
                Surname = cast.Surname,
                ImageUrl = cast.ImageUrl,
                Overview = cast.Overview,
                Biography = cast.Biography
            };
        }
    }
}
