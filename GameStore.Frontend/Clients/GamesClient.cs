using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = 
    [
        new() {
            Id = 1,
            Name = "Skyrim",
            Genre = "Adventure",
            Price = 50m,
            ReleaseDate = new DateOnly(2011, 11, 11)
        },

        new() {
            Id = 2,
            Name = "Fifa 23",
            Genre = "Sport",
            Price = 40m,
            ReleaseDate = new DateOnly(2022, 09, 27)
        },

        new() {
            Id = 3,
            Name = "Elden Ring",
            Genre = "Adventure",
            Price = 69.99m,
            ReleaseDate = new DateOnly(2022, 02, 15)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public List<GameSummary> GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.SingleOrDefault(x => x.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre!.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
        
        games.Add(gameSummary);
    }
}
