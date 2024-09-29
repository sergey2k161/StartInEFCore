namespace StartInEFCore.Models;

public class Film
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double Rating { get; set; }

    public TimeSpan Duration { get; set; }

    public Guid MoveStudioId { get; set; }

    public MovieStudio? MovieStudio { get; set; }
}
