using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.ReviewQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.ReviewResults;
using MovieApi.Persistence.Context;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MovieContext _context;

        public ReviewsController(IMediator mediator, MovieContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ReviewList([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            int totalCount = await _context.Reviews.CountAsync();
            Response.Headers.Add("X-Total-Count", totalCount.ToString());

            List<GetReviewQueryResult> reviews = await _mediator.Send(new GetReviewQuery { Page = page, PageSize = pageSize });
            return Ok(reviews);
        }
    }
}
