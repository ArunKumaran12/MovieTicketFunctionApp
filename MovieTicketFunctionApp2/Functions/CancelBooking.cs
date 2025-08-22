using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using MovieTicketFunctionApp2.Functions;
using System.Linq;

namespace MovieTicketFunctionApp2.Functions;

public static class CancelBooking
{
    [FunctionName("CancelBooking")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "bookings/{id:int}")] HttpRequest req, int id)
    {
        var booking = BookTicket.GetBookings().FirstOrDefault(b => b.BookingId == id);
        if (booking == null)
            return new NotFoundObjectResult("Booking not found.");

        var movie = SearchMovies.GetMovies().FirstOrDefault(m => m.Id == booking.MovieId);
        if (movie != null)
            movie.AvailableSeats += booking.SeatsBooked;

        BookTicket.GetBookings().Remove(booking);

        return new OkObjectResult($"Booking {id} cancelled successfully.");
    }
}
