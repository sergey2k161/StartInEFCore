namespace StartInEFCore.Models;

public class Actor
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public Guid MoveStudioId { get; set; }

    public List<MovieStudio> MovieStudios { get; set; } = [];
}
