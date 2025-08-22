using Microsoft.Extensions.Primitives;
using System;

namespace MovieTicketFunctionApp2.Models;

public class Booking
{
    public int BookingId { get; set; }
    public int MovieId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int SeatsBooked { get; set; }
    public DateTime BookingDate { get; internal set; }
    public StringValues MovieName { get; internal set; }
}
