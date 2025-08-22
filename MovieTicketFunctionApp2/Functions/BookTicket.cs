using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using MovieTicketFunctionApp2.Models;

namespace MovieTicketFunctionApp2.Functions
{
    public static class BookTicket
    {
        private static List<Booking> bookings = new List<Booking>();
        private static int bookingCounter = 1;

        [FunctionName("BookTicket")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bookings")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Booking>(requestBody);

            if (data == null || string.IsNullOrEmpty(data.CustomerName) || data.MovieId <= 0 || data.SeatsBooked <= 0)
            {
                return new BadRequestObjectResult("Invalid booking request.");
            }

            var newBooking = new Booking
            {
                BookingId = bookingCounter++,
                MovieId = data.MovieId,
                CustomerName = data.CustomerName,
                SeatsBooked = data.SeatsBooked,
                BookingDate = DateTime.UtcNow,
                MovieName = data.MovieName
            };

            bookings.Add(newBooking);

            return new OkObjectResult(newBooking);
        }

        public static List<Booking> GetBookings()
        {
            return bookings;
        }
    }
}
