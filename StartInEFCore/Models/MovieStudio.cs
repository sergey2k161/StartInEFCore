namespace StartInEFCore.Models;

public class MovieStudio
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Discription { get; set; } = string.Empty;

    public Guid DirectorId { get; set; }

    public Director? Director { get; set; }

    public List<Film> Films { get; set; } = [];

    public List<Actor> Actors { get; set; } = [];
}
