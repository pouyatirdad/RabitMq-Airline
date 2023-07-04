using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;

        //in memory database
        public static readonly List<Booking> _bookings = new();

        public BookingsController(IMessageProducer messageProducer = null)
        {
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreatingBooking(Booking model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _bookings.Add(model);

            _messageProducer.SendingMessage<Booking>(model);

            return Ok();
        }
    }
}