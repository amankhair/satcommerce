using Microsoft.AspNetCore.Mvc;
using Sat.Infrastructure.Data;
using Sat.Server.Errors;

namespace Sat.Server.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            //long id = 42;
            var thing = _context.Products.Find((long)42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find((long)42);

            var thingToReturn = thing.ToString();

            //return Ok();
            return StatusCode(500, "Something went wrong.");
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(long id)
        {
            return Ok();
        }
    }
}
