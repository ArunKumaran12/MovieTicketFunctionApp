using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace MovieTicketFunctionApp2.Functions
{
    public static class GetBooking
    {
        [FunctionName("GetBooking")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "bookings/{id:int}")] HttpRequest req, int id)
        {
            var booking = BookTicket.GetBookings().FirstOrDefault(b => b.BookingId == id);

            return booking != null
                ? new OkObjectResult(booking)
                : new NotFoundObjectResult($"Booking with ID {id} not found.");
        }
    }
}
