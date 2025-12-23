using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.TvShowQueries
{
    public class GetTvShowByIdQuery
    {
        public int TvShowId { get; set; }

        public GetTvShowByIdQuery(int tvShowId)
        {
            TvShowId = tvShowId;
        }
    }
}
