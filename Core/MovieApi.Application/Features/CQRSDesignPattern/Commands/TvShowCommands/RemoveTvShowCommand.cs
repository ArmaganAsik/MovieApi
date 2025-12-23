using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.TvShowCommands
{
    public class RemoveTvShowCommand
    {
        public int TvShowId { get; set; }

        public RemoveTvShowCommand(int tvShowId)
        {
            TvShowId = tvShowId;
        }
    }
}
