namespace StartInEFCore.Models;

public class Director
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public Guid MoveStudioId { get; set; }

    public MovieStudio? MovieStudio { get; set; }
}
