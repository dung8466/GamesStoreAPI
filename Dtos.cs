using System.ComponentModel.DataAnnotations;

namespace GamesStore.Api.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateGameDto(
    [Required, StringLength(50)] string Name,
    [Required, StringLength(20)] string Genre,
    [Range(0, 100)] decimal Price,
    DateTime ReleaseDate,
    [Url] string ImageUri
);

public record UpdateGameDto(
    [Required, StringLength(50)] string Name,
    [Required, StringLength(20)] string Genre,
    [Range(0, 100)] decimal Price,
    DateTime ReleaseDate,
    [Url] string ImageUri
);
