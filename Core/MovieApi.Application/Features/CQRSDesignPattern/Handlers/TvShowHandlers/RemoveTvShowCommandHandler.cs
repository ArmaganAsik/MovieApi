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
    public class RemoveTvShowCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveTvShowCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTvShowCommand command)
        {
            TvShow tvShow = await _context.TvShows.FindAsync(command.TvShowId);
            _context.TvShows.Remove(tvShow);
            await _context.SaveChangesAsync();
        }
    }
}
