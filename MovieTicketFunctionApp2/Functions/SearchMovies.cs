using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using MovieTicketFunctionApp2.Models;
using System.Collections.Generic;

namespace MovieTicketFunctionApp2.Functions;

public static class SearchMovies
{
    private static readonly List<Movie> Movies = new()
    {
        new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ShowTime = System.DateTime.UtcNow.AddHours(5), AvailableSeats = 50 },
        new Movie { Id = 2, Title = "Titanic", Genre = "Romance", ShowTime = System.DateTime.UtcNow.AddHours(3), AvailableSeats = 40 },
        new Movie { Id = 3, Title = "Avengers: Endgame", Genre = "Action", ShowTime = System.DateTime.UtcNow.AddHours(7), AvailableSeats = 100 }
    };

    [FunctionName("SearchMovies")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "movies")] HttpRequest req)
    {
        return new OkObjectResult(Movies);
    }

    public static List<Movie> GetMovies() => Movies;
}
