using System;

namespace MovieTicketFunctionApp2.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime ShowTime { get; set; }
    public int AvailableSeats { get; set; }
}
