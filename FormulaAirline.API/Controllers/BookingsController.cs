using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IMessageProducer messageProducer;

        public BookingsController(IMessageProducer messageProducer = null)
        {
            this.messageProducer = messageProducer;
        }
    }
}