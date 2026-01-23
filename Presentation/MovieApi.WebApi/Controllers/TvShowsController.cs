using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.TvShowCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.TvShowHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.TvShowQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.TvShowResults;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly GetTvShowQueryHandler _getTvShowQueryHandler;
        private readonly GetTvShowByIdQueryHandler _getTvShowByIdQueryHandler;
        private readonly CreateTvShowCommandHandler _createTvShowCommandHandler;
        private readonly UpdateTvShowCommandHandler _updateTvShowCommandHandler;
        private readonly RemoveTvShowCommandHandler _removeTvShowCommandHandler;
        private readonly GetTvShowWithCategoryQueryHandler _getTvShowWithCategoryQueryHandler;

        public TvShowsController(GetTvShowQueryHandler getTvShowQueryHandler, GetTvShowByIdQueryHandler getTvShowByIdQueryHandler, CreateTvShowCommandHandler createTvShowCommandHandler, UpdateTvShowCommandHandler updateTvShowCommandHandler, RemoveTvShowCommandHandler removeTvShowCommandHandler, GetTvShowWithCategoryQueryHandler getTvShowWithCategoryQueryHandler)
        {
            _getTvShowQueryHandler = getTvShowQueryHandler;
            _getTvShowByIdQueryHandler = getTvShowByIdQueryHandler;
            _createTvShowCommandHandler = createTvShowCommandHandler;
            _updateTvShowCommandHandler = updateTvShowCommandHandler;
            _removeTvShowCommandHandler = removeTvShowCommandHandler;
            _getTvShowWithCategoryQueryHandler = getTvShowWithCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> TvShowList()
        {
            List<GetTvShowQueryResult> tvShows = await _getTvShowQueryHandler.Handle();
            return Ok(tvShows);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTvShow(CreateTvShowCommand command)
        {
            await _createTvShowCommandHandler.Handle(command);
            return Ok("TvShow added successfully!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTvShow(int id)
        {
            await _removeTvShowCommandHandler.Handle(new RemoveTvShowCommand(id));
            return Ok("TvShow deleted successfully!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTvShow(UpdateTvShowCommand command)
        {
            await _updateTvShowCommandHandler.Handle(command);
            return Ok("Tv Show updated successfully!");
        }

        [HttpGet("GetTvShowById")]
        public async Task<IActionResult> GetTvShowById(int id)
        {
            GetTvShowByIdQueryResult tvShow = await _getTvShowByIdQueryHandler.Handle(new GetTvShowByIdQuery(id));
            return Ok(tvShow);
        }

        [HttpGet("GetTvShowWithCategory")]
        public async Task<IActionResult> GetTvShowWithCategory()
        {
            List<GetTvShowWithCategoryQueryResult> values = await _getTvShowWithCategoryQueryHandler.Handle();
            return Ok(values);
        }
    }
}
